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
    public partial class FormChiTietPhieuNhap : Form
    {
        private string maPN;
        private string trangThai;
        Modify modify = new Modify();
        private Action<Form> OpenChildForm;
        public FormChiTietPhieuNhap(string maPN, string trangThai, Action<Form> OpenChildForm)
        {
            InitializeComponent();
            this.maPN = maPN;
            this.trangThai = trangThai;
            this.OpenChildForm = OpenChildForm;
        }

        private void FormChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadComboBoxMaSP();

            // Gán thông tin
            txtMaPN.Text = maPN;
            txtTrangThai.Text = trangThai;

            // Load bảng chi tiết
            LoadChiTiet();

            // Tính tổng tiền
            LoadTongTien();
        }
        private void LoadChiTiet()
        {
            DataTable dt = modify.GetCTPN(maPN);
            dgvChitietPN.DataSource = dt;

            //dgvChitietPN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void LoadTongTien()
        {
            decimal tong = modify.GetTongTien(maPN);
            labThanhTien.Text = tong.ToString("N0") + " VNĐ";
        }
        private void LoadComboBoxMaSP()
        {
            Modify modify = new Modify();
            DataTable dt = modify.GetAllProductCodes();

            cboMasp.DataSource = dt;
            cboMasp.DisplayMember = "MaSP"; // cái hiển thị
            cboMasp.ValueMember = "MaSP";   // giá trị thực tế
            cboMasp.SelectedIndex = -1;     // không chọn gì lúc đầu
        }

        private void cboMasp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMasp.SelectedIndex == -1) return;

            string maSP = cboMasp.SelectedValue.ToString();

            //Modify modify = new Modify();
            DataRow info = modify.GetProductInfo(maSP);

            if (info != null)
            {
                txtTenSP.Text = info["TenSP"].ToString();
                txtDonvitinh.Text = info["DonViTinh"].ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            OpenChildForm?.Invoke(new FormPhieuNhapHang(OpenChildForm));

            // Đóng form tạo phiếu
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTrangThai.Text != "Nháp")
            {
                MessageBox.Show("Chỉ thêm được khi trạng thái là Nháp!");
                return;
            }

            if (cboMasp.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }

            string maPN = txtMaPN.Text;
            string maSP = cboMasp.SelectedValue.ToString();

            //  Chống trùng sản phẩm trong cùng 1 phiếu
            if (modify.KiemTraSPTrongPhieu(maPN, maSP))
            {
                MessageBox.Show("Sản phẩm này đã có trong phiếu!");
                return;
            }

            // Lấy giá nhập
            float donGia = modify.LayDonGia(maSP);

            if (modify.ThemCTPN(maPN, maSP, soLuong, donGia))
            {
                dgvChitietPN.DataSource = modify.LoadCTPN(maPN);

                decimal tong = modify.TinhTongTien(maPN);
                labThanhTien.Text = tong.ToString("N0") + " VNĐ";

                txtSoLuong.Clear();
                //MessageBox.Show("Thêm thành công!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // 1. Chỉ xóa khi là Nháp
            if (txtTrangThai.Text != "Nháp")
            {
                MessageBox.Show("Chỉ xóa được khi phiếu đang ở trạng thái Nháp!");
                return;
            }

            // 2. Kiểm tra đã chọn dòng trong DataGridView chưa
            if (dgvChitietPN.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!");
                return;
            }

            string maPN = txtMaPN.Text;
            string maSP = dgvChitietPN.CurrentRow.Cells["MaSP"].Value.ToString();

            // 3. Xác nhận xóa
            DialogResult rs = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sản phẩm này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.No) return;

            // 4. Xóa trong DB
            if (modify.XoaCTPN(maPN, maSP))
            {
                MessageBox.Show("Xóa thành công!");

                // Load lại danh sách
                dgvChitietPN.DataSource = modify.LoadCTPN(maPN);

                // Cập nhật lại tổng tiền
                decimal tong = modify.TinhTongTien(maPN);
                labThanhTien.Text = tong.ToString("N0") + " VNĐ";
            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
        }

        private void dgvChitietPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvChitietPN.Rows[e.RowIndex];

            cboMasp.Text = row.Cells["MaSP"].Value.ToString();
            txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
            txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (txtTrangThai.Text != "Nháp")
            {
                MessageBox.Show("Chỉ chỉnh sửa khi trạng thái là Nháp!");
                return;
            }

            if (dgvChitietPN.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }

            string maPN = txtMaPN.Text;
            string maSP = dgvChitietPN.CurrentRow.Cells["MaSP"].Value.ToString();

            float donGia = modify.LayDonGia(maSP);

            if (modify.CapNhatCTPN(maPN, maSP, soLuong, donGia))
            {
                //MessageBox.Show("Cập nhật thành công!");

                // Load lại danh sách
                dgvChitietPN.DataSource = modify.LoadCTPN(maPN);

                // Cập nhật tổng tiền
                decimal tong = modify.TinhTongTien(maPN);
                labThanhTien.Text = tong.ToString("N0") + " VNĐ";

                txtSoLuong.Clear();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }
    }
}
