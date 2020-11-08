namespace QuanLyTour.GUI
{
    partial class KhachHang
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
            this.grid_dsKhachHang = new System.Windows.Forms.DataGridView();
            this.btn_them = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_dsKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_dsKhachHang
            // 
            this.grid_dsKhachHang.AllowUserToAddRows = false;
            this.grid_dsKhachHang.AllowUserToDeleteRows = false;
            this.grid_dsKhachHang.AllowUserToResizeColumns = false;
            this.grid_dsKhachHang.AllowUserToResizeRows = false;
            this.grid_dsKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_dsKhachHang.Location = new System.Drawing.Point(12, 12);
            this.grid_dsKhachHang.Name = "grid_dsKhachHang";
            this.grid_dsKhachHang.ReadOnly = true;
            this.grid_dsKhachHang.RowHeadersVisible = false;
            this.grid_dsKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_dsKhachHang.Size = new System.Drawing.Size(776, 378);
            this.grid_dsKhachHang.TabIndex = 0;
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(13, 397);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(126, 41);
            this.btn_them.TabIndex = 1;
            this.btn_them.Text = "Thêm khách hàng";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.grid_dsKhachHang);
            this.Name = "KhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KhachHang";
            this.Load += new System.EventHandler(this.KhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_dsKhachHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_them;
        public System.Windows.Forms.DataGridView grid_dsKhachHang;
    }
}