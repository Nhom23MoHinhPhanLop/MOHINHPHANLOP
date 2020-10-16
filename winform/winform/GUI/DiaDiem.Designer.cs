namespace winform.GUI
{
    partial class DiaDiem
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
            this.checkedListChiTiet = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // checkedListChiTiet
            // 
            this.checkedListChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListChiTiet.FormattingEnabled = true;
            this.checkedListChiTiet.Location = new System.Drawing.Point(0, 0);
            this.checkedListChiTiet.Name = "checkedListChiTiet";
            this.checkedListChiTiet.Size = new System.Drawing.Size(366, 141);
            this.checkedListChiTiet.TabIndex = 0;
            // 
            // DiaDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 141);
            this.Controls.Add(this.checkedListChiTiet);
            this.Name = "DiaDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DiaDiem";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListChiTiet;
    }
}