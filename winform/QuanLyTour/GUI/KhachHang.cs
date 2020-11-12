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
            grid_dsKhachHang.DataSource = BUS.KhachHangBUS.getKhachHangKhongCoDoan(this.doan);
            grid_dsKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid_dsKhachHang.Columns["doan"].Visible = false;
            grid_dsKhachHang.Columns["quoctich"].Visible = false;

            grid_dsKhachHang.ClearSelection();

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            clicked = true;
            this.Close();
        }
    }
}
