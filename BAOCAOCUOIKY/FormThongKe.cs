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
    public partial class FormThongKe : Form
    {
        private Action<Form> OpenChildForm;
        public FormThongKe(Action<Form> OpenChildForm)
        {
            InitializeComponent();
            this.OpenChildForm = OpenChildForm;
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            Modify modify = new Modify();
            lbldemnv.Text = modify.CountNhanVien().ToString();
            lblPhieu.Text = modify.CountPhieuNhap().ToString();
            lblDemSp.Text = modify.CountSanPham().ToString();
            lblTongDT.Text = modify.GetTongTienLichSu().ToString("N0") + " VND";
            dgvPhieuCho.DataSource = modify.getPhieuCho();
            dvgCanhCaoTK.DataSource = modify.getCanhCaoTonKho();
        }

        private void lblTongDT_Click(object sender, EventArgs e)
        {

        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            FormBackUp f = new FormBackUp();
            f.ShowDialog();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            FormRestore f = new FormRestore();
            f.ShowDialog();
        }
    }
}
