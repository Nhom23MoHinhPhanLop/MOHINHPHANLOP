namespace winform.GUI
{
    partial class itemLoaiTour
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.xoa = new System.Windows.Forms.Button();
            this.sua = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbTenloai = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbMaloai = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 46);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.xoa);
            this.panel4.Controls.Add(this.sua);
            this.panel4.Location = new System.Drawing.Point(484, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(182, 46);
            this.panel4.TabIndex = 2;
            // 
            // xoa
            // 
            this.xoa.BackColor = System.Drawing.Color.Transparent;
            this.xoa.Location = new System.Drawing.Point(98, 12);
            this.xoa.Margin = new System.Windows.Forms.Padding(0);
            this.xoa.Name = "xoa";
            this.xoa.Size = new System.Drawing.Size(75, 23);
            this.xoa.TabIndex = 1;
            this.xoa.Text = "Xóa";
            this.xoa.UseVisualStyleBackColor = false;
            this.xoa.Click += new System.EventHandler(this.xoa_Click);
            // 
            // sua
            // 
            this.sua.Location = new System.Drawing.Point(17, 12);
            this.sua.Name = "sua";
            this.sua.Size = new System.Drawing.Size(75, 23);
            this.sua.TabIndex = 0;
            this.sua.Text = "Sửa";
            this.sua.UseVisualStyleBackColor = true;
            this.sua.Click += new System.EventHandler(this.sua_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.lbTenloai);
            this.panel3.Location = new System.Drawing.Point(82, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(396, 46);
            this.panel3.TabIndex = 1;
            // 
            // lbTenloai
            // 
            this.lbTenloai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTenloai.Location = new System.Drawing.Point(0, 0);
            this.lbTenloai.Name = "lbTenloai";
            this.lbTenloai.Size = new System.Drawing.Size(396, 46);
            this.lbTenloai.TabIndex = 0;
            this.lbTenloai.Text = "Tên loại";
            this.lbTenloai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.lbMaloai);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(76, 46);
            this.panel2.TabIndex = 0;
            // 
            // lbMaloai
            // 
            this.lbMaloai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMaloai.Location = new System.Drawing.Point(0, 0);
            this.lbMaloai.Name = "lbMaloai";
            this.lbMaloai.Size = new System.Drawing.Size(76, 46);
            this.lbMaloai.TabIndex = 0;
            this.lbMaloai.Text = "Mã loại";
            this.lbMaloai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemLoaiTour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "itemLoaiTour";
            this.Size = new System.Drawing.Size(669, 46);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbTenloai;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbMaloai;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button xoa;
        private System.Windows.Forms.Button sua;
    }
}
