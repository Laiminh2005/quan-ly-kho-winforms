namespace BAOCAOCUOIKY
{
    partial class PhieuNhapXuat
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSpham = new System.Windows.Forms.Button();
            this.btnPXH = new System.Windows.Forms.Button();
            this.btnPNH = new System.Windows.Forms.Button();
            this.labTenNV = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.ptbAvatar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(232, 91);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 506);
            this.panel2.TabIndex = 8;
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
            this.panel1.Location = new System.Drawing.Point(10, 91);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 506);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSpham);
            this.groupBox1.Controls.Add(this.btnPXH);
            this.groupBox1.Controls.Add(this.btnPNH);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 255);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(217, 251);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnSpham
            // 
            this.btnSpham.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSpham.Location = new System.Drawing.Point(26, 187);
            this.btnSpham.Name = "btnSpham";
            this.btnSpham.Size = new System.Drawing.Size(165, 53);
            this.btnSpham.TabIndex = 1;
            this.btnSpham.Text = "Quản Lý Sản Phẩm";
            this.btnSpham.UseVisualStyleBackColor = false;
            this.btnSpham.Click += new System.EventHandler(this.btnSpham_Click);
            // 
            // btnPXH
            // 
            this.btnPXH.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPXH.Location = new System.Drawing.Point(26, 115);
            this.btnPXH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPXH.Name = "btnPXH";
            this.btnPXH.Size = new System.Drawing.Size(165, 53);
            this.btnPXH.TabIndex = 0;
            this.btnPXH.Text = "Quản Lý Phiếu Xuất";
            this.btnPXH.UseVisualStyleBackColor = false;
            this.btnPXH.Click += new System.EventHandler(this.btnPXH_Click);
            // 
            // btnPNH
            // 
            this.btnPNH.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPNH.Location = new System.Drawing.Point(26, 46);
            this.btnPNH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPNH.Name = "btnPNH";
            this.btnPNH.Size = new System.Drawing.Size(165, 53);
            this.btnPNH.TabIndex = 0;
            this.btnPNH.Text = "Quản Lý Phiếu Nhập";
            this.btnPNH.UseVisualStyleBackColor = false;
            this.btnPNH.Click += new System.EventHandler(this.btnPNH_Click);
            // 
            // labTenNV
            // 
            this.labTenNV.AutoSize = true;
            this.labTenNV.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTenNV.Location = new System.Drawing.Point(68, 147);
            this.labTenNV.Name = "labTenNV";
            this.labTenNV.Size = new System.Drawing.Size(84, 19);
            this.labTenNV.TabIndex = 1;
            this.labTenNV.Text = "Nhân Viên";
            // 
            // panelTop
            // 
            this.panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTop.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelTop.Controls.Add(this.btnDangXuat);
            this.panelTop.Location = new System.Drawing.Point(10, 1);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1004, 86);
            this.panelTop.TabIndex = 6;
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
            this.btnDangXuat.TabIndex = 0;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // ptbAvatar
            // 
            this.ptbAvatar.Image = global::BAOCAOCUOIKY.Properties.Resources.icons8_staff_100;
            this.ptbAvatar.InitialImage = null;
            this.ptbAvatar.Location = new System.Drawing.Point(41, 18);
            this.ptbAvatar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptbAvatar.Name = "ptbAvatar";
            this.ptbAvatar.Size = new System.Drawing.Size(141, 115);
            this.ptbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbAvatar.TabIndex = 0;
            this.ptbAvatar.TabStop = false;
            this.ptbAvatar.Click += new System.EventHandler(this.ptbAvatar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 42F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Location = new System.Drawing.Point(6, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(785, 78);
            this.label1.TabIndex = 1;
            this.label1.Text = "XIN CHÀO NHÂN VIÊN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PhieuNhapXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 608);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.Name = "PhieuNhapXuat";
            this.Text = "PhieuNhapXuat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PhieuNhapXuat_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPXH;
        private System.Windows.Forms.Button btnPNH;
        private System.Windows.Forms.Label labTenNV;
        private System.Windows.Forms.PictureBox ptbAvatar;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnSpham;
        private System.Windows.Forms.Label label1;
    }
}