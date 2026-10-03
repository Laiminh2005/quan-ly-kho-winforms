namespace BAOCAOCUOIKY
{
    partial class FormChiTietPhieuNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.labTongTien = new System.Windows.Forms.Label();
            this.labThanhTien = new System.Windows.Forms.Label();
            this.cboMasp = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnChinhSua = new System.Windows.Forms.Button();
            this.txtMaPN = new System.Windows.Forms.TextBox();
            this.txtDonvitinh = new System.Windows.Forms.TextBox();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.dgvChitietPN = new System.Windows.Forms.DataGridView();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.labMaPN = new System.Windows.Forms.Label();
            this.labDonVT = new System.Windows.Forms.Label();
            this.labSoLuong = new System.Windows.Forms.Label();
            this.labTenSP = new System.Windows.Forms.Label();
            this.labMaSP = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChitietPN)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.labTongTien);
            this.panel2.Controls.Add(this.labThanhTien);
            this.panel2.Location = new System.Drawing.Point(746, 457);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 40);
            this.panel2.TabIndex = 5;
            // 
            // labTongTien
            // 
            this.labTongTien.AutoSize = true;
            this.labTongTien.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTongTien.Location = new System.Drawing.Point(6, 10);
            this.labTongTien.Name = "labTongTien";
            this.labTongTien.Size = new System.Drawing.Size(76, 19);
            this.labTongTien.TabIndex = 1;
            this.labTongTien.Text = "Tổng Tiền";
            // 
            // labThanhTien
            // 
            this.labThanhTien.AutoSize = true;
            this.labThanhTien.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labThanhTien.ForeColor = System.Drawing.Color.Red;
            this.labThanhTien.Location = new System.Drawing.Point(118, 10);
            this.labThanhTien.Name = "labThanhTien";
            this.labThanhTien.Size = new System.Drawing.Size(57, 19);
            this.labThanhTien.TabIndex = 1;
            this.labThanhTien.Text = "0 VNĐ";
            // 
            // cboMasp
            // 
            this.cboMasp.FormattingEnabled = true;
            this.cboMasp.Location = new System.Drawing.Point(238, 50);
            this.cboMasp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboMasp.Name = "cboMasp";
            this.cboMasp.Size = new System.Drawing.Size(160, 27);
            this.cboMasp.TabIndex = 4;
            this.cboMasp.SelectedIndexChanged += new System.EventHandler(this.cboMasp_SelectedIndexChanged);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.BackColor = System.Drawing.Color.LightGreen;
            this.btnThem.Location = new System.Drawing.Point(701, 50);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(132, 40);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(848, 106);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(132, 40);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.BackColor = System.Drawing.Color.Tomato;
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnXoa.Location = new System.Drawing.Point(701, 106);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(132, 40);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa sản phẩm";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnChinhSua
            // 
            this.btnChinhSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChinhSua.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnChinhSua.Location = new System.Drawing.Point(848, 50);
            this.btnChinhSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChinhSua.Name = "btnChinhSua";
            this.btnChinhSua.Size = new System.Drawing.Size(132, 40);
            this.btnChinhSua.TabIndex = 3;
            this.btnChinhSua.Text = "Chỉnh sửa";
            this.btnChinhSua.UseVisualStyleBackColor = false;
            this.btnChinhSua.Click += new System.EventHandler(this.btnChinhSua_Click);
            // 
            // txtMaPN
            // 
            this.txtMaPN.Location = new System.Drawing.Point(25, 50);
            this.txtMaPN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaPN.Multiline = true;
            this.txtMaPN.Name = "txtMaPN";
            this.txtMaPN.ReadOnly = true;
            this.txtMaPN.Size = new System.Drawing.Size(160, 41);
            this.txtMaPN.TabIndex = 2;
            this.txtMaPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDonvitinh
            // 
            this.txtDonvitinh.Location = new System.Drawing.Point(25, 115);
            this.txtDonvitinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDonvitinh.Multiline = true;
            this.txtDonvitinh.Name = "txtDonvitinh";
            this.txtDonvitinh.ReadOnly = true;
            this.txtDonvitinh.Size = new System.Drawing.Size(160, 41);
            this.txtDonvitinh.TabIndex = 2;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(452, 115);
            this.txtTrangThai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTrangThai.Multiline = true;
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.ReadOnly = true;
            this.txtTrangThai.Size = new System.Drawing.Size(160, 41);
            this.txtTrangThai.TabIndex = 2;
            this.txtTrangThai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(238, 115);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoLuong.Multiline = true;
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(160, 41);
            this.txtSoLuong.TabIndex = 2;
            this.txtSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvChitietPN
            // 
            this.dgvChitietPN.AllowUserToAddRows = false;
            this.dgvChitietPN.AllowUserToDeleteRows = false;
            this.dgvChitietPN.AllowUserToResizeColumns = false;
            this.dgvChitietPN.AllowUserToResizeRows = false;
            this.dgvChitietPN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChitietPN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChitietPN.BackgroundColor = System.Drawing.Color.White;
            this.dgvChitietPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChitietPN.Location = new System.Drawing.Point(12, 187);
            this.dgvChitietPN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChitietPN.Name = "dgvChitietPN";
            this.dgvChitietPN.ReadOnly = true;
            this.dgvChitietPN.RowHeadersVisible = false;
            this.dgvChitietPN.RowHeadersWidth = 62;
            this.dgvChitietPN.RowTemplate.Height = 28;
            this.dgvChitietPN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChitietPN.Size = new System.Drawing.Size(995, 261);
            this.dgvChitietPN.TabIndex = 1;
            this.dgvChitietPN.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChitietPN_CellClick);
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(452, 50);
            this.txtTenSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenSP.Multiline = true;
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.ReadOnly = true;
            this.txtTenSP.Size = new System.Drawing.Size(160, 41);
            this.txtTenSP.TabIndex = 2;
            // 
            // labMaPN
            // 
            this.labMaPN.AutoSize = true;
            this.labMaPN.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMaPN.Location = new System.Drawing.Point(21, 30);
            this.labMaPN.Name = "labMaPN";
            this.labMaPN.Size = new System.Drawing.Size(107, 19);
            this.labMaPN.TabIndex = 1;
            this.labMaPN.Text = "Mã phiếu nhập";
            // 
            // labDonVT
            // 
            this.labDonVT.AutoSize = true;
            this.labDonVT.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDonVT.Location = new System.Drawing.Point(21, 95);
            this.labDonVT.Name = "labDonVT";
            this.labDonVT.Size = new System.Drawing.Size(84, 19);
            this.labDonVT.TabIndex = 1;
            this.labDonVT.Text = "Đơn vị tính";
            // 
            // labSoLuong
            // 
            this.labSoLuong.AutoSize = true;
            this.labSoLuong.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSoLuong.Location = new System.Drawing.Point(235, 95);
            this.labSoLuong.Name = "labSoLuong";
            this.labSoLuong.Size = new System.Drawing.Size(75, 19);
            this.labSoLuong.TabIndex = 1;
            this.labSoLuong.Text = "Số Lượng";
            // 
            // labTenSP
            // 
            this.labTenSP.AutoSize = true;
            this.labTenSP.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTenSP.Location = new System.Drawing.Point(450, 31);
            this.labTenSP.Name = "labTenSP";
            this.labTenSP.Size = new System.Drawing.Size(100, 19);
            this.labTenSP.TabIndex = 1;
            this.labTenSP.Text = "Tên sản phẩm";
            // 
            // labMaSP
            // 
            this.labMaSP.AutoSize = true;
            this.labMaSP.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMaSP.Location = new System.Drawing.Point(235, 30);
            this.labMaSP.Name = "labMaSP";
            this.labMaSP.Size = new System.Drawing.Size(97, 19);
            this.labMaSP.TabIndex = 1;
            this.labMaSP.Text = "Mã sản phẩm";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvChitietPN);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 509);
            this.panel1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboMasp);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnChinhSua);
            this.groupBox1.Controls.Add(this.txtMaPN);
            this.groupBox1.Controls.Add(this.txtDonvitinh);
            this.groupBox1.Controls.Add(this.txtTrangThai);
            this.groupBox1.Controls.Add(this.txtSoLuong);
            this.groupBox1.Controls.Add(this.txtTenSP);
            this.groupBox1.Controls.Add(this.labMaPN);
            this.groupBox1.Controls.Add(this.labDonVT);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labSoLuong);
            this.groupBox1.Controls.Add(this.labTenSP);
            this.groupBox1.Controls.Add(this.labMaSP);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(998, 178);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi Tiết Phiếu Nhập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(448, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Trạng Thái";
            // 
            // FormChiTietPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 508);
            this.Controls.Add(this.panel1);
            this.Name = "FormChiTietPhieuNhap";
            this.Text = "FormChiTietPhieuNhap";
            this.Load += new System.EventHandler(this.FormChiTietPhieuNhap_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChitietPN)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labTongTien;
        private System.Windows.Forms.Label labThanhTien;
        private System.Windows.Forms.ComboBox cboMasp;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnChinhSua;
        private System.Windows.Forms.TextBox txtMaPN;
        private System.Windows.Forms.TextBox txtDonvitinh;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.DataGridView dgvChitietPN;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label labMaPN;
        private System.Windows.Forms.Label labDonVT;
        private System.Windows.Forms.Label labSoLuong;
        private System.Windows.Forms.Label labTenSP;
        private System.Windows.Forms.Label labMaSP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
    }
}