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
    public partial class ThemPhieuXuat : Form
    {
        private Action<Form> OpenChildForm;
        private Modify modify;
        public ThemPhieuXuat(Action<Form> OpenChildForm)
        {
            InitializeComponent();
            this.OpenChildForm = OpenChildForm;
            modify = new Modify();
        }

        private void ThemPhieuXuat_Load(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maPX = txtMaPN.Text.Trim().ToUpper();
            string maNV = txtMaNV.Text.Trim().ToUpper();
            DateTime ngayTao = NgayTao.Value;
            if (string.IsNullOrEmpty(maPX) || string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (modify.CheckMaPhieuDaTonTai(maPX)  || modify.CheckMaPhieuTonTaiTrongLichSu(maPX))
            {
                MessageBox.Show("Đã có phiếu trong dữ liệu!", "Lỗi trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!modify.CheckMaNhanVienTonTai(maNV))
            {
                MessageBox.Show("Sai mã nhân viên! Mã không tồn tại trong dữ liệu.", "Lỗi mã nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!modify.checkChucVuNhanVien(maNV))
            {
                MessageBox.Show("Chỉ nhân viên kho mới có thể tạo phiếu!", "Lỗi quyền hạn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = $"INSERT INTO PHIEUXUAT (MaPX, NgayLap, MaNV, TongTien) " +
                           $"VALUES ('{maPX}', '{ngayTao:yyyy-MM-dd}', '{maNV}', '0')";

            try
            {
                modify.Command(query);

                MessageBox.Show("Tạo phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau khi lưu → mở chi tiết phiếu nhập
                ChiTietPhieuXuat f = new ChiTietPhieuXuat(maPX,OpenChildForm);
                OpenChildForm?.Invoke(f);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu nhập: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            OpenChildForm?.Invoke(new PhienXuatHang(OpenChildForm));

            // Đóng form tạo phiếu
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
