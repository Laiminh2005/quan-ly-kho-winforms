namespace BAOCAOCUOIKY
{
    partial class FormBackUp
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
            this.lblDuongDan = new System.Windows.Forms.Label();
            this.txtDuongdan = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnBackUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDuongDan
            // 
            this.lblDuongDan.AutoSize = true;
            this.lblDuongDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuongDan.Location = new System.Drawing.Point(3, 46);
            this.lblDuongDan.Name = "lblDuongDan";
            this.lblDuongDan.Size = new System.Drawing.Size(203, 25);
            this.lblDuongDan.TabIndex = 0;
            this.lblDuongDan.Text = "Đường Dẫn Lưu File";
            // 
            // txtDuongdan
            // 
            this.txtDuongdan.BackColor = System.Drawing.Color.White;
            this.txtDuongdan.Enabled = false;
            this.txtDuongdan.Location = new System.Drawing.Point(242, 41);
            this.txtDuongdan.Multiline = true;
            this.txtDuongdan.Name = "txtDuongdan";
            this.txtDuongdan.Size = new System.Drawing.Size(337, 30);
            this.txtDuongdan.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnBrowse.Location = new System.Drawing.Point(613, 41);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 30);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnBackUp
            // 
            this.btnBackUp.BackColor = System.Drawing.Color.Salmon;
            this.btnBackUp.Enabled = false;
            this.btnBackUp.Location = new System.Drawing.Point(462, 91);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(117, 35);
            this.btnBackUp.TabIndex = 3;
            this.btnBackUp.Text = "BackUp";
            this.btnBackUp.UseVisualStyleBackColor = false;
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // FormBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 155);
            this.Controls.Add(this.btnBackUp);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDuongdan);
            this.Controls.Add(this.lblDuongDan);
            this.Name = "FormBackUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBackUp";
            this.Load += new System.EventHandler(this.FormBackUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDuongDan;
        private System.Windows.Forms.TextBox txtDuongdan;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnBackUp;
    }
}