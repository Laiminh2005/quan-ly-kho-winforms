namespace BAOCAOCUOIKY
{
    partial class FormRestore
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
            this.btnBackUpRT = new System.Windows.Forms.Button();
            this.btnBrowseRT = new System.Windows.Forms.Button();
            this.txtDuongdanRT = new System.Windows.Forms.TextBox();
            this.lblDuongDan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBackUpRT
            // 
            this.btnBackUpRT.BackColor = System.Drawing.Color.Salmon;
            this.btnBackUpRT.Enabled = false;
            this.btnBackUpRT.Location = new System.Drawing.Point(482, 85);
            this.btnBackUpRT.Name = "btnBackUpRT";
            this.btnBackUpRT.Size = new System.Drawing.Size(117, 35);
            this.btnBackUpRT.TabIndex = 7;
            this.btnBackUpRT.Text = "Restore";
            this.btnBackUpRT.UseVisualStyleBackColor = false;
            this.btnBackUpRT.Click += new System.EventHandler(this.btnBackUpRT_Click);
            // 
            // btnBrowseRT
            // 
            this.btnBrowseRT.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnBrowseRT.Location = new System.Drawing.Point(633, 35);
            this.btnBrowseRT.Name = "btnBrowseRT";
            this.btnBrowseRT.Size = new System.Drawing.Size(75, 30);
            this.btnBrowseRT.TabIndex = 6;
            this.btnBrowseRT.Text = "Browse";
            this.btnBrowseRT.UseVisualStyleBackColor = false;
            this.btnBrowseRT.Click += new System.EventHandler(this.btnBrowseRT_Click);
            // 
            // txtDuongdanRT
            // 
            this.txtDuongdanRT.BackColor = System.Drawing.Color.White;
            this.txtDuongdanRT.Enabled = false;
            this.txtDuongdanRT.Location = new System.Drawing.Point(262, 35);
            this.txtDuongdanRT.Multiline = true;
            this.txtDuongdanRT.Name = "txtDuongdanRT";
            this.txtDuongdanRT.Size = new System.Drawing.Size(337, 30);
            this.txtDuongdanRT.TabIndex = 5;
            // 
            // lblDuongDan
            // 
            this.lblDuongDan.AutoSize = true;
            this.lblDuongDan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuongDan.Location = new System.Drawing.Point(23, 40);
            this.lblDuongDan.Name = "lblDuongDan";
            this.lblDuongDan.Size = new System.Drawing.Size(203, 25);
            this.lblDuongDan.TabIndex = 4;
            this.lblDuongDan.Text = "Đường Dẫn Lưu File";
            // 
            // FormRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 155);
            this.Controls.Add(this.btnBackUpRT);
            this.Controls.Add(this.btnBrowseRT);
            this.Controls.Add(this.txtDuongdanRT);
            this.Controls.Add(this.lblDuongDan);
            this.Name = "FormRestore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRestore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBackUpRT;
        private System.Windows.Forms.Button btnBrowseRT;
        private System.Windows.Forms.TextBox txtDuongdanRT;
        private System.Windows.Forms.Label lblDuongDan;
    }
}