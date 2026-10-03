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
    public partial class lichsuxuathang : Form
    {
        private Action<Form> OpenChildForm;
        Modify modify = new Modify();
        public lichsuxuathang(Action<Form> OpenChildForm)
        {
            InitializeComponent();
            this.OpenChildForm = OpenChildForm;
        }

        private void lichsuxuathang_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = modify.getLichSuPhieuXuat();
            dataGridView1.Columns["MaPX"].HeaderText = "Mã phiếu xuất";  
            dataGridView1.Columns["NgayXuat"].HeaderText = "Ngày xuất";
            dataGridView1.Columns["TongTien"].HeaderText = "Tổng tiền";
            dataGridView1.Columns["MaNV"].HeaderText = "Mã nhân viên";

            label2.Text = modify.GetTongTienLichSu().ToString("N0") + " VND";    
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
