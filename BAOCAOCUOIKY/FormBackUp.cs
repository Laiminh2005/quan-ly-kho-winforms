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
    public partial class FormBackUp : Form
    {
        public FormBackUp()
        {
            InitializeComponent();
        }


        private void FormBackUp_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if(fb.ShowDialog() == DialogResult.OK)
            {
                txtDuongdan.Text = fb.SelectedPath;
                btnBackUp.Enabled = true;
            }
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDuongdan.Text))
            {
                MessageBox.Show("Vui lòng chọn đường dẫn lưu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Modify modify = new Modify();
            if (modify.BackupDatabase(txtDuongdan.Text))
            {
                MessageBox.Show("Backup thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Backup thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
