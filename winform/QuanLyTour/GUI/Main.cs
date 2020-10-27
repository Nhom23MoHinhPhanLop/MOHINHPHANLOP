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
                tour.GiaHienTai = GiaDAO.getGiaHienTai(tour);
                tour.DsGia = GiaDAO.getGiaByTour(tour);
            }

            //Hiển thị danh sách tour
            grid_dsTour.DataSource = dsTour;
            grid_dsTour.Columns.Remove("loaiTour");
            grid_dsTour.Columns.Remove("giaHienTai");

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

            //Ẩn up and down giá trị của giá hiện tại
            txt_Gia.Controls[0].Visible = false;

        }

        private void grid_dsTour_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TourBUS currentTour = (TourBUS)grid_dsTour.SelectedRows[0].DataBoundItem;
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

                //Hiển thị giá hiện tại
                txt_Gia.Value = currentTour.GiaHienTai.Tien;
                datetime_batdauGia.Value = (DateTime)currentTour.GiaHienTai.NgayBatDau;
                datetime_ketthucGia.Value = (DateTime)currentTour.GiaHienTai.NgayKetThuc;

                //Hiển thị danh sách giá của tour
                grid_dsGia.DataSource = null;
                grid_dsGia.DataSource = currentTour.DsGia;
                grid_dsGia.Columns.Remove("tour");
                grid_dsGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grid_dsGia.ClearSelection();

            }



        }

        private void btn_themTour_Click(object sender, EventArgs e)
        {
            //Tạo một tour mới 
            TourBUS tour = new TourBUS();

            //Cập nhật thông tin tour
            tour.MaTour = txt_maTour.Text;
            tour.TenTour = txt_tenTour.Text;
            tour.LoaiTour = (LoaiTourBUS)comboBox_loaiTour.SelectedItem;

            tour.GiaHienTai = new GiaBUS();
            tour.GiaHienTai.Tien = long.Parse(txt_Gia.Value.ToString());
            tour.GiaHienTai.NgayBatDau = datetime_batdauGia.Value;
            tour.GiaHienTai.NgayKetThuc = datetime_ketthucGia.Value;
            tour.GiaHienTai.Tour = tour;
            tour.DsGia = new List<GiaBUS>();
            tour.DsGia.Add(tour.GiaHienTai);

            tour.DsDiaDiem = new List<DiaDiemBUS>();
            foreach (DiaDiemBUS diadiem in dsDiaDiem)
            {
                foreach (var item in checkedListBox_dsDiaDiem.CheckedItems)
                {
                    if (item.ToString() == diadiem.TenDiaDiem)
                    {
                        tour.DsDiaDiem.Add(diadiem);
                    }
                }
            }
            
            //Hiển thị lại giao diện khi thêm
            dsTour.Add(tour);
            grid_dsTour.DataSource = null;
            grid_dsTour.DataSource = dsTour;
            grid_dsTour.Columns.Remove("loaiTour");
            grid_dsTour.Columns.Remove("giaHienTai");

            grid_dsTour.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid_dsTour.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_dsTour.ClearSelection();

            tour.ThemMoi();
        }

        private void btn_capnhatTour_Click(object sender, EventArgs e)
        {

        }

        private void btn_xoaTour_Click(object sender, EventArgs e)
        {

        }
    }
}
