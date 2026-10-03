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
    public partial class PhieuNhapXuat : Form
    {
        public string ChucVu;
        public PhieuNhapXuat(string chucVu)
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
            OpenChildForm(new FormPhieuNhapHang(OpenChildForm));
        }

        private void btnPXH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhienXuatHang(OpenChildForm));
        }

        private void PhieuNhapXuat_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSpham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQLSP(ChucVu,OpenChildForm));
        }

        private void ptbAvatar_Click(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FormDangNhap frm = new FormDangNhap();
            frm.Show();
            this.Hide();
        }
    }
}
