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
    public partial class KhachHang : Form
    {
        DoanBUS doan;
        public bool clicked = false;
        public KhachHang()
        {
            InitializeComponent();
        }
        public KhachHang(BUS.DoanBUS doan)
        {
            InitializeComponent();
            this.doan = doan;
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            grid_dsKhachHang.DataSource = null;
            grid_dsKhachHang.DataSource = KhachHangDAO.getKhachHangKhongCoDoan(this.doan);
            grid_dsKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid_dsKhachHang.Columns["doan"].Visible = false;

            grid_dsKhachHang.Columns["makhachhang"].HeaderText = "Mã khách hàng";
            grid_dsKhachHang.Columns["tenkhachhang"].HeaderText = "Họ tên";
            grid_dsKhachHang.Columns["sdt"].HeaderText = "Số điện thoại";
            grid_dsKhachHang.Columns["gioitinh"].HeaderText = "Giới tính";
            grid_dsKhachHang.Columns["cmnd"].HeaderText = "CMND";
            grid_dsKhachHang.Columns["diachi"].HeaderText = "Địa chỉ";
            grid_dsKhachHang.ClearSelection();

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            clicked = true;
            this.Close();
        }
    }
}
