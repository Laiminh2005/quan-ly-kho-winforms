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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private string GetChucVu(string maNV, string matKhau)
        {
            string query = @"SELECT ChucVu 
                             FROM NHANVIEN 
                             WHERE MaNV = @MaNV 
                               AND MatKhau = @MatKhau 
                               AND TrangThai = N'Đang làm'";

            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = maNV.Trim();
                cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = matKhau.Trim();

                object result = cmd.ExecuteScalar();

                if (result != null)
                    return result.ToString(); // trả về chức vụ

                return ""; // không tìm thấy
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (maNV == "" || matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Lấy chức vụ từ DB
            string chucVu = GetChucVu(maNV, matKhau);

            if (chucVu == "")
            {
                MessageBox.Show("Sai Mã nhân viên hoặc Mật khẩu!");
                return;
            }

            MessageBox.Show("Đăng nhập thành công!");

            // ================================
            // PHÂN QUYỀN THEO CHỨC VỤ
            // ================================
            string cv = chucVu.Trim().ToLower();

            if (cv == "quản lý" || cv == "quan ly")
            {
                FormADMIN frm = new FormADMIN(chucVu);
                frm.Show();
                this.Hide();
            }
            else
            {
                PhieuNhapXuat frm = new PhieuNhapXuat(chucVu);
                frm.Show();
                this.Hide();
            }
        }
    }
}
