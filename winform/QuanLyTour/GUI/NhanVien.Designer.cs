namespace QuanLyTour.GUI
{
    partial class NhanVien
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
            this.btn_them = new System.Windows.Forms.Button();
            this.grid_dsNhanVien = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grid_dsNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(13, 397);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(126, 41);
            this.btn_them.TabIndex = 3;
            this.btn_them.Text = "Thêm nhân viên";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // grid_dsNhanVien
            // 
            this.grid_dsNhanVien.AllowUserToAddRows = false;
            this.grid_dsNhanVien.AllowUserToDeleteRows = false;
            this.grid_dsNhanVien.AllowUserToResizeColumns = false;
            this.grid_dsNhanVien.AllowUserToResizeRows = false;
            this.grid_dsNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_dsNhanVien.Location = new System.Drawing.Point(12, 12);
            this.grid_dsNhanVien.Name = "grid_dsNhanVien";
            this.grid_dsNhanVien.ReadOnly = true;
            this.grid_dsNhanVien.RowHeadersVisible = false;
            this.grid_dsNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_dsNhanVien.Size = new System.Drawing.Size(776, 378);
            this.grid_dsNhanVien.TabIndex = 2;
            // 
            // NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.grid_dsNhanVien);
            this.Name = "NhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NhanVien";
            this.Load += new System.EventHandler(this.NhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_dsNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_them;
        public System.Windows.Forms.DataGridView grid_dsNhanVien;
    }
}