namespace QuanLyTour.GUI
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_xoaTour = new System.Windows.Forms.Button();
            this.btn_capnhatTour = new System.Windows.Forms.Button();
            this.btn_themTour = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkedListBox_dsDiaDiem = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grid_dsGia = new System.Windows.Forms.DataGridView();
            this.panel14 = new System.Windows.Forms.Panel();
            this.datetime_ketthucGia = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.datetime_batdauGia = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txt_maTour = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_tenTour = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBox_loaiTour = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grid_dsTour = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_Gia = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_dsGia)).BeginInit();
            this.panel14.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel15.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_dsTour)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Gia)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(975, 482);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_xoaTour);
            this.tabPage1.Controls.Add(this.btn_capnhatTour);
            this.tabPage1.Controls.Add(this.btn_themTour);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.grid_dsTour);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(967, 456);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Quản lý tour";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_xoaTour
            // 
            this.btn_xoaTour.Location = new System.Drawing.Point(559, 412);
            this.btn_xoaTour.Name = "btn_xoaTour";
            this.btn_xoaTour.Size = new System.Drawing.Size(87, 33);
            this.btn_xoaTour.TabIndex = 26;
            this.btn_xoaTour.Text = "Xóa";
            this.btn_xoaTour.UseVisualStyleBackColor = true;
            // 
            // btn_capnhatTour
            // 
            this.btn_capnhatTour.Location = new System.Drawing.Point(467, 412);
            this.btn_capnhatTour.Name = "btn_capnhatTour";
            this.btn_capnhatTour.Size = new System.Drawing.Size(87, 33);
            this.btn_capnhatTour.TabIndex = 25;
            this.btn_capnhatTour.Text = "Cập nhật";
            this.btn_capnhatTour.UseVisualStyleBackColor = true;
            // 
            // btn_themTour
            // 
            this.btn_themTour.Location = new System.Drawing.Point(374, 412);
            this.btn_themTour.Name = "btn_themTour";
            this.btn_themTour.Size = new System.Drawing.Size(87, 33);
            this.btn_themTour.TabIndex = 24;
            this.btn_themTour.Text = "Thêm";
            this.btn_themTour.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkedListBox_dsDiaDiem);
            this.groupBox3.Location = new System.Drawing.Point(740, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(221, 446);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Địa điểm";
            // 
            // checkedListBox_dsDiaDiem
            // 
            this.checkedListBox_dsDiaDiem.CheckOnClick = true;
            this.checkedListBox_dsDiaDiem.FormattingEnabled = true;
            this.checkedListBox_dsDiaDiem.Location = new System.Drawing.Point(6, 15);
            this.checkedListBox_dsDiaDiem.Name = "checkedListBox_dsDiaDiem";
            this.checkedListBox_dsDiaDiem.Size = new System.Drawing.Size(209, 424);
            this.checkedListBox_dsDiaDiem.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grid_dsGia);
            this.groupBox2.Controls.Add(this.panel14);
            this.groupBox2.Controls.Add(this.panel8);
            this.groupBox2.Controls.Add(this.panel15);
            this.groupBox2.Location = new System.Drawing.Point(290, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 304);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Giá";
            // 
            // grid_dsGia
            // 
            this.grid_dsGia.AllowUserToAddRows = false;
            this.grid_dsGia.AllowUserToDeleteRows = false;
            this.grid_dsGia.AllowUserToResizeColumns = false;
            this.grid_dsGia.AllowUserToResizeRows = false;
            this.grid_dsGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_dsGia.Location = new System.Drawing.Point(3, 121);
            this.grid_dsGia.MultiSelect = false;
            this.grid_dsGia.Name = "grid_dsGia";
            this.grid_dsGia.ReadOnly = true;
            this.grid_dsGia.RowHeadersVisible = false;
            this.grid_dsGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_dsGia.Size = new System.Drawing.Size(437, 177);
            this.grid_dsGia.TabIndex = 23;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.datetime_ketthucGia);
            this.panel14.Controls.Add(this.label13);
            this.panel14.Location = new System.Drawing.Point(3, 84);
            this.panel14.Margin = new System.Windows.Forms.Padding(0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(437, 34);
            this.panel14.TabIndex = 22;
            // 
            // datetime_ketthucGia
            // 
            this.datetime_ketthucGia.CustomFormat = "hh:mm:ss dd/MM/yyyy";
            this.datetime_ketthucGia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetime_ketthucGia.Location = new System.Drawing.Point(86, 4);
            this.datetime_ketthucGia.Name = "datetime_ketthucGia";
            this.datetime_ketthucGia.Size = new System.Drawing.Size(192, 20);
            this.datetime_ketthucGia.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Ngày kết thúc";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txt_Gia);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Location = new System.Drawing.Point(3, 16);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(210, 34);
            this.panel8.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Giá hiện tại";
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.datetime_batdauGia);
            this.panel15.Controls.Add(this.label14);
            this.panel15.Location = new System.Drawing.Point(3, 50);
            this.panel15.Margin = new System.Windows.Forms.Padding(0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(437, 34);
            this.panel15.TabIndex = 21;
            // 
            // datetime_batdauGia
            // 
            this.datetime_batdauGia.CustomFormat = "hh:mm:ss dd/MM/yyyy";
            this.datetime_batdauGia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetime_batdauGia.Location = new System.Drawing.Point(86, 4);
            this.datetime_batdauGia.MinDate = new System.DateTime(2020, 10, 24, 0, 0, 0, 0);
            this.datetime_batdauGia.Name = "datetime_batdauGia";
            this.datetime_batdauGia.Size = new System.Drawing.Size(192, 20);
            this.datetime_batdauGia.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Ngày bắt đầu";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Location = new System.Drawing.Point(290, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 90);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tour";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txt_maTour);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(3, 16);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(210, 34);
            this.panel6.TabIndex = 13;
            // 
            // txt_maTour
            // 
            this.txt_maTour.Location = new System.Drawing.Point(86, 7);
            this.txt_maTour.Name = "txt_maTour";
            this.txt_maTour.Size = new System.Drawing.Size(116, 20);
            this.txt_maTour.TabIndex = 1;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_tenTour);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(437, 34);
            this.panel2.TabIndex = 14;
            // 
            // txt_tenTour
            // 
            this.txt_tenTour.Location = new System.Drawing.Point(86, 7);
            this.txt_tenTour.Name = "txt_tenTour";
            this.txt_tenTour.Size = new System.Drawing.Size(343, 20);
            this.txt_tenTour.TabIndex = 1;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.comboBox_loaiTour);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(230, 16);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(210, 34);
            this.panel4.TabIndex = 16;
            // 
            // comboBox_loaiTour
            // 
            this.comboBox_loaiTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_loaiTour.FormattingEnabled = true;
            this.comboBox_loaiTour.Location = new System.Drawing.Point(57, 7);
            this.comboBox_loaiTour.Name = "comboBox_loaiTour";
            this.comboBox_loaiTour.Size = new System.Drawing.Size(145, 21);
            this.comboBox_loaiTour.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Loại tour";
            // 
            // grid_dsTour
            // 
            this.grid_dsTour.AllowUserToAddRows = false;
            this.grid_dsTour.AllowUserToDeleteRows = false;
            this.grid_dsTour.AllowUserToResizeColumns = false;
            this.grid_dsTour.AllowUserToResizeRows = false;
            this.grid_dsTour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_dsTour.Location = new System.Drawing.Point(0, 0);
            this.grid_dsTour.MultiSelect = false;
            this.grid_dsTour.Name = "grid_dsTour";
            this.grid_dsTour.ReadOnly = true;
            this.grid_dsTour.RowHeadersVisible = false;
            this.grid_dsTour.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_dsTour.Size = new System.Drawing.Size(284, 456);
            this.grid_dsTour.TabIndex = 0;
            this.grid_dsTour.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_dsTour_CellClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(967, 456);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quản lý đoàn khách";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(476, 456);
            this.dataGridView1.TabIndex = 0;
            // 
            // txt_Gia
            // 
            this.txt_Gia.DecimalPlaces = 1;
            this.txt_Gia.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txt_Gia.InterceptArrowKeys = false;
            this.txt_Gia.Location = new System.Drawing.Point(86, 7);
            this.txt_Gia.Maximum = new decimal(new int[] {
            2147000000,
            0,
            0,
            0});
            this.txt_Gia.Name = "txt_Gia";
            this.txt_Gia.Size = new System.Drawing.Size(116, 20);
            this.txt_Gia.TabIndex = 24;
            this.txt_Gia.ThousandsSeparator = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 482);
            this.Controls.Add(this.tabControl1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_dsGia)).EndInit();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_dsTour)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Gia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView grid_dsTour;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBox_loaiTour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_tenTour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txt_maTour;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_xoaTour;
        private System.Windows.Forms.Button btn_capnhatTour;
        private System.Windows.Forms.Button btn_themTour;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox checkedListBox_dsDiaDiem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grid_dsGia;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.DateTimePicker datetime_ketthucGia;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.DateTimePicker datetime_batdauGia;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown txt_Gia;
    }
}