namespace winform
{
    partial class Main
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
            this.dataGridViewGia = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.timePickerKetThuc = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.timePickerBatDau = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbLoaiTour = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTenTour = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMaTour = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedList = new System.Windows.Forms.CheckedListBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dataGridViewTour = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGia)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTour)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(385, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 426);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewGia);
            this.groupBox1.Location = new System.Drawing.Point(3, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 207);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lịch sử giá";
            // 
            // dataGridViewGia
            // 
            this.dataGridViewGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGia.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewGia.Name = "dataGridViewGia";
            this.dataGridViewGia.Size = new System.Drawing.Size(351, 188);
            this.dataGridViewGia.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.timePickerKetThuc);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Location = new System.Drawing.Point(3, 174);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(360, 36);
            this.panel7.TabIndex = 5;
            // 
            // timePickerKetThuc
            // 
            this.timePickerKetThuc.Location = new System.Drawing.Point(108, 8);
            this.timePickerKetThuc.Name = "timePickerKetThuc";
            this.timePickerKetThuc.Size = new System.Drawing.Size(249, 20);
            this.timePickerKetThuc.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ngày kết thúc";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.timePickerBatDau);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(3, 140);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(360, 36);
            this.panel6.TabIndex = 4;
            // 
            // timePickerBatDau
            // 
            this.timePickerBatDau.Location = new System.Drawing.Point(108, 8);
            this.timePickerBatDau.Name = "timePickerBatDau";
            this.timePickerBatDau.Size = new System.Drawing.Size(249, 20);
            this.timePickerBatDau.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Bắt đầu";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtGia);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(3, 106);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(360, 36);
            this.panel5.TabIndex = 3;
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(108, 8);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(249, 20);
            this.txtGia.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Giá";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbLoaiTour);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(3, 71);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(360, 36);
            this.panel4.TabIndex = 3;
            // 
            // cbLoaiTour
            // 
            this.cbLoaiTour.FormattingEnabled = true;
            this.cbLoaiTour.Location = new System.Drawing.Point(108, 8);
            this.cbLoaiTour.Name = "cbLoaiTour";
            this.cbLoaiTour.Size = new System.Drawing.Size(249, 21);
            this.cbLoaiTour.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Loại tour";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtTenTour);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(3, 37);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 36);
            this.panel3.TabIndex = 2;
            // 
            // txtTenTour
            // 
            this.txtTenTour.Location = new System.Drawing.Point(108, 8);
            this.txtTenTour.Name = "txtTenTour";
            this.txtTenTour.Size = new System.Drawing.Size(249, 20);
            this.txtTenTour.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên tour";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMaTour);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 36);
            this.panel2.TabIndex = 0;
            // 
            // txtMaTour
            // 
            this.txtMaTour.Location = new System.Drawing.Point(108, 8);
            this.txtMaTour.Name = "txtMaTour";
            this.txtMaTour.Size = new System.Drawing.Size(249, 20);
            this.txtMaTour.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã tour";
            // 
            // checkedList
            // 
            this.checkedList.FormattingEnabled = true;
            this.checkedList.Location = new System.Drawing.Point(754, 128);
            this.checkedList.Name = "checkedList";
            this.checkedList.Size = new System.Drawing.Size(153, 304);
            this.checkedList.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnXoa);
            this.panel8.Controls.Add(this.btnSua);
            this.panel8.Controls.Add(this.btnThem);
            this.panel8.Location = new System.Drawing.Point(754, 12);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(153, 107);
            this.panel8.TabIndex = 3;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(3, 77);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(147, 23);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(3, 43);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(147, 23);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(3, 9);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(147, 23);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dataGridViewTour);
            this.panel9.Location = new System.Drawing.Point(13, 12);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(369, 420);
            this.panel9.TabIndex = 4;
            // 
            // dataGridViewTour
            // 
            this.dataGridViewTour.AllowUserToAddRows = false;
            this.dataGridViewTour.AllowUserToDeleteRows = false;
            this.dataGridViewTour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTour.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTour.Name = "dataGridViewTour";
            this.dataGridViewTour.ReadOnly = true;
            this.dataGridViewTour.Size = new System.Drawing.Size(369, 420);
            this.dataGridViewTour.TabIndex = 0;
            this.dataGridViewTour.SelectionChanged += new System.EventHandler(this.dataGridViewTour_SelectionChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 449);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.checkedList);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGia)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbLoaiTour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTenTour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMaTour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker timePickerBatDau;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewGia;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DateTimePicker timePickerKetThuc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox checkedList;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dataGridViewTour;
    }
}