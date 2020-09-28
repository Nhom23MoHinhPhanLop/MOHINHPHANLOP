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

               dataGridViewTour.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewTour.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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



        private void dataGridViewTour_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewTour.SelectedRows.Count > 0)
            {
                String matour = dataGridViewTour.SelectedRows[0].Cells["matour"].Value.ToString();

                //Hiển thị giá của tour
                dataGridViewGia.DataSource = GiaBUS.getGiaById(matour);
                dataGridViewGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewGia.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewGia.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                //Hiển thị tên tour
                txtMaTour.Text = matour;
                txtTenTour.Text = dataGridViewTour.SelectedRows[0].Cells["tentour"].Value.ToString();

                //

            }
        }
    }
}
