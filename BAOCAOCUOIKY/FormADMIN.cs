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
    public partial class FormADMIN : Form
    {
        public string ChucVu;
        public FormADMIN(string chucVu)
        {
            InitializeComponent();
            ChucVu = chucVu;
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnPNH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormThongKe(OpenChildForm));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnFormDuyetPhieu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDuyetDonHang(OpenChildForm));
        }

        private void btnLSUxuat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new lichsuxuathang(OpenChildForm));
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQLNV(OpenChildForm));
        }

        private void btnQlySanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQLSP(ChucVu,OpenChildForm));
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FormDangNhap frm = new FormDangNhap();
            frm.Show();
            this.Hide();
        }
    }
}
