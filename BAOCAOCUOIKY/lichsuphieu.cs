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
    public partial class lichsuphieu : Form
    {
        Modify modify;
        private Action<Form> OpenChildForm;
        public lichsuphieu(Action<Form> openChildForm)
        {
            InitializeComponent();
            OpenChildForm = openChildForm;
        }

        private void lichsuphieu_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.getPhieuNhapDaDuyet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối dữ liệu:" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm?.Invoke(new FormDuyetDonHang(OpenChildForm));
            this.Close();
        }
    }
}
