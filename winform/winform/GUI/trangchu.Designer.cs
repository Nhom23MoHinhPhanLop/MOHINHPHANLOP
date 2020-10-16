namespace winform.GUI
{
    partial class trangchu
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelLoai = new System.Windows.Forms.FlowLayoutPanel();
            this.btnInsertLoai = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewDiadiem = new System.Windows.Forms.DataGridView();
            this.btnThemDiadiem = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gridTour = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.datNgaytrove = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataNgaykhoihanh = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbLoaitour = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTentour = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtMatour = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dateNgayketthuc = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dateNgaybatdau = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listDiadiem = new System.Windows.Forms.CheckedListBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnThemtour = new System.Windows.Forms.Button();
            this.btnSuatour = new System.Windows.Forms.Button();
            this.btnXoatour = new System.Windows.Forms.Button();
            this.btnChitietgia = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiadiem)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTour)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(704, 378);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelLoai);
            this.tabPage1.Controls.Add(this.btnInsertLoai);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(696, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Quản lý loại";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelLoai
            // 
            this.panelLoai.AutoScroll = true;
            this.panelLoai.Location = new System.Drawing.Point(0, 84);
            this.panelLoai.Name = "panelLoai";
            this.panelLoai.Size = new System.Drawing.Size(696, 268);
            this.panelLoai.TabIndex = 3;
            // 
            // btnInsertLoai
            // 
            this.btnInsertLoai.Location = new System.Drawing.Point(0, 54);
            this.btnInsertLoai.Name = "btnInsertLoai";
            this.btnInsertLoai.Size = new System.Drawing.Size(75, 23);
            this.btnInsertLoai.TabIndex = 2;
            this.btnInsertLoai.Text = "Thêm";
            this.btnInsertLoai.UseVisualStyleBackColor = true;
            this.btnInsertLoai.Click += new System.EventHandler(this.btnInsertLoai_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 48);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý loại tour";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewDiadiem);
            this.tabPage2.Controls.Add(this.btnThemDiadiem);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(696, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quản lý địa điểm";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDiadiem
            // 
            this.dataGridViewDiadiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDiadiem.Location = new System.Drawing.Point(3, 32);
            this.dataGridViewDiadiem.Name = "dataGridViewDiadiem";
            this.dataGridViewDiadiem.Size = new System.Drawing.Size(690, 317);
            this.dataGridViewDiadiem.TabIndex = 1;
            // 
            // btnThemDiadiem
            // 
            this.btnThemDiadiem.Location = new System.Drawing.Point(3, 3);
            this.btnThemDiadiem.Name = "btnThemDiadiem";
            this.btnThemDiadiem.Size = new System.Drawing.Size(75, 23);
            this.btnThemDiadiem.TabIndex = 0;
            this.btnThemDiadiem.Text = "Thêm";
            this.btnThemDiadiem.UseVisualStyleBackColor = true;
            this.btnThemDiadiem.Click += new System.EventHandler(this.btnThemDiadiem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel10);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.panel7);
            this.tabPage3.Controls.Add(this.panel8);
            this.tabPage3.Controls.Add(this.panel9);
            this.tabPage3.Controls.Add(this.panel5);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Controls.Add(this.panel6);
            this.tabPage3.Controls.Add(this.gridTour);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(696, 352);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Quản lý tour";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gridTour
            // 
            this.gridTour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTour.Location = new System.Drawing.Point(6, 6);
            this.gridTour.Name = "gridTour";
            this.gridTour.Size = new System.Drawing.Size(277, 340);
            this.gridTour.TabIndex = 0;
            this.gridTour.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTour_CellClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.datNgaytrove);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(286, 142);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(278, 34);
            this.panel5.TabIndex = 9;
            // 
            // datNgaytrove
            // 
            this.datNgaytrove.Location = new System.Drawing.Point(86, 11);
            this.datNgaytrove.Name = "datNgaytrove";
            this.datNgaytrove.Size = new System.Drawing.Size(180, 20);
            this.datNgaytrove.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ngày kết thúc";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataNgaykhoihanh);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(286, 108);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(278, 34);
            this.panel3.TabIndex = 7;
            // 
            // dataNgaykhoihanh
            // 
            this.dataNgaykhoihanh.Location = new System.Drawing.Point(86, 10);
            this.dataNgaykhoihanh.Name = "dataNgaykhoihanh";
            this.dataNgaykhoihanh.Size = new System.Drawing.Size(180, 20);
            this.dataNgaykhoihanh.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày khởi hành";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbLoaitour);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(286, 74);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(278, 34);
            this.panel4.TabIndex = 8;
            // 
            // cbLoaitour
            // 
            this.cbLoaitour.FormattingEnabled = true;
            this.cbLoaitour.Location = new System.Drawing.Point(86, 7);
            this.cbLoaitour.Name = "cbLoaitour";
            this.cbLoaitour.Size = new System.Drawing.Size(180, 21);
            this.cbLoaitour.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Loại";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTentour);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(286, 40);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(278, 34);
            this.panel2.TabIndex = 6;
            // 
            // txtTentour
            // 
            this.txtTentour.Location = new System.Drawing.Point(86, 7);
            this.txtTentour.Name = "txtTentour";
            this.txtTentour.Size = new System.Drawing.Size(180, 20);
            this.txtTentour.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên tour";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtMatour);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(286, 6);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(278, 34);
            this.panel6.TabIndex = 5;
            // 
            // txtMatour
            // 
            this.txtMatour.Location = new System.Drawing.Point(86, 7);
            this.txtMatour.Name = "txtMatour";
            this.txtMatour.Size = new System.Drawing.Size(180, 20);
            this.txtMatour.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mã tour";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dateNgayketthuc);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(286, 244);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(278, 34);
            this.panel7.TabIndex = 12;
            // 
            // dateNgayketthuc
            // 
            this.dateNgayketthuc.Location = new System.Drawing.Point(86, 4);
            this.dateNgayketthuc.Name = "dateNgayketthuc";
            this.dateNgayketthuc.Size = new System.Drawing.Size(180, 20);
            this.dateNgayketthuc.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ngày kết thúc";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnChitietgia);
            this.panel8.Controls.Add(this.txtGia);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Location = new System.Drawing.Point(286, 176);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(278, 34);
            this.panel8.TabIndex = 10;
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(86, 7);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(99, 20);
            this.txtGia.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Giá";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dateNgaybatdau);
            this.panel9.Controls.Add(this.label9);
            this.panel9.Location = new System.Drawing.Point(286, 210);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(278, 34);
            this.panel9.TabIndex = 11;
            // 
            // dateNgaybatdau
            // 
            this.dateNgaybatdau.Location = new System.Drawing.Point(86, 4);
            this.dateNgaybatdau.Name = "dateNgaybatdau";
            this.dateNgaybatdau.Size = new System.Drawing.Size(180, 20);
            this.dateNgaybatdau.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Ngày bắt đầu";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listDiadiem);
            this.groupBox1.Location = new System.Drawing.Point(567, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 272);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // listDiadiem
            // 
            this.listDiadiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDiadiem.FormattingEnabled = true;
            this.listDiadiem.Location = new System.Drawing.Point(3, 16);
            this.listDiadiem.Name = "listDiadiem";
            this.listDiadiem.Size = new System.Drawing.Size(116, 253);
            this.listDiadiem.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnXoatour);
            this.panel10.Controls.Add(this.btnSuatour);
            this.panel10.Controls.Add(this.btnThemtour);
            this.panel10.Location = new System.Drawing.Point(286, 284);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(403, 62);
            this.panel10.TabIndex = 14;
            // 
            // btnThemtour
            // 
            this.btnThemtour.Location = new System.Drawing.Point(6, 13);
            this.btnThemtour.Name = "btnThemtour";
            this.btnThemtour.Size = new System.Drawing.Size(75, 23);
            this.btnThemtour.TabIndex = 0;
            this.btnThemtour.Text = "Thêm";
            this.btnThemtour.UseVisualStyleBackColor = true;
            // 
            // btnSuatour
            // 
            this.btnSuatour.Location = new System.Drawing.Point(118, 13);
            this.btnSuatour.Name = "btnSuatour";
            this.btnSuatour.Size = new System.Drawing.Size(75, 23);
            this.btnSuatour.TabIndex = 1;
            this.btnSuatour.Text = "Sửa";
            this.btnSuatour.UseVisualStyleBackColor = true;
            // 
            // btnXoatour
            // 
            this.btnXoatour.Location = new System.Drawing.Point(233, 13);
            this.btnXoatour.Name = "btnXoatour";
            this.btnXoatour.Size = new System.Drawing.Size(75, 23);
            this.btnXoatour.TabIndex = 2;
            this.btnXoatour.Text = "Xóa";
            this.btnXoatour.UseVisualStyleBackColor = true;
            // 
            // btnChitietgia
            // 
            this.btnChitietgia.Location = new System.Drawing.Point(191, 5);
            this.btnChitietgia.Name = "btnChitietgia";
            this.btnChitietgia.Size = new System.Drawing.Size(75, 23);
            this.btnChitietgia.TabIndex = 2;
            this.btnChitietgia.Text = "Xem lịch sử";
            this.btnChitietgia.UseVisualStyleBackColor = true;
            // 
            // trangchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 402);
            this.Controls.Add(this.tabControl1);
            this.Name = "trangchu";
            this.Text = "trangchu";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiadiem)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTour)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnInsertLoai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.FlowLayoutPanel panelLoai;
        private System.Windows.Forms.Button btnThemDiadiem;
        private System.Windows.Forms.DataGridView dataGridViewDiadiem;
        private System.Windows.Forms.DataGridView gridTour;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DateTimePicker datNgaytrove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dataNgaykhoihanh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbLoaitour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTentour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtMatour;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DateTimePicker dateNgayketthuc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DateTimePicker dateNgaybatdau;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnXoatour;
        private System.Windows.Forms.Button btnSuatour;
        private System.Windows.Forms.Button btnThemtour;
        private System.Windows.Forms.CheckedListBox listDiadiem;
        private System.Windows.Forms.Button btnChitietgia;
    }
}