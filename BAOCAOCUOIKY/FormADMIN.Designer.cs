namespace BAOCAOCUOIKY
{
    partial class FormADMIN
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLSUxuat = new System.Windows.Forms.Button();
            this.btnQlySanPham = new System.Windows.Forms.Button();
            this.btnQLNV = new System.Windows.Forms.Button();
            this.btnFormDuyetPhieu = new System.Windows.Forms.Button();
            this.btnPNH = new System.Windows.Forms.Button();
            this.labTenNV = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ptbAvatar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.labTenNV);
            this.panel1.Controls.Add(this.ptbAvatar);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(10, 96);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 507);
            this.panel1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLSUxuat);
            this.groupBox1.Controls.Add(this.btnQlySanPham);
            this.groupBox1.Controls.Add(this.btnQLNV);
            this.groupBox1.Controls.Add(this.btnFormDuyetPhieu);
            this.groupBox1.Controls.Add(this.btnPNH);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 186);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(217, 319);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnLSUxuat
            // 
            this.btnLSUxuat.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLSUxuat.Location = new System.Drawing.Point(26, 257);
            this.btnLSUxuat.Name = "btnLSUxuat";
            this.btnLSUxuat.Size = new System.Drawing.Size(165, 53);
            this.btnLSUxuat.TabIndex = 4;
            this.btnLSUxuat.Text = "Lịch Sử Xuất Hàng";
            this.btnLSUxuat.UseVisualStyleBackColor = false;
            this.btnLSUxuat.Click += new System.EventHandler(this.btnLSUxuat_Click);
            // 
            // btnQlySanPham
            // 
            this.btnQlySanPham.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnQlySanPham.Location = new System.Drawing.Point(26, 198);
            this.btnQlySanPham.Name = "btnQlySanPham";
            this.btnQlySanPham.Size = new System.Drawing.Size(165, 53);
            this.btnQlySanPham.TabIndex = 3;
            this.btnQlySanPham.Text = "Quản Lý Sản Phẩm";
            this.btnQlySanPham.UseVisualStyleBackColor = false;
            this.btnQlySanPham.Click += new System.EventHandler(this.btnQlySanPham_Click);
            // 
            // btnQLNV
            // 
            this.btnQLNV.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnQLNV.Location = new System.Drawing.Point(26, 139);
            this.btnQLNV.Name = "btnQLNV";
            this.btnQLNV.Size = new System.Drawing.Size(165, 53);
            this.btnQLNV.TabIndex = 2;
            this.btnQLNV.Text = "Quản Lý Nhân Viên";
            this.btnQLNV.UseVisualStyleBackColor = false;
            this.btnQLNV.Click += new System.EventHandler(this.btnQLNV_Click);
            // 
            // btnFormDuyetPhieu
            // 
            this.btnFormDuyetPhieu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFormDuyetPhieu.Location = new System.Drawing.Point(26, 81);
            this.btnFormDuyetPhieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFormDuyetPhieu.Name = "btnFormDuyetPhieu";
            this.btnFormDuyetPhieu.Size = new System.Drawing.Size(165, 53);
            this.btnFormDuyetPhieu.TabIndex = 1;
            this.btnFormDuyetPhieu.Text = "Duyệt Phiếu";
            this.btnFormDuyetPhieu.UseVisualStyleBackColor = false;
            this.btnFormDuyetPhieu.Click += new System.EventHandler(this.btnFormDuyetPhieu_Click);
            // 
            // btnPNH
            // 
            this.btnPNH.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPNH.Location = new System.Drawing.Point(26, 24);
            this.btnPNH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPNH.Name = "btnPNH";
            this.btnPNH.Size = new System.Drawing.Size(165, 53);
            this.btnPNH.TabIndex = 0;
            this.btnPNH.Text = "Doanh Thu";
            this.btnPNH.UseVisualStyleBackColor = false;
            this.btnPNH.Click += new System.EventHandler(this.btnPNH_Click);
            // 
            // labTenNV
            // 
            this.labTenNV.AutoSize = true;
            this.labTenNV.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTenNV.Location = new System.Drawing.Point(81, 147);
            this.labTenNV.Name = "labTenNV";
            this.labTenNV.Size = new System.Drawing.Size(66, 19);
            this.labTenNV.TabIndex = 1;
            this.labTenNV.Text = "ADMIN";
            // 
            // panelTop
            // 
            this.panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTop.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelTop.Controls.Add(this.btnDangXuat);
            this.panelTop.Location = new System.Drawing.Point(10, 6);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1004, 86);
            this.panelTop.TabIndex = 9;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDangXuat.BackColor = System.Drawing.Color.Red;
            this.btnDangXuat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDangXuat.Location = new System.Drawing.Point(841, 22);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(133, 42);
            this.btnDangXuat.TabIndex = 5;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(232, 96);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 507);
            this.panel2.TabIndex = 11;
            // 
            // ptbAvatar
            // 
            this.ptbAvatar.Image = global::BAOCAOCUOIKY.Properties.Resources.icons8_manager_96;
            this.ptbAvatar.InitialImage = null;
            this.ptbAvatar.Location = new System.Drawing.Point(41, 16);
            this.ptbAvatar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptbAvatar.Name = "ptbAvatar";
            this.ptbAvatar.Size = new System.Drawing.Size(141, 117);
            this.ptbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbAvatar.TabIndex = 0;
            this.ptbAvatar.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 42F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Location = new System.Drawing.Point(36, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(697, 78);
            this.label1.TabIndex = 0;
            this.label1.Text = "XIN CHÀO QUẢN LÝ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormADMIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 610);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.Name = "FormADMIN";
            this.Text = "FormADMIN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFormDuyetPhieu;
        private System.Windows.Forms.Button btnPNH;
        private System.Windows.Forms.Label labTenNV;
        private System.Windows.Forms.PictureBox ptbAvatar;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnLSUxuat;
        private System.Windows.Forms.Button btnQlySanPham;
        private System.Windows.Forms.Button btnQLNV;
        private System.Windows.Forms.Label label1;
    }
}