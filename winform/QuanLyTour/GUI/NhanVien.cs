using QuanLyTour.BUS;
using QuanLyTour.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTour.GUI
{
    public partial class NhanVien : Form
    {
        DoanBUS doan;
        public bool clicked = false;
        public NhanVien()
        {
            InitializeComponent();
        }
        public NhanVien(DoanBUS doan)
        {
            InitializeComponent();
            this.doan = doan;
        }
        private void NhanVien_Load(object sender, EventArgs e)
        {
            grid_dsNhanVien.DataSource = null;
            grid_dsNhanVien.DataSource = NhanVienDAO.getNhanVienKhongCoDoan(this.doan);

            grid_dsNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid_dsNhanVien.Columns["manhanvien"].HeaderText = "Mã nhân viên";
            grid_dsNhanVien.Columns["tennhanvien"].HeaderText = "Họ tên";
            grid_dsNhanVien.Columns["sdt"].HeaderText = "Số điện thoại";
            grid_dsNhanVien.Columns["gioitinh"].HeaderText = "Giới tính";
            grid_dsNhanVien.Columns["cmnd"].HeaderText = "CMND";
            grid_dsNhanVien.Columns["diachi"].HeaderText = "Địa chỉ";
            grid_dsNhanVien.Columns["chucvu"].HeaderText = "Chức vụ";

            grid_dsNhanVien.ClearSelection();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            clicked = true;
            this.Close();
        }
    }
}
