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
    public partial class FormQLNV : Form
    {
        private Action<Form> OpenChildForm;
        public FormQLNV(Action<Form> openChildForm)
        {
            InitializeComponent();
            OpenChildForm = openChildForm;
        }
        Modify modify = new Modify();
        nhanvien nhanVien;

        private void FormQLNV_Load(object sender, EventArgs e)
        {
            try
            {
                dgv.DataSource = modify.getAllNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaNV = txtMaNV.Text.Trim();
            string TenNV = txtTenNV.Text;
            string MatKhau = txtMatKhau.Text;
            string SoDienThoai = txtSoDienThoai.Text;
            string DiaChi = txtDiaChi.Text;
            DateTime NgayLam = dtpNgayLam.Value;
            string ChucVu = cmbChucVu.Text;
            string TrangThai = "Đang làm";
            if (string.IsNullOrWhiteSpace(MaNV) || string.IsNullOrWhiteSpace(TenNV))
            {
                MessageBox.Show("Mã NV và Tên NV không được để trống!");
                return;
            }
            // ⭐ NEW: Kiểm tra trùng mã — kể cả nghỉ việc
            if (modify.CheckExistMaNV(MaNV))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại (bao gồm cả nhân viên đang nghỉ). Vui lòng nhập mã khác!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.nhanVien = new nhanvien(MaNV, TenNV, MatKhau, ChucVu, SoDienThoai, DiaChi, NgayLam, TrangThai);

            if (modify.insertNV(nhanVien))
            {
                dgv.DataSource = modify.getAllNhanVien();
            }
            else
            {
                MessageBox.Show("Lỗi: Không thêm được nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên trước!");
                return;
            }

            string MaNV = txtMaNV.Text;
            string TenNV = txtTenNV.Text;
            string MatKhau = txtMatKhau.Text;
            string SoDienThoai = txtSoDienThoai.Text;
            string DiaChi = txtDiaChi.Text;
            DateTime NgayLam = dtpNgayLam.Value;
            string ChucVu = cmbChucVu.Text;
            string TrangThai = "Đang làm";

            if (string.IsNullOrWhiteSpace(MaNV) || string.IsNullOrWhiteSpace(TenNV))
            {
                MessageBox.Show("Mã NV và Tên NV không được để trống!");
                return;
            }
            this.nhanVien = new nhanvien(MaNV, TenNV, MatKhau, ChucVu, SoDienThoai, DiaChi, NgayLam, TrangThai);

            if (modify.updateNV(nhanVien))
            {
                dgv.DataSource = modify.getAllNhanVien();
            }
            else
            {
                MessageBox.Show("Lỗi: Không sửa được nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ra không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên trước!");
                return;
            }
            string MaNV = dgv.SelectedRows[0].Cells[0].Value.ToString();

            if (modify.deleteNV(MaNV))
            {
                dgv.DataSource = modify.getAllNhanVien();
            }
            else
            {
                MessageBox.Show("Lỗi: Không xóa được nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtTenNV.Text = row.Cells[1].Value.ToString();
                txtMatKhau.Text = row.Cells[2].Value.ToString();
                cmbChucVu.Text = row.Cells[3].Value.ToString();
                txtSoDienThoai.Text = row.Cells[4].Value.ToString();
                txtDiaChi.Text = row.Cells[5].Value.ToString();
                dtpNgayLam.Text = row.Cells[6].Value.ToString();

            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string key = txtTimkiem.Text.Trim();

            if (key == "")
            {
                dgv.DataSource = modify.getAllNhanVien();
            }
            else
            {
                dgv.DataSource = modify.TimkiemNV(key);
            }
        }

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtMatKhau.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            cmbChucVu.Text = "";
            dtpNgayLam.Text = "";
        }

        private void cmbChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
