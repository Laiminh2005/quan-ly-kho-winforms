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
    public partial class FormPhieuNhapHang : Form
    {
        private Action<Form> OpenChildForm;
        public FormPhieuNhapHang(Action<Form> OpenChildForm)
        {
            InitializeComponent();
            this.OpenChildForm = OpenChildForm;
        }
        Modify modify;

        private void FormPhieuNhapHang_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dgvPhieuNhap.DataSource = modify.getAllphieunhap();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadCounts();   // Load số lượng lên button
            loadData("Chờ duyệt"); // Load tất cả bản ghi
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormThemPhieuNhap(OpenChildForm));
        }
        private void loadCounts()
        {
            btnALL.Text = $"Tất cả ({modify.countByStatus("ALL")})";
            btnChoduyet.Text = $"Chờ duyệt ({modify.countByStatus("Chờ duyệt")})";
            btnDaduyet.Text = $"Đã duyệt ({modify.countByStatus("Đã Duyệt")})";
            btnNhap.Text = $"Nháp ({modify.countByStatus("Nháp")})";
        }
        private void loadData(string status)
        {
            dgvPhieuNhap.DataSource = modify.getPhieuNhapByStatus(status);
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            loadData("ALL");
        }

        private void btnChoduyet_Click(object sender, EventArgs e)
        {
            loadData("Chờ duyệt");
        }

        private void btnDaduyet_Click(object sender, EventArgs e)
        {
            loadData("Đã Duyệt");
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            loadData("Nháp");
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhieuNhap.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn 1 phiếu để xem!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maPN = dgvPhieuNhap.CurrentRow.Cells["MaPN"].Value.ToString();
                string trangThai = dgvPhieuNhap.CurrentRow.Cells["TrangThai"].Value.ToString();

                // Gọi OpenChildForm để mở FormChiTietPhieuNhap
                OpenChildForm(new FormChiTietPhieuNhap(maPN, trangThai, OpenChildForm));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu cần xóa!");
                return;
            }

            string maPN = dgvPhieuNhap.CurrentRow.Cells["MaPN"].Value.ToString();
            string trangThai = dgvPhieuNhap.CurrentRow.Cells["TrangThai"].Value.ToString();

            // Kiểm tra điều kiện xóa
            if (trangThai != "Nháp")
            {
                MessageBox.Show("Chỉ có thể xóa phiếu ở trạng thái 'Nháp'!",
                    "Không thể xóa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult r = MessageBox.Show(
                $"Bạn có chắc muốn xóa phiếu {maPN} không?\n(Lưu ý: Dữ liệu CTPHIEUNHAP cũng sẽ bị xóa)",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                if (modify.DeletePhieuNhap(maPN))
                {
                    MessageBox.Show("Xóa phiếu thành công!");

                    // Reload dữ liệu và số lượng
                    loadData("ALL");
                    loadCounts();
                }
                else
                {
                    MessageBox.Show("Xóa phiếu thất bại!");
                }
            }
        }

        private void btnGuiPhieu_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu để gửi!");
                return;
            }

            string maPN = dgvPhieuNhap.CurrentRow.Cells["MaPN"].Value.ToString();
            string trangThai = dgvPhieuNhap.CurrentRow.Cells["TrangThai"].Value.ToString();

            if (trangThai != "Nháp")
            {
                MessageBox.Show("Chỉ những phiếu có trạng thái 'Nháp' mới được gửi!");
                return;
            }

            DialogResult r = MessageBox.Show(
                $"Bạn có chắc muốn gửi phiếu {maPN} không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                if (modify.GuiPhieu(maPN))
                {
                    MessageBox.Show("Gửi phiếu thành công!");

                    // Load lại dữ liệu để cập nhật trạng thái
                    loadData("ALL");

                    // Đồng thời cập nhật lại số lượng các nhóm
                    loadCounts();
                }
                else
                {
                    MessageBox.Show("Gửi phiếu thất bại!");
                }
            }
        }
    }
}
