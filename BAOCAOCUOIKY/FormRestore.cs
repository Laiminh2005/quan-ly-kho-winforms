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
    public partial class FormRestore : Form
    {
        public FormRestore()
        {
            InitializeComponent();
        }

        private void btnBrowseRT_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Backup files (.bak)|*.bak";

            if (open.ShowDialog() == DialogResult.OK)
            {
                txtDuongdanRT.Text = open.FileName;
                btnBackUpRT.Enabled = true;
            }
        }

        private void btnBackUpRT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDuongdanRT.Text))
            {
                MessageBox.Show("Vui lòng chọn file backup!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Modify modify = new Modify();

            if (modify.RestoreDatabase(txtDuongdanRT.Text))
            {
                MessageBox.Show("Khôi phục dữ liệu thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Khôi phục thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
