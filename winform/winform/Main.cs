using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winform.BUS;

namespace winform
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Hiển thị tất cả các tour
            dataGridViewTour.DataSource = TourBUS.getAllTour();

            //Hiển thị dữ liệu cho loại tour
            foreach (var item in LoaiTourBUS.getAll().ToArray())
            {
                cbLoaiTour.Items.Add(item.toString());
            }
            cbLoaiTour.SelectedIndex = 0;

            //Hiển thị danh sách các địa điểm
            foreach (var item in DiaDiemBUS.getAll().ToArray())
            {
                checkedList.Items.Add(item.toString());
            }

        }
    }
}
