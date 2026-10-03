using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAOCAOCUOIKY
{
    public partial class PhienXuatHang : Form
    {
        private Action<Form> OpenChildForm;
        Modify modify;
        public PhienXuatHang(Action<Form> OpenChildForm)
        {
            InitializeComponent();
            this.OpenChildForm = OpenChildForm;
        }
        private void DoiTenCot()
        {
            if (dataGridView1.Columns.Count == 0) return;
            dataGridView1.Columns["MaPX"].HeaderText = "Mã phiếu xuất";
            dataGridView1.Columns["NgayLap"].HeaderText = "Ngày lập";
            dataGridView1.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dataGridView1.Columns["TongTien"].HeaderText = "Tổng tiền";
        }
        private void PhienXuatHang_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.getAllphieuxuat();
                DoiTenCot();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối dữ liệu:" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThemPhieuXuat(OpenChildForm));
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn phiếu để xóa!");
                return;
            }

            // Lấy mã phiếu từ dòng đang chọn
            string maPX = dataGridView1.CurrentRow.Cells["MaPX"].Value.ToString();

            if (MessageBox.Show(
                $"Bạn có chắc muốn xóa phiếu xuất {maPX}?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Modify modify = new Modify();
                bool result = modify.XoaPhieuXuat(maPX);

                if (result)
                {
                    MessageBox.Show("Xóa phiếu xuất thành công!");
                    dataGridView1.DataSource = modify.getAllphieuxuat();
                    DoiTenCot();
                }
                else
                {
                    MessageBox.Show("Xóa phiếu thất bại!");
                }
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn phiếu xuất!");
                return;
            }

            string maPX = dataGridView1.CurrentRow.Cells["MaPX"].Value.ToString();

            ChiTietPhieuXuat form = new ChiTietPhieuXuat(maPX, OpenChildForm);
            OpenChildForm?.Invoke(form);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu xuất!");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            string maPX = row.Cells["MaPX"].Value.ToString();
            string maNV = row.Cells["MaNV"].Value.ToString();
            DateTime ngayXuat = DateTime.Now;

            double tongTien = Convert.ToDouble(row.Cells["TongTien"].Value);

            // 1) Lấy danh sách chi tiết phiếu xuất
            DataTable chiTiet = modify.GetCTPhieuXuat(maPX);

            if (chiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Phiếu xuất không có sản phẩm!");
                return;
            }

            // 2) TRỪ SỐ LƯỢNG
            foreach (DataRow sp in chiTiet.Rows)
            {
                string maSP = sp["MaSP"].ToString();
                int sl = Convert.ToInt32(sp["SoLuong"]);

                bool ok = modify.TruSoLuongXuat(maSP, sl);
                if (!ok)
                {
                    MessageBox.Show("Không đủ tồn kho cho sản phẩm: " + maSP);
                    return;
                }
            }

            // 3) LƯU LỊCH SỬ
            bool insertLS = modify.ThemLichSuXuat(maPX, ngayXuat, tongTien, maNV);
            if (!insertLS)
            {
                MessageBox.Show("Lỗi khi lưu lịch sử xuất hàng!");
                return;
            }

            // 4) XÓA CHI TIẾT + PHIẾU XUẤT
            modify.XoaCTPX(maPX);
            modify.XoaPhieuXuatKhiDaXuat(maPX);

            MessageBox.Show("Xuất hàng thành công!");

            dataGridView1.DataSource = modify.getAllphieuxuat();
            DoiTenCot();
        }
    }
}
