namespace QuanLyTour.GUI
{
    partial class Gia
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
            this.grid_gia = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grid_gia)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_gia
            // 
            this.grid_gia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_gia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_gia.Location = new System.Drawing.Point(0, 0);
            this.grid_gia.Name = "grid_gia";
            this.grid_gia.Size = new System.Drawing.Size(800, 450);
            this.grid_gia.TabIndex = 0;
            // 
            // Gia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grid_gia);
            this.Name = "Gia";
            this.Text = "Gia";
            this.Load += new System.EventHandler(this.Gia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_gia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid_gia;
    }
}