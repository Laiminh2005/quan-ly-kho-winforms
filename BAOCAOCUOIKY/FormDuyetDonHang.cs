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
    public partial class FormDuyetDonHang : Form
    {
        Modify modify;
        private Action<Form> OpenChildForm;
        public FormDuyetDonHang(Action<Form> OpenChildForm)
        {
            InitializeComponent();
            this.OpenChildForm = OpenChildForm;
        }
        private void DoiTenCot()
        {
            if (dataGridView1.Columns.Count == 0) return;

            dataGridView1.Columns["MaPN"].HeaderText = "Mã phiếu nhập";
            dataGridView1.Columns["NgayLap"].HeaderText = "Ngày lập";
            dataGridView1.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 phiếu để hủy!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPN = dataGridView1.SelectedRows[0].Cells["MaPN"].Value.ToString();

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn hủy phiếu " + maPN + " ?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;
            string trangThai = dataGridView1.SelectedRows[0].Cells["TrangThai"].Value.ToString();

            if (trangThai == "Đã duyệt")
            {
                MessageBox.Show("Phiếu đã duyệt không thể hủy!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ok = modify.HuyPhieu(maPN);

            if (ok)
            {
                MessageBox.Show("Hủy phiếu thành công!");
                dataGridView1.DataSource = modify.getAllphieunhap();
                DoiTenCot();
            }
            else
            {
                MessageBox.Show("Hủy phiếu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 phiếu nhập trước khi duyệt!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            string maPN = row.Cells["MaPN"].Value.ToString();

            bool result = modify.DuyetPhieu(maPN);

            if (result)
            {
                MessageBox.Show("Duyệt phiếu thành công!");

                // load lại danh sách
                dataGridView1.DataSource = modify.getAllphieunhap();
                DoiTenCot();
            }
            else
            {
                MessageBox.Show("Duyệt phiếu thất bại!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new lichsuphieu(OpenChildForm));
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            modify = new Modify();
            try
            {
                dataGridView1.DataSource = modify.getAllphieunhap();
                DoiTenCot();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi kết nối dữ liệu:"+ex.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để xem chi tiết!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã phiếu nhập từ dòng đang chọn
            string maPN = dataGridView1.SelectedRows[0].Cells["MaPN"].Value.ToString();

            // Truyền mã vào form chi tiết
            OpenChildForm(new ctphieunhap(maPN,OpenChildForm));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string maPN = textBox1.Text.Trim();
            if (maPN == "")
            {
                MessageBox.Show("Nhập mã phiếu trước khi tìm!");
                return;
            }
            dataGridView1.DataSource = modify.TimKiemPhieuNhap(maPN);
            DoiTenCot();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
