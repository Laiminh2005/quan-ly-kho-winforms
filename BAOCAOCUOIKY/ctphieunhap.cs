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
    public partial class ctphieunhap : Form
    {
        private Action<Form> OpenChildForm;
        Modify modify = new Modify();
        private string MaPN;
        public ctphieunhap(string maPn,Action<Form> openChildForm)
        {
            InitializeComponent();
            OpenChildForm = openChildForm;
            MaPN = maPn;
        }
 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ctphieunhap_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = modify.getAllCTPhieuNhap(MaPN);
                dataGridView1.Columns["MaSP"].HeaderText = "Mã sản phẩm";
                dataGridView1.Columns["TenSP"].HeaderText = "Tên sản phẩm";
                dataGridView1.Columns["SoLuong"].HeaderText = "Số lượng";
                dataGridView1.Columns["DonGiaNhap"].HeaderText = "Đơn giá nhập";
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
