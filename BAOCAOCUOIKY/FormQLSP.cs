using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAOCAOCUOIKY
{
    public partial class FormQLSP : Form
    {
        private string ChucVu;
        private Action<Form> OpenChildForm;
        public FormQLSP(string chucVu,Action<Form> openChildForm)
        {
            InitializeComponent();
            ChucVu = chucVu;
            OpenChildForm = openChildForm;
        }
        Modify modify = new Modify();
        QuanLySanPham sanPham;

        private void FormQLSP_Load(object sender, EventArgs e)
        {
            try
            {
                dgv.DataSource = modify.getAllSanPham();
                if(ChucVu == "Nhân viên kho")
                {
                    btnXoa.Visible = false;
                    btnSua.Visible = false;
                    btnThem.Visible = false;
                    btnKhoiTao.Visible = false;
                    btnChonAnh.Visible = false;
                    txtDonGia.ReadOnly = true;
                    txtGiaNhap.ReadOnly = true;
                    txtDonViTinh.ReadOnly = true;
                    txtSLTon.ReadOnly = true;
                    txtTenSP.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private byte[] ImageToByArray(PictureBox pictureBox)
        {
            if (pictureBox.Image == null)
                return null;

            MemoryStream memoryStream = new MemoryStream();
            pictureBox.Image.Save(memoryStream, pictureBox.Image.RawFormat);
            return memoryStream.ToArray();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text.Trim() == "" ||
                txtTenSP.Text.Trim() == "" ||
                txtDonViTinh.Text.Trim() == "" ||
                txtGiaNhap.Text.Trim() == "" ||
                txtDonGia.Text.Trim() == "" ||
                txtSLTon.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (!float.TryParse(txtGiaNhap.Text, out float GiaNhap))
            {
                MessageBox.Show("Giá nhập không hợp lệ!");
                return;
            }

            if (!float.TryParse(txtDonGia.Text, out float DonGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return;
            }

            if (!int.TryParse(txtSLTon.Text, out int SlTon))
            {
                MessageBox.Show("Số lượng tồn không hợp lệ!");
                return;
            }

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Bạn chưa chọn ảnh sản phẩm!");
                return;
            }

            string MaSP = txtMaSP.Text.Trim();
            string TenSP = txtTenSP.Text.Trim();
            string DonViTinh = txtDonViTinh.Text.Trim();
            byte[] HinhAnh = ImageToByArray(pictureBox1);
            string TrangThai = "Đang bán";
             
            DataTable dt = modify.FindProductByID(MaSP);

            if (dt.Rows.Count > 0)
            {
                string oldTrangThai = dt.Rows[0]["TrangThai"].ToString();

                //  Nếu sản phẩm đang "Ngừng bán" → cho phép khôi phục
                if (oldTrangThai == "Ngừng bán")
                {
                    DialogResult ask = MessageBox.Show(
                        "Mã sản phẩm này đã tồn tại và đang ở trạng thái 'Ngừng bán'.\nBạn có muốn khôi phục và cập nhật sản phẩm này không?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (ask == DialogResult.Yes)
                    {
                        //  Khôi phục = update lại sản phẩm cũ
                        QuanLySanPham sanPham = new QuanLySanPham(
                            MaSP, TenSP, DonViTinh, GiaNhap, DonGia, SlTon, HinhAnh, "Đang bán"
                        );

                        if (modify.update(sanPham))
                        {
                            MessageBox.Show("Khôi phục sản phẩm thành công!");
                            dgv.DataSource = modify.getAllSanPham();
                        }
                        else
                        {
                            MessageBox.Show("Không thể khôi phục sản phẩm!");
                        }
                    }
                    return;
                }

                //  Nếu sản phẩm đang bán → không cho phép thêm
                MessageBox.Show("Mã sản phẩm đã tồn tại và đang được bán. Vui lòng nhập mã khác!");
                return;
            }

            //  Nếu không trùng → thêm mới bình thường
            QuanLySanPham newSP = new QuanLySanPham(
                MaSP, TenSP, DonViTinh, GiaNhap, DonGia, SlTon, HinhAnh, TrangThai
            );
            if (newSP.SLTon < 0 || newSP.DonGia <=0 || newSP.GiaNhap<=0)
            {
                MessageBox.Show("Giá trị không được âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (modify.insert(newSP))
            {
                MessageBox.Show("Thêm sản phẩm mới thành công!");
                dgv.DataSource = modify.getAllSanPham();
            }
            else
            {
                MessageBox.Show("Không thêm được sản phẩm!");
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn Ảnh";
            openFileDialog.Filter = "Image Files(*.gif; *.jpg; *.jpeg; *.png)|*.gif; *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog.FileName;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string MaSP = txtMaSP.Text.Trim();
            string TenSP = txtTenSP.Text.Trim();
            string DonViTinh = txtDonViTinh.Text.Trim();
            float GiaNhap = float.Parse(txtGiaNhap.Text);
            float DonGia = float.Parse(txtDonGia.Text);
            int SlTon = int.Parse(txtSLTon.Text);
            byte[] HinhAnh = ImageToByArray(pictureBox1);

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Bạn chưa chọn ảnh sản phẩm!");
                return;
            }

            // Kiểm tra sản phẩm có tồn tại không
            DataTable dt = modify.FindProductByID(MaSP);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm để sửa!");
                return;
            }

            string oldTrangThai = dt.Rows[0]["TrangThai"].ToString();

            // Nếu sản phẩm ngừng bán → KHÔNG CHO SỬA
            if (oldTrangThai == "Ngừng bán")
            {
                MessageBox.Show("Sản phẩm đang ở trạng thái 'Ngừng bán', không thể sửa!");
                return;
            }

            //  Nếu đang bán → sửa bình thường
            QuanLySanPham sanPham = new QuanLySanPham(
                MaSP, TenSP, DonViTinh, GiaNhap, DonGia, SlTon, HinhAnh, "Đang bán"
            );
            if (sanPham.SLTon < 0 || sanPham.DonGia <= 0 || sanPham.GiaNhap <= 0)
            {
                MessageBox.Show("Giá trị không được âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (modify.update(sanPham))
            {
                MessageBox.Show("Sửa sản phẩm thành công!");
                dgv.DataSource = modify.getAllSanPham();
            }
            else
            {
                MessageBox.Show("Không sửa được sản phẩm!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaSP = dgv.SelectedRows[0].Cells[0].Value.ToString();
            if (modify.delete(MaSP))
            {
                dgv.DataSource = modify.getAllSanPham();
            }
            else
            {
                MessageBox.Show("Lỗi: " + "Không xóa được ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string key = txtTimkiem.Text.Trim();

            if (key == "")
            {
                dgv.DataSource = modify.getAllSanPham();
            }
            else
            {
                dgv.DataSource = modify.Timkiem(key);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ click vào header
            if (e.RowIndex < 0) return;

            // Nếu click vào dòng thêm mới
            if (e.RowIndex == dgv.Rows.Count - 1)
            {
                txtMaSP.Enabled = true;   // cho phép nhập mã mới
                txtMaSP.Clear();
                txtTenSP.Clear();
                txtDonViTinh.Clear();
                txtGiaNhap.Clear();
                txtDonGia.Clear();
                txtSLTon.Clear();
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                return;
            }
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                txtMaSP.Text = row.Cells[0].Value?.ToString() ?? "";
                txtTenSP.Text = row.Cells[1].Value?.ToString() ?? "";
                txtDonViTinh.Text = row.Cells[2].Value?.ToString() ?? "";
                txtGiaNhap.Text = row.Cells[3].Value?.ToString() ?? "";
                txtDonGia.Text = row.Cells[4].Value?.ToString() ?? "";
                txtSLTon.Text = row.Cells[5].Value?.ToString() ?? "";

                txtMaSP.Enabled = false;

                // Ảnh
                if (row.Cells[6].Value != DBNull.Value && row.Cells[6].Value != null)
                {
                    byte[] imageBytes = (byte[])row.Cells[6].Value;
                    pictureBox1.Image = Image.FromStream(new MemoryStream(imageBytes));
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = "";
            txtMaSP.Enabled = true;
            txtTenSP.Text = "";
            txtDonViTinh.Text = "";
            txtGiaNhap.Text = "";
            txtDonGia.Text = "";
            txtSLTon.Text = "";
            pictureBox1.Image = null;
        }
    }
}
