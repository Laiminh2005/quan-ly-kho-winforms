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
    public partial class FormThemPhieuNhap : Form
    {
        private Action<Form> OpenChildForm;
        private Modify modify;
        public FormThemPhieuNhap(Action<Form> OpenChildForm)
        {
            InitializeComponent();
            this.OpenChildForm = OpenChildForm;
            modify = new Modify();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maPN = txtMaPN.Text.Trim().ToUpper();
            string maNV = txtMaNV.Text.Trim().ToUpper();
            DateTime ngayTao = NgayTao.Value;

            if (string.IsNullOrEmpty(maPN) || string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (modify.CheckMaPhieuDaTonTai2(maPN))
            {
                MessageBox.Show("Đã có phiếu trong dữ liệu!", "Lỗi trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!modify.CheckMaNhanVienTonTai(maNV))
            {
                MessageBox.Show("Sai mã nhân viên! Mã không tồn tại trong dữ liệu.", "Lỗi mã nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!modify.checkChucVuNhanVien(maNV))
            {
                MessageBox.Show("Chỉ nhân viên kho mới có thể tạo phiếu!", "Lỗi quyền hạn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = $"INSERT INTO PHIEUNHAP (MaPN, NgayLap, MaNV, TrangThai) " +
                           $"VALUES ('{maPN}', '{ngayTao:yyyy-MM-dd}', '{maNV}', N'Nháp')";

            try
            {
                modify.Command(query);

                MessageBox.Show("Tạo phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau khi lưu → mở chi tiết phiếu nhập
                OpenChildForm?.Invoke(new FormChiTietPhieuNhap(maPN, "Nháp", OpenChildForm));


                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu nhập: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            OpenChildForm?.Invoke(new FormPhieuNhapHang(OpenChildForm));

            // Đóng form tạo phiếu
            this.Close();
        }
    }
}
