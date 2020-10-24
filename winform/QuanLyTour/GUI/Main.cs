using QuanLyTour.BUS;
using QuanLyTour.DAO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyTour.GUI
{
    public partial class Main : Form
    {
        List<TourBUS> dsTour;
        List<LoaiTourBUS> dsLoaiTour;
        List<DiaDiemBUS> dsDiaDiem;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Lấy dữ liệu ban đầu từ csdl
            dsTour = TourDAO.getAll();
            dsLoaiTour = LoaiTourDAO.getAll();
            dsDiaDiem = DiaDiemDAO.getAll();
            foreach (TourBUS tour in dsTour)
            {
                tour.LoaiTour = LoaiTourDAO.getLoaiTourByTour(tour);
                tour.DsDiaDiem = DiaDiemDAO.getDiaDiemByTour(tour);
            }

            //Hiển thị danh sách tour
            grid_dsTour.DataSource = dsTour;
            grid_dsTour.Columns.Remove("loaiTour");
            grid_dsTour.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid_dsTour.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_dsTour.ClearSelection();

            //Hiển thị danh sách loại tour
            comboBox_loaiTour.DataSource = dsLoaiTour;
            comboBox_loaiTour.DisplayMember = "tenLoai";
            comboBox_loaiTour.ValueMember = "maLoai";

            //Hiển thị danh sách địa điểm 
            foreach (DiaDiemBUS diadiem in dsDiaDiem)
            {
                checkedListBox_dsDiaDiem.Items.Add(diadiem.TenDiaDiem);
            }

            //
            txt_Gia.Controls[0].Visible = false;

        }

        private void grid_dsTour_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TourBUS currentTour = dsTour[e.RowIndex];
                txt_maTour.Text = currentTour.MaTour;
                txt_tenTour.Text = currentTour.TenTour;

                //Hiển thị loại tour của tour
                comboBox_loaiTour.SelectedValue = currentTour.LoaiTour.MaLoai;

                //Check danh sách địa điểm của tour
                for (int i = 0; i < checkedListBox_dsDiaDiem.Items.Count; i++)
                {
                    checkedListBox_dsDiaDiem.SetItemChecked(i, false);
                    foreach (DiaDiemBUS diadiem in currentTour.DsDiaDiem)
                    {
                        if (checkedListBox_dsDiaDiem.Items[i].ToString() == diadiem.TenDiaDiem)
                        {
                            checkedListBox_dsDiaDiem.SetItemChecked(i, true);
                        }
                    }
                }

                //Hiển thị giá của tour
                grid_dsGia.DataSource = GiaDAO.getGiaByTour(currentTour);
                grid_dsGia.Columns.Remove("tour");
                grid_dsGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grid_dsGia.ClearSelection();
            }



        }
    }
}
