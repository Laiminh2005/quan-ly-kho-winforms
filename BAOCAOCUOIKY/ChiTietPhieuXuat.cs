using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAOCAOCUOIKY
{
    public partial class ChiTietPhieuXuat : Form
    {
        private string maPhieuXuat="";
        private Action<Form> OpenChildForm;
        private bool isEditing = false;
        public ChiTietPhieuXuat(string MaPX, Action<Form> openChildForm)
        {
            InitializeComponent();
            maPhieuXuat = MaPX;
            OpenChildForm = openChildForm;
            isEditing = true;
        }
        Modify modify;
        private void LoadChiTiet()
        {
            // Lấy DataTable từ DB
            DataTable dt = modify.GetCTPhieuXuat(maPhieuXuat);

            // 1) Ngắt binding (nếu có) để có thể dùng Rows.Add()
            dataGridView1.DataSource = null;

            // 2) Clear rows hiện tại
            dataGridView1.Rows.Clear();

            // 3) Nếu bạn muốn đảm bảo các cột tồn tại - tạo nếu chưa có
            //    (thay header/text theo thiết kế của bạn)
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("MaSP", "Mã SP");
                dataGridView1.Columns.Add("TenSP", "Tên SP");
                dataGridView1.Columns.Add("DVT", "Đơn vị");
                dataGridView1.Columns.Add("SL", "Số lượng");
                dataGridView1.Columns.Add("Gia", "Đơn giá");
                dataGridView1.Columns.Add("ThanhTien", "Thành tiền");
            }
            else
            {
                // nếu đã có cột, đảm bảo tên cột khớp với code (tên Name)
                // nếu header text khác không sao, nhưng Name phải tương ứng
                // bạn có thể set lại Name nếu muốn:
                // dataGridView1.Columns[0].Name = "MaSP"; ...
            }

            // 4) Thêm từng dòng từ DataTable
            foreach (DataRow r in dt.Rows)
            {
                object[] values = new object[]
                {
            r["MaSP"],
            r["TenSP"],
            r["DonViTinh"],
            r["SoLuong"],
            r["DonGiaXuat"],
            r["ThanhTien"]
                };

                dataGridView1.Rows.Add(values);
            }
        }

        private void ChiTietPhieuXuat_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            DataTable dt = modify.GetDanhSachSanPham2();

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "MaSP";   // cái để hiển thị
            comboBox1.ValueMember = "MaSP";     // giá trị thực
            txtMaPX.Text = maPhieuXuat;         // gán mã phiếu xuất

            if (isEditing)
                LoadChiTiet();
        }
        int slTon = 0;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng!");
                return;
            }

            int slNhap = int.Parse(txtSoLuong.Text);

            if (slNhap <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!");
                return;
            }

            if (slNhap > slTon)
            {
                MessageBox.Show($"Số lượng vượt quá tồn kho! Tồn kho hiện tại: {slTon}");
                return;
            }
            
            //string maPX = txtMaPX.Text;
            string maSP = comboBox1.SelectedValue.ToString();
            string tenSP = txtTenSP.Text;
            string dvt = txtDVT.Text;
            double gia = double.Parse(textBox1.Text);
            double thanhTien = slNhap * gia;

            //if (modify.KiemTraSPTrongPhieu2(maPX, maSP))
            //{
            //    MessageBox.Show("Sản phẩm này đã có trong phiếu!");
            //    return;
            //}
            // Kiểm tra trùng ngay trong DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == maSP)
                {
                    MessageBox.Show("Sản phẩm này đã có trong phiếu!");
                    return;
                }
            }
            dataGridView1.Rows.Add(
                maSP,
                tenSP,
                dvt,
                slNhap,
                gia,
                thanhTien
            );

            MessageBox.Show("Thêm sản phẩm vào phiếu xuất thành công!");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null) return;

            string maSP = comboBox1.SelectedValue.ToString();
            DataTable dt = modify.GetSanPham(maSP);

            if (dt.Rows.Count > 0)
            {
                txtTenSP.Text = dt.Rows[0]["TenSP"].ToString();
                txtDVT.Text = dt.Rows[0]["DonViTinh"].ToString();
                textBox1.Text = dt.Rows[0]["DonGia"].ToString();
                slTon = Convert.ToInt32(dt.Rows[0]["SLTon"]);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPX.Text))
            {
                MessageBox.Show("Chưa có mã phiếu xuất!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maPX = txtMaPX.Text;

            //if (dataGridView1.Rows.Count == 0)
            //{
            //    MessageBox.Show("Phiếu xuất chưa có sản phẩm!");
            //    return;
            //}
            if (isEditing)
            {
                modify.XoaCTPhieuXuat(maPX);
            }    
                
            // Lưu toàn bộ dòng trong DGV vào database
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string maSP = row.Cells["MaSP"].Value.ToString();
                int soLuong = Convert.ToInt32(row.Cells["SL"].Value);
                double donGia = Convert.ToDouble(row.Cells["Gia"].Value);

                modify.InsertCTPhieuXuat(maPX, maSP, soLuong, donGia);
            }

            MessageBox.Show("Lưu phiếu xuất thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            OpenChildForm?.Invoke(new PhienXuatHang(OpenChildForm));
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để chỉnh sửa!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng!");
                return;
            }

            int slNhap = int.Parse(txtSoLuong.Text);

            if (slNhap <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!");
                return;
            }

            if (slNhap > slTon)
            {
                MessageBox.Show($"Số lượng vượt quá tồn kho! Tồn kho hiện tại: {slTon}");
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            string maSP = comboBox1.SelectedValue.ToString();
            string tenSP = txtTenSP.Text;
            string dvt = txtDVT.Text;
            int sl = int.Parse(txtSoLuong.Text);
            double gia = double.Parse(textBox1.Text);
            double thanhTien = sl * gia;

            // Gán lại vào dòng đang chọn
            row.Cells["MaSP"].Value = maSP;
            row.Cells["TenSP"].Value = tenSP;
            row.Cells["DVT"].Value = dvt;
            row.Cells["SL"].Value = sl;
            row.Cells["Gia"].Value = gia;
            row.Cells["ThanhTien"].Value = thanhTien;

            MessageBox.Show("Cập nhật thành công!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            comboBox1.SelectedValue = row.Cells["MaSP"].Value.ToString();
            txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
            txtDVT.Text = row.Cells["DVT"].Value.ToString();
            txtSoLuong.Text = row.Cells["SL"].Value.ToString();
            textBox1.Text = row.Cells["Gia"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                MessageBox.Show("Đã xóa sản phẩm khỏi phiếu xuất!");
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            OpenChildForm?.Invoke(new PhienXuatHang(OpenChildForm));

            // Đóng form tạo phiếu
            this.Close();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) &&
            !char.IsControl(e.KeyChar) &&
            !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
