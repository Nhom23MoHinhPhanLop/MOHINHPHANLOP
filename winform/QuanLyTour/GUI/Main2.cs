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

        public Main2()
        {
            InitializeComponent();
        }

        private void Main2_Load(object sender, EventArgs e)
        {
            List<TourBUS> dsTour;
            List<LoaiTourBUS> dsLoaiTour;
            List<DiaDiemBUS> dsDiaDiem;
            List<DoanBUS> dsDoan;
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
            load_dsTour(dsTour);

            //Hiển thị danh sách loại tour
            load_dsLoaiTour(dsLoaiTour);

            //Hiển thị danh sách địa điểm 
            load_dsDiaDiem(dsDiaDiem);

            //Ẩn up and down giá trị của giá hiện tại
            txt_Gia.Controls[0].Visible = false;

            //////////////////////////////////////////
            //Lấy dữ liệu đoàn khách
            dsDoan = DAO.DoanDAO.getAll();
            foreach (DoanBUS item in dsDoan)
            {
                item.DsChiPhi = ChiPhiBUS.getChiPhiByDoan(item);
                item.DsKhachHang = KhachHangBUS.getKhachHangByDoan(item);
                item.DsNhanVien = NhanVienBUS.getNhanVienByDoan(item);
            }

            //hiển thị danh sách đoàn khách
            load_dsDoan(dsDoan);
            //hiển thị danh sách loại chi phí
            load_dsLoaiChiPhi(DAO.LoaiChiPhiDAO.getAll());

            //Hiển thị danh sách tour của đoàn
            load_cb_dsTour(dsTour);
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
            List<TourBUS> dsTour = (List<TourBUS>)grid_dsTour.DataSource;

            //Thêm thông tin cho tour
            TourBUS tour = new TourBUS();

            tour.MaTour = txt_maTour.Text;
            tour.TenTour = txt_tenTour.Text;
            tour.LoaiTour = (LoaiTourBUS)comboBox_loaiTour.SelectedItem;

            if (!String.IsNullOrEmpty(tour.MaTour))
            {
                if (!tour.isExist())
                {
                    dsTour.Add(tour);

                    tour.Them();

                    load_dsTour(dsTour);
                }
                else
                {
                    MessageBox.Show("Tour đã tồn tại", "Thông báo");

                }
            }
            else
            {
                MessageBox.Show("Nhập mã tour", "Thông báo");
            }
        }
        private void btn_xoaTour_Click(object sender, EventArgs e)
        {
            if (grid_dsTour.SelectedRows.Count > 0)
            {
                List<TourBUS> dsTour = (List<TourBUS>)grid_dsTour.DataSource;

                TourBUS tour = (TourBUS)grid_dsTour.CurrentRow.DataBoundItem;

                //Xóa tour trong cơ sở dữ liệu
                tour.Xoa();

                //Xóa tour và hiển thị lại giao diện
                dsTour.Remove(tour);
                load_dsTour(dsTour);
            }
            else
            {
                MessageBox.Show("Chọn 1 tour để xóa", "Thông báo");
            }
        }
        private void btn_suaTour_Click(object sender, EventArgs e)
        {
            if (grid_dsTour.SelectedRows.Count > 0)
            {
                List<TourBUS> dsTour = (List<TourBUS>)grid_dsTour.DataSource;

                //Tạo tour mới từ giao diện
                TourBUS tourmoi = new TourBUS();
                tourmoi.MaTour = txt_maTour.Text;
                tourmoi.TenTour = txt_tenTour.Text;
                tourmoi.LoaiTour = (LoaiTourBUS)comboBox_loaiTour.SelectedItem;

                //Lấy tour đang chọn
                TourBUS tourcu = (TourBUS)grid_dsTour.CurrentRow.DataBoundItem;

                if (tourmoi.isExist() && tourmoi.MaTour != tourcu.MaTour)
                {
                    MessageBox.Show("Trùng mã tour", "Thông báo");
                }
                else
                {
                    //Sửa đoàn trong cơ sở dữ liệu
                    tourcu.Sua(tourmoi);

                    //Đặt tất cả thông tin của đoàn cũ thành đoàn mới
                    tourcu.MaTour = tourmoi.MaTour;
                    tourcu.TenTour = tourmoi.TenTour;
                    tourcu.LoaiTour = tourmoi.LoaiTour;


                    //Hiển thị lại danh sách đoàn
                    load_dsTour(dsTour);
                }
            }
            else
            {
                MessageBox.Show("Chọn 1 tour để sửa", "Thông báo");
            }
        }
        #endregion

        #region DiaDiem

        private void btn_themDiaDiemTour_Click(object sender, EventArgs e)
        {
            if (grid_dsTour.SelectedRows.Count > 0)
            {
                TourBUS tour = (TourBUS)grid_dsTour.CurrentRow.DataBoundItem;

                if (listBox_dsDiaDiem.SelectedIndex >= 0)
                {
                    DiaDiemBUS diadiem = (DiaDiemBUS)listBox_dsDiaDiem.SelectedItem;
                    listBox_dsDiaDiem.Items.Remove(diadiem);
                    listBox_dsDiaDiemTour.Items.Add(diadiem);


                    //Thêm vào cơ sở dữ liệu
                    tour.ThemDiaDiem(diadiem);
                }
                else
                {
                    MessageBox.Show("Chưa chọn địa điểm", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn tour", "Thông báo", MessageBoxButtons.OK);

            }
        }

        private void btn_xoaDiaDiemTour_Click(object sender, EventArgs e)
        {
            if (grid_dsTour.SelectedRows.Count > 0)
            {
                TourBUS tour = (TourBUS)grid_dsTour.CurrentRow.DataBoundItem;

                if (listBox_dsDiaDiemTour.SelectedIndex >= 0)
                {
                    DiaDiemBUS diadiem = (DiaDiemBUS)listBox_dsDiaDiemTour.SelectedItem;
                    listBox_dsDiaDiemTour.Items.Remove(diadiem);
                    listBox_dsDiaDiem.Items.Add(diadiem);

                    //Xóa trong cơ sở dữ liệu
                    tour.XoaDiaDiem(diadiem);
                }
                else
                {
                    MessageBox.Show("Chưa chọn địa điểm", "Thông báo", MessageBoxButtons.OK);

                }
            }
            else
            {
                MessageBox.Show("Chưa chọn tour", "Thông báo", MessageBoxButtons.OK);

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
            if (grid_dsTour.SelectedRows.Count > 0)
            {
                TourBUS tour = (TourBUS)grid_dsTour.CurrentRow.DataBoundItem;

                //Lấy thông tin giá từ giao diện
                GiaBUS gia = getGia();

                //Thêm giá vào tour
                tour.ThemGia(gia);

                //Hiển thị lại danh sách giá
                load_dsGia(tour.DsGia);
            }
            else
            {
                MessageBox.Show("Chọn tour để thêm giá", "Thông báo");

            }
        }
        private void btn_xoaGia_Click(object sender, EventArgs e)
        {
            if (grid_dsGia.SelectedRows.Count > 0)
            {
                TourBUS tour = (TourBUS)grid_dsTour.CurrentRow.DataBoundItem;

                //Lấy thông tin giá từ giao diện
                GiaBUS gia = getGia();

                //Xóa giá trong tour
                tour.XoaGia(gia);

                //Hiển thị lại danh sách giá
                load_dsGia(tour.DsGia);

            }
            else
            {
                MessageBox.Show("Chọn 1 giá để xóa", "Thông báo");
            }
        }
        private void btn_suaGia_Click(object sender, EventArgs e)
        {
            if (grid_dsGia.SelectedRows.Count > 0 && grid_dsTour.SelectedRows.Count > 0)
            {
                TourBUS tour = (TourBUS)grid_dsTour.CurrentRow.DataBoundItem;

                //Lấy thông tin giá từ giao diện
                GiaBUS gia = getGia();

                tour.SuaGia(gia);

                load_dsGia(tour.DsGia);

            }
            else
            {
                MessageBox.Show("Chọn 1 giá để sửa", "Thông báo");
            }
        }

        #endregion

        #region Đoàn
        private void grid_dsDoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DoanBUS doan = (DoanBUS)grid_dsDoan.CurrentRow.DataBoundItem;

                //Hiển thị thông tin của đoàn
                txt_maDoan.Text = doan.MaDoan;
                txt_tenDoan.Text = doan.TenDoan;
                datetime_batdauDoan.Value = doan.NgayBatDau;
                datetime_ketthucDoan.Value = doan.NgayKetThuc;
                comboBox_Tour.SelectedValue = doan.Tour.MaTour;

                //Hiển thị danh sách chi phí
                load_dsChiPhi(doan.DsChiPhi);

                //Hiển thị danh sách Nhân viên
                load_dsNhanVien(doan.DsNhanVien);

                //Hiển thị danh sách Khách hàng
                load_dsKhachHang(doan.DsKhachHang);
            }
        }
        private void btn_ThemDoan_Click(object sender, EventArgs e)
        {
            //Lấy danh sách đoàn dang có 
            List<DoanBUS> dsDoan = (List<DoanBUS>)grid_dsDoan.DataSource;

            //Lấy thông tin đoàn từ giao diện
            DoanBUS doan = getDoan();

            if (doan.KiemTraTonTai())
            {
                MessageBox.Show("Đoàn đã tồn tại", "Thông báo");
            }
            else if (String.IsNullOrEmpty(doan.MaDoan))
            {
                MessageBox.Show("Mã đoàn không được để trống", "Thông báo");
            }
            else
            {
                //Thêm vào cơ sở dữ liệu
                doan.Them();

                //Thêm vào danh sách đoàn và hiển thị lại giao diện
                dsDoan.Add(doan);
                load_dsDoan(dsDoan);
            }

        }
        private void btn_XoaDoan_Click(object sender, EventArgs e)
        {
            List<DoanBUS> dsDoan = (List<DoanBUS>)grid_dsDoan.DataSource;

            if (grid_dsDoan.SelectedRows.Count > 0)
            {
                DoanBUS doan = (DoanBUS)grid_dsDoan.CurrentRow.DataBoundItem;

                //Xóa đoàn trong cơ sở dữ liệu
                doan.Xoa();

                //Xóa đoàn và hiển thị lại giao diện
                dsDoan.Remove(doan);
                load_dsDoan(dsDoan);
            }
            else
            {
                MessageBox.Show("Chọn 1 đoàn để xóa", "Thông báo");
            }
        }
        private void btn_SuaDoan_Click(object sender, EventArgs e)
        {
            List<DoanBUS> dsDoan = (List<DoanBUS>)grid_dsDoan.DataSource;

            if (grid_dsDoan.SelectedRows.Count > 0)
            {
                //Lấy đoàn từ giao diện
                DoanBUS doanmoi = getDoan();

                //Lấy đoàn đang chọn
                DoanBUS doancu = (DoanBUS)grid_dsDoan.CurrentRow.DataBoundItem;

                if (doanmoi.KiemTraTonTai() && doanmoi.MaDoan != doancu.MaDoan)
                {
                    MessageBox.Show("Trùng mã đoàn", "Thông báo");
                }
                else
                {
                    //Sửa đoàn trong cơ sở dữ liệu
                    doancu.Sua(doanmoi);

                    //Đặt tất cả thông tin của đoàn cũ thành đoàn mới
                    doancu.MaDoan = doanmoi.MaDoan;
                    doancu.TenDoan = doanmoi.TenDoan;
                    doancu.NgayBatDau = doanmoi.NgayBatDau;
                    doancu.NgayKetThuc = doanmoi.NgayKetThuc;
                    doancu.Tour = doanmoi.Tour;

                    //Hiển thị lại danh sách đoàn
                    load_dsDoan(dsDoan);
                }

            }
            else
            {
                MessageBox.Show("Chọn 1 đoàn để sửa", "Thông báo");
            }
        }
        #endregion

        #region Khách hàng
        private void btn_ThemKhachHang_Click(object sender, EventArgs e)
        {
            if (grid_dsDoan.SelectedRows.Count > 0)
            {
                DoanBUS doan = (DoanBUS)grid_dsDoan.CurrentRow.DataBoundItem;

                //Mở form hiển thị danh sách khách hàng không có trong đoàn hiện tại
                KhachHang formKhachHang = new KhachHang(doan);
                formKhachHang.ShowDialog();

                if (formKhachHang.grid_dsKhachHang.SelectedRows.Count > 0 && formKhachHang.clicked)
                {
                    //Lấy danh sách khách hàng được chọn ở form danh sách khách hàng
                    List<KhachHangBUS> dsThemMoi = new List<KhachHangBUS>();

                    foreach (DataGridViewRow row in formKhachHang.grid_dsKhachHang.SelectedRows)
                    {
                        KhachHangBUS khachhang = (KhachHangBUS)row.DataBoundItem;

                        dsThemMoi.Add(khachhang);

                        //Thêm khách hàng ở cơ sở dữ liệu
                        doan.ThemKhachHang(khachhang);
                    }


                    //thêm danh sách khách hàng vào danh sách khách hàng của đoàn đang chọn và hiển thị lại giao diện
                    doan.DsKhachHang.AddRange(dsThemMoi);
                    load_dsKhachHang(doan.DsKhachHang);

                }
            }
            else
            {
                MessageBox.Show("Chưa chọn đoàn", "Thông báo");
            }
        }
        private void btn_XoaKhachHang_Click(object sender, EventArgs e)
        {

            if (grid_dsDoan.SelectedRows.Count > 0 && grid_dsKhachHang.SelectedRows.Count > 0)
            {
                DoanBUS doan = (DoanBUS)grid_dsDoan.CurrentRow.DataBoundItem;

                //Xóa từng khách hàng được chọn
                foreach (DataGridViewRow row in grid_dsKhachHang.SelectedRows)
                {
                    KhachHangBUS khachhang = (KhachHangBUS)row.DataBoundItem;

                    doan.DsKhachHang.Remove(khachhang);

                    //Xóa ở cơ sở dữ liệu
                    doan.XoaKhachHang(khachhang);

                }
                //Hiển thị lại giao diện
                load_dsKhachHang(doan.DsKhachHang);
            }
            else
            {
                MessageBox.Show("Chưa chọn khách hàng để xóa", "Thông báo");
            }
        }
        #endregion

        #region Nhân viên
        private void btn_ThemNhanVien_Click(object sender, EventArgs e)
        {
            if (grid_dsDoan.SelectedRows.Count > 0)
            {
                DoanBUS doan = (DoanBUS)grid_dsDoan.CurrentRow.DataBoundItem;

                //Mở form hiển thị danh sách nhân viên không có trong đoàn đang chọn
                NhanVien formNhanVien = new NhanVien(doan);
                formNhanVien.ShowDialog();

                //Lấy danh sách nhân viên được chọn ở form trên
                if (formNhanVien.grid_dsNhanVien.SelectedRows.Count > 0 && formNhanVien.clicked)
                {
                    List<NhanVienBUS> dsThemMoi = new List<NhanVienBUS>();
                    foreach (DataGridViewRow row in formNhanVien.grid_dsNhanVien.SelectedRows)
                    {
                        NhanVienBUS nhanvien = (NhanVienBUS)row.DataBoundItem;
                        dsThemMoi.Add(nhanvien);

                        //Thêm danh sách nhân viên vào cơ sở dữ liệu
                        doan.ThemNhanVien(nhanvien);
                    }
                    //Thêm vào danh sách nhân viên của đoàn đang chọn và hiển thị lại giao diện
                    doan.DsNhanVien.AddRange(dsThemMoi);
                    load_dsNhanVien(doan.DsNhanVien);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn đoàn", "Thông báo");
            }
        }
        private void btn_XoaNhanVien_Click(object sender, EventArgs e)
        {
            if (grid_dsDoan.SelectedRows.Count > 0 && grid_dsNhanVien.SelectedRows.Count > 0)
            {
                DoanBUS doan = (DoanBUS)grid_dsDoan.CurrentRow.DataBoundItem;

                //Xóa từng nhân viên được chọn
                foreach (DataGridViewRow row in grid_dsNhanVien.SelectedRows)
                {
                    NhanVienBUS nhanvien = (NhanVienBUS)row.DataBoundItem;

                    doan.DsNhanVien.Remove(nhanvien);

                    //Cập nhật ở cơ sở dữ liệu
                    doan.XoaNhanVien(nhanvien);
                }

                //Hiển thị lại giao diện
                load_dsNhanVien(doan.DsNhanVien);

            }
            else
            {
                MessageBox.Show("Chưa chọn nhân viên để xóa", "Thông báo");
            }
        }

        #endregion

        #region Chi phí
        private void grid_dsChiPhi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ChiPhiBUS chiphi = (ChiPhiBUS)grid_dsChiPhi.CurrentRow.DataBoundItem;

                //Thông tin của chi phí
                txt_sotien.Value = chiphi.Tien;
                datetime_thoigian.Value = chiphi.Thoigian;

                //Hiển thị loại chi phí
                comboBox_loaiChiPhi.SelectedValue = chiphi.LoaiChiPhi.MaLoaiChiPhi;
                //Hiển thị danh sách Nhân viên

                //Hiển thị danh sách Khách hàng

            }
        }

        private void btn_ThemChiPhi_Click(object sender, EventArgs e)
        {

            if (grid_dsDoan.SelectedRows.Count > 0)
            {
                DoanBUS doan = (DoanBUS)grid_dsDoan.CurrentRow.DataBoundItem;

                //Lấy chi phí từ giao diện
                ChiPhiBUS chiphi = getChiPhi();

                //Thêm vào cơ sở dữ liệu
                doan.ThemChiPhi(chiphi);

                //Thêm vào đoàn đang chọn và hiển thị lại giao diện
                doan.DsChiPhi.Add(chiphi);
                load_dsChiPhi(doan.DsChiPhi);
            }
            else
            {
                MessageBox.Show("Chưa chọn đoàn", "Thông báo");
            }
        }

        private void btn_XoaChiPhi_Click(object sender, EventArgs e)
        {
            if (grid_dsDoan.SelectedRows.Count > 0 && grid_dsChiPhi.SelectedRows.Count > 0)
            {
                DoanBUS doan = (DoanBUS)grid_dsDoan.CurrentRow.DataBoundItem;

                //Xóa từng chi phí được chọn
                foreach (DataGridViewRow row in grid_dsChiPhi.SelectedRows)
                {
                    ChiPhiBUS chiphi = (ChiPhiBUS)row.DataBoundItem;

                    doan.DsChiPhi.Remove(chiphi);

                    //Xóa trong cơ sở dữ liệu
                    chiphi.Xoa();

                }

                //Hiển thị lại giao diện
                load_dsChiPhi(doan.DsChiPhi);
            }
            else
            {
                MessageBox.Show("Chưa chọn chi phí để xóa", "Thông báo");
            }
        }

        private void btn_SuaChiPhi_Click(object sender, EventArgs e)
        {
            if (grid_dsDoan.SelectedRows.Count > 0 && grid_dsChiPhi.SelectedRows.Count == 1)
            {
                DoanBUS doan = (DoanBUS)grid_dsDoan.CurrentRow.DataBoundItem;

                //lấy chi phí từ giao diện
                ChiPhiBUS chiphimoi = getChiPhi();

                //lấy chi phí đang chọn
                ChiPhiBUS chiphicu = (ChiPhiBUS)grid_dsChiPhi.CurrentRow.DataBoundItem;

                //đặt tất cả thông tin của chi phí cũ thành chi phí mới
                chiphicu.LoaiChiPhi = chiphimoi.LoaiChiPhi;
                chiphicu.Thoigian = chiphimoi.Thoigian;
                chiphicu.Tien = chiphimoi.Tien;

                //Cập nhật trong cơ sở dữ liệu
                chiphicu.Sua();

                //Hiển thị lại giao diện
                load_dsChiPhi(doan.DsChiPhi);
            }
            else
            {
                MessageBox.Show("Chọn 1 chi phí để sửa", "Thông báo");
            }
        }
        #endregion

        #region loadDataGUI
        void load_dsTour(List<TourBUS> dsTour)
        {
            grid_dsTour.DataSource = null;
            grid_dsTour.DataSource = dsTour;
            grid_dsTour.Columns["loaiTour"].Visible = false;
            grid_dsTour.Columns["giaHienTai"].Visible = false;

            grid_dsTour.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid_dsTour.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_dsTour.ClearSelection();

            load_cb_dsTour(dsTour);
        }
        void load_dsLoaiTour(List<LoaiTourBUS> dsLoaiTour)
        {
            comboBox_loaiTour.DataSource = dsLoaiTour;
            comboBox_loaiTour.DisplayMember = "tenLoai";
            comboBox_loaiTour.ValueMember = "maLoai";
        }
        void load_dsDiaDiemTour(List<DiaDiemBUS> diadiem)
        {
            if (diadiem != null)
            {
                listBox_dsDiaDiem.Items.AddRange(listBox_dsDiaDiemTour.Items);
                listBox_dsDiaDiemTour.Items.Clear();

                foreach (DiaDiemBUS item in diadiem)
                {
                    listBox_dsDiaDiemTour.Items.Add(item);
                    listBox_dsDiaDiem.Items.Remove(item);

                }
            }

        }
        void load_dsDiaDiem(List<DiaDiemBUS> dsDiaDiem)
        {
            listBox_dsDiaDiem.Items.Clear();
            foreach (DiaDiemBUS item in dsDiaDiem)
            {
                listBox_dsDiaDiem.Items.Add(item);
            }
        }
        void load_dsGia(List<GiaBUS> dsGia)
        {
            grid_dsGia.DataSource = null;
            if (dsGia.Count > 0)
            {
                grid_dsGia.DataSource = dsGia;
                grid_dsGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grid_dsGia.Columns["maTour"].Visible = false;
                grid_dsGia.Columns["id"].Visible = false;
                grid_dsGia.ClearSelection();
            }
        }
        void load_Gia(GiaBUS gia)
        {
            txt_Gia.Value = gia.Tien;
            datetime_batdauGia.Value = gia.NgayBatDau;
            datetime_ketthucGia.Value = gia.NgayKetThuc;
        }
        void load_dsDoan(List<DoanBUS> dsDoan)
        {
            grid_dsDoan.DataSource = null;
            grid_dsDoan.DataSource = dsDoan;

            grid_dsDoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            grid_dsDoan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_dsDoan.Columns["tour"].Visible = false;

            grid_dsDoan.ClearSelection();

            load_dsChiPhi(null);
            load_dsKhachHang(null);
            load_dsNhanVien(null);
        }
        void load_dsChiPhi(List<ChiPhiBUS> dsChiPhi)
        {

            grid_dsChiPhi.DataSource = null;
            if (dsChiPhi != null && dsChiPhi.Count > 0)
            {
                grid_dsChiPhi.DataSource = dsChiPhi;
                grid_dsChiPhi.Columns["loaiChiPhi"].Visible = false;
                grid_dsChiPhi.Columns["maChiphi"].Visible = false;
                grid_dsChiPhi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grid_dsChiPhi.ClearSelection();
            }

        }
        void load_dsLoaiChiPhi(List<LoaiChiPhiBUS> dsLoaiChiPhi)
        {
            comboBox_loaiChiPhi.DataSource = dsLoaiChiPhi;
            comboBox_loaiChiPhi.DisplayMember = "tenLoaiChiPhi";
            comboBox_loaiChiPhi.ValueMember = "maLoaiChiPhi";
        }
        void load_dsKhachHang(List<KhachHangBUS> dsKhachHang)
        {
            grid_dsKhachHang.DataSource = null;
            if (dsKhachHang != null && dsKhachHang.Count > 0)
            {
                grid_dsKhachHang.DataSource = dsKhachHang;
                grid_dsKhachHang.Columns["doan"].Visible = false;
                grid_dsKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                grid_dsKhachHang.Columns["tenkhachhang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                grid_dsKhachHang.ClearSelection();
            }

        }
        void load_dsNhanVien(List<NhanVienBUS> dsNhanVien)
        {
            grid_dsNhanVien.DataSource = null;
            if (dsNhanVien != null && dsNhanVien.Count > 0)
            {
                grid_dsNhanVien.DataSource = dsNhanVien;
                grid_dsNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grid_dsNhanVien.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                grid_dsNhanVien.ClearSelection();
            }
        }
        void load_cb_dsTour(List<TourBUS> dsTour)
        {
            comboBox_Tour.DataSource = dsTour;
            comboBox_Tour.DisplayMember = "tenTour";
            comboBox_Tour.ValueMember = "maTour";
        }

        #endregion

        #region getDataGUI

        GiaBUS getGia()
        {
            GiaBUS gia = new GiaBUS();
            gia.Tien = (long)txt_Gia.Value;
            gia.NgayBatDau = datetime_batdauGia.Value;
            gia.NgayKetThuc = datetime_ketthucGia.Value;
            gia.MaTour = grid_dsTour.CurrentRow.Cells["maTour"].Value.ToString();

            if (grid_dsGia.SelectedRows.Count > 0)
                gia.Id = int.Parse(grid_dsGia.CurrentRow.Cells["id"].Value.ToString());

            return gia;
        }
        ChiPhiBUS getChiPhi()
        {
            ChiPhiBUS chiphi = new ChiPhiBUS();
            chiphi.Tien = long.Parse(txt_sotien.Value.ToString());
            chiphi.LoaiChiPhi = (LoaiChiPhiBUS)comboBox_loaiChiPhi.SelectedItem;
            chiphi.Thoigian = datetime_thoigian.Value;
            return chiphi;

        }
        DoanBUS getDoan()
        {
            DoanBUS doan = new DoanBUS();
            doan.MaDoan = txt_maDoan.Text;
            doan.TenDoan = txt_tenDoan.Text;
            doan.NgayBatDau = datetime_batdauDoan.Value;
            doan.NgayKetThuc = datetime_ketthucDoan.Value;
            doan.Tour = (TourBUS)comboBox_Tour.SelectedItem;
            return doan;
        }
        #endregion

        #region Event dùng chung

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //grid_dsDoan.ClearSelection();

        }

        private void grid_dsChiPhi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            gridView.ClearSelection();
        }

        #endregion


    }
}
