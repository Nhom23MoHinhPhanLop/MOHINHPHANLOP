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
    public partial class Main2 : Form
    {
        List<TourBUS> dsTour;
        List<LoaiTourBUS> dsLoaiTour;
        List<DiaDiemBUS> dsDiaDiem;
        public Main2()
        {
            InitializeComponent();
        }

        private void Main2_Load(object sender, EventArgs e)
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
            load_dsTour();

            //Hiển thị danh sách loại tour
            comboBox_loaiTour.DataSource = dsLoaiTour;
            comboBox_loaiTour.DisplayMember = "tenLoai";
            comboBox_loaiTour.ValueMember = "maLoai";

            //Hiển thị danh sách địa điểm 
            load_dsDiaDiem();

            //Ẩn up and down giá trị của giá hiện tại
            txt_Gia.Controls[0].Visible = false;
        }


        #region Tour
        private void grid_dsTour_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TourBUS currentTour = (TourBUS)grid_dsTour.CurrentRow.DataBoundItem;
                txt_maTour.Text = currentTour.MaTour;
                txt_tenTour.Text = currentTour.TenTour;

                //Hiển thị loại tour của tour
                comboBox_loaiTour.SelectedValue = currentTour.LoaiTour.MaLoai;

                //Hiển thị danh sách địa điểm của tour
                load_dsDiaDiemTour(currentTour.DsDiaDiem);

                //Hiển thị giá hiện tại
                load_Gia(currentTour.GiaHienTai);

                //Hiển thị danh sách giá của tour
                load_dsGia(currentTour.DsGia);

            }
        }

        private void btn_themTour_Click(object sender, EventArgs e)
        {
            //Tạo mới 1 tour
            //Thêm thông tin cho tour
            TourBUS newTour = new TourBUS();

            newTour.MaTour = txt_maTour.Text;
            newTour.TenTour = txt_tenTour.Text;
            newTour.LoaiTour = (LoaiTourBUS)comboBox_loaiTour.SelectedItem;

            //Lấy danh sách địa điểm 
            foreach (DiaDiemBUS diadiem in listBox_dsDiaDiemTour.Items)
                newTour.DsDiaDiem.Add(diadiem);

            newTour.DsGia = (List<GiaBUS>)grid_dsGia.DataSource;

            //Lấy giá hiện tại
            GiaBUS gia = new GiaBUS();
            gia.NgayBatDau = datetime_batdauGia.Value;
            gia.NgayKetThuc = datetime_ketthucGia.Value;
            gia.Tien = (long)txt_Gia.Value;
            newTour.GiaHienTai = gia;

            if (newTour.isExist())
                MessageBox.Show("Tour đã tồn tại", "Thông báo", MessageBoxButtons.OK);
            else
            {
                newTour.ThemMoi();
                dsTour.Add(newTour);

                //Load lại danh sách tour
                load_dsTour();
            }
        }

        private void btn_suaTour_Click(object sender, EventArgs e)
        {
            TourBUS currentTour = (TourBUS)grid_dsTour.CurrentRow.DataBoundItem;

            TourBUS newTour = new TourBUS();
            newTour.MaTour = txt_maTour.Text;
            newTour.TenTour = txt_tenTour.Text;
            newTour.LoaiTour = (LoaiTourBUS)comboBox_loaiTour.SelectedItem;
            newTour.DsDiaDiem = (List<DiaDiemBUS>)listBox_dsDiaDiemTour.DataSource;
            newTour.DsGia = (List<GiaBUS>)grid_dsGia.DataSource;


        }

        private void btn_xoaTour_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region DiaDiem

        private void btn_themDiaDiemTour_Click(object sender, EventArgs e)
        {
            if (listBox_dsDiaDiem.SelectedIndex >= 0)
            {
                DiaDiemBUS diadiem = (DiaDiemBUS)listBox_dsDiaDiem.SelectedItem;
                listBox_dsDiaDiem.Items.Remove(diadiem);
                listBox_dsDiaDiemTour.Items.Add(diadiem);
            }
            else
            {
                MessageBox.Show("Chưa chọn địa điểm", "Thông báo", MessageBoxButtons.OK);
                listBox_dsDiaDiem.Focus();
            }
        }

        private void btn_xoaDiaDiemTour_Click(object sender, EventArgs e)
        {
            if (listBox_dsDiaDiemTour.SelectedIndex >= 0)
            {
                DiaDiemBUS diadiem = (DiaDiemBUS)listBox_dsDiaDiemTour.SelectedItem;
                listBox_dsDiaDiemTour.Items.Remove(diadiem);
                listBox_dsDiaDiem.Items.Add(diadiem);
            }
            else
            {
                MessageBox.Show("Chưa chọn địa điểm", "Thông báo", MessageBoxButtons.OK);
                listBox_dsDiaDiemTour.Focus();

            }
        }

        #endregion

        #region Gia

        private void grid_dsGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                GiaBUS gia = (GiaBUS)grid_dsGia.CurrentRow.DataBoundItem;
                load_Gia(gia);
            }

        }

        private void btn_themGia_Click(object sender, EventArgs e)
        {
            TourBUS currentTour = (TourBUS)grid_dsTour.CurrentRow.DataBoundItem;

            currentTour.DsGia.Add(getGia());
            load_dsGia(currentTour.DsGia);
        }

        private void btn_suaGia_Click(object sender, EventArgs e)
        {
            if (grid_dsGia.SelectedRows.Count > 0)
            {
                TourBUS currentTour = (TourBUS)grid_dsTour.CurrentRow.DataBoundItem;

                GiaBUS gia = (GiaBUS)grid_dsGia.CurrentRow.DataBoundItem;
                GiaBUS newGia = getGia();
                if (!gia.Equals(newGia))
                {
                    currentTour.DsGia[grid_dsGia.CurrentRow.Index] = newGia;
                    load_dsGia(currentTour.DsGia);
                }
                else
                {
                    MessageBox.Show("NO");
                }
            }
        }

        private void btn_xoaGia_Click(object sender, EventArgs e)
        {
            if (grid_dsGia.SelectedRows.Count > 0)
            {
                TourBUS currentTour = (TourBUS)grid_dsTour.CurrentRow.DataBoundItem;

                GiaBUS gia = (GiaBUS)grid_dsGia.CurrentRow.DataBoundItem;

                currentTour.DsGia.Remove(gia);
                load_dsGia(currentTour.DsGia);

            }
        }

        #endregion

        #region loadDataGUI
        void load_dsTour()
        {
            grid_dsTour.DataSource = null;
            grid_dsTour.DataSource = dsTour;
            grid_dsTour.Columns.Remove("loaiTour");
            grid_dsTour.Columns.Remove("giaHienTai");

            grid_dsTour.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid_dsTour.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_dsTour.ClearSelection();
        }
        void load_dsDiaDiemTour(List<DiaDiemBUS> diadiem)
        {
            listBox_dsDiaDiem.Items.Clear();
            listBox_dsDiaDiemTour.Items.Clear();
            String message = "";
            foreach (DiaDiemBUS item in dsDiaDiem)
            {
                if (diadiem.Contains(item))
                    listBox_dsDiaDiemTour.Items.Add(item);
                else
                    listBox_dsDiaDiem.Items.Add(item);

            }

            listBox_dsDiaDiem.DisplayMember = "tenDiaDiem";
            listBox_dsDiaDiem.ValueMember = "maDiaDiem";

            listBox_dsDiaDiemTour.DisplayMember = "tenDiaDiem";
            listBox_dsDiaDiemTour.ValueMember = "maDiaDiem";
        }
        void load_dsDiaDiem()
        {
            listBox_dsDiaDiem.Items.Clear();
            foreach (DiaDiemBUS item in dsDiaDiem)
            {
                listBox_dsDiaDiem.Items.Add(item);
            }

            listBox_dsDiaDiem.DisplayMember = "tenDiaDiem";
            listBox_dsDiaDiem.ValueMember = "maDiaDiem";

            listBox_dsDiaDiemTour.DisplayMember = "tenDiaDiem";
            listBox_dsDiaDiemTour.ValueMember = "maDiaDiem";
        }
        void load_dsGia(List<GiaBUS> dsGia)
        {
            grid_dsGia.DataSource = null;
            grid_dsGia.DataSource = dsGia;
            grid_dsGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid_dsGia.ClearSelection();
        }
        void load_Gia(GiaBUS gia)
        {
            txt_Gia.Value = gia.Tien;
            datetime_batdauGia.Value = gia.NgayBatDau;
            datetime_ketthucGia.Value = gia.NgayKetThuc;
        }

        #endregion

        #region getDataGUI

        GiaBUS getGia()
        {
            GiaBUS gia = new GiaBUS();
            gia.Tien = (long)txt_Gia.Value;
            gia.NgayBatDau = datetime_batdauGia.Value;
            gia.NgayKetThuc = datetime_ketthucGia.Value;

            return gia;
        }

        #endregion
    }
}
