using QuanLyTour.BUS;
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
            grid_dsNhanVien.DataSource = this.doan.getNhanVienKhongCoDoan();
            grid_dsNhanVien.ClearSelection();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            clicked = true;
            this.Close();
        }
    }
}
