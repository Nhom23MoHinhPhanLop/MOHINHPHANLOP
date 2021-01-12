using Newtonsoft.Json.Linq;
using QuanLyTour.BUS;
using QuanLyTour.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyTour.GUI
{
    public partial class Main2 : Form
    {

        public Main2()
        {
            InitializeComponent();
        }

        #region Event

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
            loadTour(dsTour);

            //Hiển thị danh sách loại tour
            loadLoaiTour(dsLoaiTour);

            //Hiển thị danh sách địa điểm 
            loadDiaDiem(dsDiaDiem);

            //Lấy dữ liệu đoàn khách
            dsDoan = DAO.DoanDAO.getAll();
            foreach (DoanBUS item in dsDoan)
            {
                item.DsChiPhi = ChiPhiDAO.getChiPhiByDoan(item);
                item.DsKhachHang = KhachHangDAO.getKhachHangByDoan(item);
                item.DsNhanVien = NhanVienDAO.getNhanVienByDoan(item);
            }

            //hiển thị danh sách đoàn khách
            loadDoan(dsDoan);
            //hiển thị danh sách loại chi phí
            loadLoaiChiPhi(DAO.LoaiChiPhiDAO.getAll());

            //Hiển thị danh sách nhân viên
            loadNhanVien(NhanVienDAO.getAll());

            //Hiển thị danh sách chức vụ
            loadCbChucVu(ChucVuDAO.getAll());

            //Hiển thị danh sách khách hàng
            loadKhachHang(KhachHangDAO.getAll());
        }
        private void grid_dsTour_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TourBUS tour = (TourBUS)grid_dsTour.CurrentRow.DataBoundItem;
                txt_maTour.Text = tour.MaTour;
                txt_tenTour.Text = tour.TenTour;

                //Hiển thị loại tour của tour
                comboBox_loaiTour.SelectedValue = tour.LoaiTour.MaLoai;

                //Hiển thị danh sách địa điểm của tour
                loadDiaDiemByTour(tour.DsDiaDiem);

                //Hiển thị giá hiện tại
                loadGiaHienTai(tour.GiaHienTai);

                //Hiển thị danh sách giá của tour
                loadGia(tour.DsGia);

            }
        }
        private void btn_themTour_Click(object sender, EventArgs e)
        {
            List<TourBUS> dsTour = (List<TourBUS>)grid_dsTour.DataSource;

            //Lấy tour từ giao diện
            TourBUS tour = getTour();

            if (!String.IsNullOrEmpty(tour.MaTour))
            {
                if (tour.Them())
                {
                    dsTour.Add(tour);
                    loadTour(dsTour);
                }
                else
                {
                    MessageBox.Show("Thêm tour thất bại", "Thông báo");

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

                if (tour.Xoa())
                {
                    dsTour.Remove(tour);
                    loadTour(dsTour);
                }
                else
                {
                    MessageBox.Show("Xóa tour thất bại", "Thông báo");
                }
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

                TourBUS tourmoi = getTour();

                TourBUS tourcu = (TourBUS)grid_dsTour.CurrentRow.DataBoundItem;

                if (tourcu.Sua(tourmoi))
                {
                    //Đặt tất cả thông tin của đoàn cũ thành đoàn mới
                    tourcu.MaTour = tourmoi.MaTour;
                    tourcu.TenTour = tourmoi.TenTour;
                    tourcu.LoaiTour = tourmoi.LoaiTour;

                    loadTour(dsTour);

                }
                else
                {
                    MessageBox.Show("Sửa tour thất bại", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Chọn 1 tour để sửa", "Thông báo");
            }
        }
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
        private void grid_dsGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                GiaBUS gia = (GiaBUS)grid_dsGia.CurrentRow.DataBoundItem;
                loadGiaHienTai(gia);
            }

        }
        private void btn_themGia_Click(object sender, EventArgs e)
        {
            if (grid_dsTour.SelectedRows.Count > 0)
            {
                TourBUS tour = (TourBUS)grid_dsTour.CurrentRow.DataBoundItem;

                //Lấy thông tin giá từ giao diện
                GiaBUS gia = getGia();
                if (gia.NgayBatDau > gia.NgayKetThuc)
                    MessageBox.Show("Ngày bắt đầu không lớn hơn ngày kết thúc", "Thông báo");
                else if (tour.ThemGia(gia))
                {
                    loadGia(tour.DsGia);
                    loadGiaHienTai(tour.GiaHienTai);
                }
                else
                {
                    MessageBox.Show("Thêm giá thất bại", "Thông báo");
                }
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

                if (tour.XoaGia(gia))
                {
                    loadGia(tour.DsGia);
                    loadGiaHienTai(tour.GiaHienTai);

                }
                else
                {
                    MessageBox.Show("Xóa giá thất bại", "Thông báo");
                }
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
                if (gia.NgayBatDau > gia.NgayKetThuc)
                    MessageBox.Show("Ngày bắt đầu không lớn hơn ngày kết thúc", "Thông báo");
                else if (tour.SuaGia(gia))
                {
                    loadGia(tour.DsGia);
                    loadGiaHienTai(tour.GiaHienTai);

                }
                else
                {
                    MessageBox.Show("Sửa giá thất bại", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Chọn 1 giá để sửa", "Thông báo");
            }
        }
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
                loadChiPhi(doan.DsChiPhi);

                //Hiển thị danh sách Nhân viên
                loadNhanVienByDoan(doan.DsNhanVien);

                //Hiển thị danh sách Khách hàng
                loadKhachHangByDoan(doan.DsKhachHang);
            }
        }
        private void btn_ThemDoan_Click(object sender, EventArgs e)
        {
            //Lấy danh sách đoàn dang có 
            List<DoanBUS> dsDoan = (List<DoanBUS>)grid_dsDoan.DataSource;

            //Lấy thông tin đoàn từ giao diện
            DoanBUS doan = getDoan();
            if (doan.NgayBatDau > doan.NgayKetThuc)
            {
                MessageBox.Show("Ngày bắt đầu không lớn hơn ngày kết thúc", "Thông báo");
            }
            else if (doan.KiemTraTonTai())
            {
                MessageBox.Show("Đoàn đã tồn tại", "Thông báo");
            }
            else if (String.IsNullOrEmpty(doan.MaDoan))
            {
                MessageBox.Show("Mã đoàn không được để trống", "Thông báo");
            }
            else
            {
                if (doan.Them())
                {
                    dsDoan.Add(doan);
                    loadDoan(dsDoan);
                }
                else
                {
                    MessageBox.Show("Thêm đoàn thất bại", "Thông báo");
                }
            }

        }
        private void btn_XoaDoan_Click(object sender, EventArgs e)
        {
            List<DoanBUS> dsDoan = (List<DoanBUS>)grid_dsDoan.DataSource;

            if (grid_dsDoan.SelectedRows.Count > 0)
            {
                DoanBUS doan = (DoanBUS)grid_dsDoan.CurrentRow.DataBoundItem;

                if (doan.Xoa())
                {
                    dsDoan.Remove(doan);
                    loadDoan(dsDoan);
                }
                else
                {
                    MessageBox.Show("Xóa đoàn thất bại", "Thông báo");
                }
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
                if (doanmoi.NgayBatDau > doanmoi.NgayKetThuc)
                {
                    MessageBox.Show("Ngày bắt đầu không lớn hơn ngày kết thúc", "Thông báo");
                }
                else if (doanmoi.KiemTraTonTai() && doanmoi.MaDoan != doancu.MaDoan)
                {
                    MessageBox.Show("Trùng mã đoàn", "Thông báo");
                }
                else
                {
                    if (doancu.Sua(doanmoi))
                    {
                        //Đặt tất cả thông tin của đoàn cũ thành đoàn mới
                        doancu.MaDoan = doanmoi.MaDoan;
                        doancu.TenDoan = doanmoi.TenDoan;
                        doancu.NgayBatDau = doanmoi.NgayBatDau;
                        doancu.NgayKetThuc = doanmoi.NgayKetThuc;
                        doancu.Tour = doanmoi.Tour;

                        //Hiển thị lại danh sách đoàn
                        loadDoan(dsDoan);
                    }
                    else
                    {
                        MessageBox.Show("Sửa đoàn thất bại", "Thông báo");
                    }
                }

            }
            else
            {
                MessageBox.Show("Chọn 1 đoàn để sửa", "Thông báo");
            }
        }
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
                    bool flag = true;
                    foreach (DataGridViewRow row in formKhachHang.grid_dsKhachHang.SelectedRows)
                    {
                        KhachHangBUS khachhang = (KhachHangBUS)row.DataBoundItem;

                        dsThemMoi.Add(khachhang);

                        flag = doan.ThemKhachHang(khachhang);
                        if (!flag) break;
                    }

                    if (flag)
                    {
                        doan.DsKhachHang.AddRange(dsThemMoi);
                        loadKhachHangByDoan(doan.DsKhachHang);
                    }
                    else
                    {
                        MessageBox.Show("Thêm khách hàng thất bại", "Thông báo");
                    }
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

                bool flag = true;

                //Xóa từng khách hàng được chọn
                foreach (DataGridViewRow row in grid_dsKhachHang.SelectedRows)
                {
                    KhachHangBUS khachhang = (KhachHangBUS)row.DataBoundItem;

                    doan.DsKhachHang.Remove(khachhang);

                    flag = doan.XoaKhachHang(khachhang);
                    if (!flag) break;
                }
                if (flag)
                {
                    loadKhachHangByDoan(doan.DsKhachHang);
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng thất bại", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn khách hàng để xóa", "Thông báo");
            }
        }
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
                    bool flag = true;
                    List<NhanVienBUS> dsThemMoi = new List<NhanVienBUS>();
                    foreach (DataGridViewRow row in formNhanVien.grid_dsNhanVien.SelectedRows)
                    {
                        NhanVienBUS nhanvien = (NhanVienBUS)row.DataBoundItem;
                        dsThemMoi.Add(nhanvien);

                        //Thêm danh sách nhân viên vào cơ sở dữ liệu
                        flag = doan.ThemNhanVien(nhanvien);
                        if (!flag)
                            break;
                    }
                    if (flag)
                    {
                        //Thêm vào danh sách nhân viên của đoàn đang chọn và hiển thị lại giao diện
                        doan.DsNhanVien.AddRange(dsThemMoi);
                        loadNhanVienByDoan(doan.DsNhanVien);
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên thất bại", "Thông báo");
                    }
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
                loadNhanVienByDoan(doan.DsNhanVien);

            }
            else
            {
                MessageBox.Show("Chưa chọn nhân viên để xóa", "Thông báo");
            }
        }
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

            }
        }
        private void btn_ThemChiPhi_Click(object sender, EventArgs e)
        {

            if (grid_dsDoan.SelectedRows.Count > 0)
            {
                DoanBUS doan = (DoanBUS)grid_dsDoan.CurrentRow.DataBoundItem;

                //Lấy chi phí từ giao diện
                ChiPhiBUS chiphi = getChiPhi();
                if ((chiphi.Thoigian.Date < doan.NgayBatDau.Date) || (chiphi.Thoigian.Date > doan.NgayKetThuc.Date))
                    MessageBox.Show("Ngoài thời gian của đoàn", "Thông báo");
                else if (doan.ThemChiPhi(chiphi))
                {
                    //Thêm vào đoàn đang chọn và hiển thị lại giao diện
                    doan.DsChiPhi.Add(chiphi);
                    loadChiPhi(doan.DsChiPhi);
                }
                else
                {
                    MessageBox.Show("Thêm chi phí thất bại", "Thông báo");
                }
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

                bool flag = true;
                //Xóa từng chi phí được chọn
                foreach (DataGridViewRow row in grid_dsChiPhi.SelectedRows)
                {
                    ChiPhiBUS chiphi = (ChiPhiBUS)row.DataBoundItem;

                    doan.DsChiPhi.Remove(chiphi);

                    //Xóa trong cơ sở dữ liệu
                    flag = chiphi.Xoa();
                    if (!flag)
                        break;
                }
                if (flag)
                    loadChiPhi(doan.DsChiPhi);
                else
                    MessageBox.Show("Xóa chi phí thất bại", "Thông báo");
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

                if (chiphimoi.Thoigian < doan.NgayBatDau || chiphimoi.Thoigian > doan.NgayKetThuc)
                    MessageBox.Show("Ngoài thời gian của đoàn", "Thông báo");
                else if (chiphicu.Sua())
                    //Hiển thị lại giao diện
                    loadChiPhi(doan.DsChiPhi);
                else
                    MessageBox.Show("Sửa chi phí thất bại", "Thông báo");

            }
            else
            {
                MessageBox.Show("Chọn 1 chi phí để sửa", "Thông báo");
            }
        }
        private void grid_qlNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_qlNhanVien.SelectedRows.Count > 0)
            {
                NhanVienBUS nhanvien = (NhanVienBUS)grid_qlNhanVien.CurrentRow.DataBoundItem;

                txt_maNhanVien.Text = nhanvien.MaNhanVien;
                txt_tenNhanVien.Text = nhanvien.TenNhanVien;
                txt_diachiNhanVien.Text = nhanvien.Diachi;
                txt_sdtNhanVien.Text = nhanvien.Sdt;
                txt_cmndNhanVien.Text = nhanvien.Cmnd;
                cb_ChucVu.SelectedValue = nhanvien.Chucvu.MaChucVu;
                if (nhanvien.Gioitinh.Equals("Nam"))
                    rd_namNhanVien.Checked = true;
                else
                    rd_nuNhanVien.Checked = true;

            }
        }
        private void btn_themmoiNhanVien_Click(object sender, EventArgs e)
        {
            List<NhanVienBUS> dsNhanVien = (List<NhanVienBUS>)grid_qlNhanVien.DataSource;


            NhanVienBUS nhanvien = getNhanVien();

            if (!String.IsNullOrEmpty(nhanvien.MaNhanVien.Trim()))
            {
                if (nhanvien.them())
                {
                    dsNhanVien.Add(nhanvien);
                    loadNhanVien(dsNhanVien);
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại");
                }
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại");
            }
        }
        private void btn_xoaboNhanVien_Click(object sender, EventArgs e)
        {
            if (grid_qlNhanVien.SelectedRows.Count > 0)
            {
                List<NhanVienBUS> dsNhanVien = (List<NhanVienBUS>)grid_qlNhanVien.DataSource;


                NhanVienBUS nhanvien = (NhanVienBUS)grid_qlNhanVien.CurrentRow.DataBoundItem;

                if (nhanvien.xoa())
                {
                    dsNhanVien.Remove(nhanvien);
                    loadNhanVien(dsNhanVien);
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại");
                }
            }
            else
            {
                MessageBox.Show("Chọn nhân viên để xóa");
            }
        }
        private void btn_suaNhanVien_Click(object sender, EventArgs e)
        {
            if (grid_qlNhanVien.SelectedRows.Count > 0)
            {
                List<NhanVienBUS> dsNhanVien = (List<NhanVienBUS>)grid_qlNhanVien.DataSource;


                NhanVienBUS nhanvienmoi = getNhanVien();


                NhanVienBUS nhanviencu = (NhanVienBUS)grid_qlNhanVien.CurrentRow.DataBoundItem;

                if (nhanviencu.sua(nhanvienmoi))
                {
                    //Đặt tất cả thông tin của đoàn cũ thành đoàn mới
                    nhanviencu.MaNhanVien = nhanvienmoi.MaNhanVien;
                    nhanviencu.TenNhanVien = nhanvienmoi.TenNhanVien;
                    nhanviencu.Sdt = nhanvienmoi.Sdt;
                    nhanviencu.Gioitinh = nhanvienmoi.Gioitinh;
                    nhanviencu.Chucvu = nhanvienmoi.Chucvu;
                    nhanviencu.Diachi = nhanvienmoi.Diachi;
                    nhanviencu.Cmnd = nhanvienmoi.Cmnd;
                    loadNhanVien(dsNhanVien);

                }
                else
                {
                    MessageBox.Show("Sửa nhân viên thất bại", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Chọn 1 nhân viên để sửa", "Thông báo");
            }

        }
        private void grid_qlKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (grid_qlKhachHang.SelectedRows.Count > 0)
            {
                KhachHangBUS khachang = (KhachHangBUS)grid_qlKhachHang.CurrentRow.DataBoundItem;

                txt_maKhachHang.Text = khachang.MaKhachHang;
                txt_tenKhachHang.Text = khachang.TenKhachHang;
                txt_diachiKhachHang.Text = khachang.Diachi;
                txt_sdtKhachHang.Text = khachang.Sdt;
                txt_cmndKhachHang.Text = khachang.Cmnd;
                if (khachang.Gioitinh.Equals("Nam"))
                    rd_namKhachHang.Checked = true;
                else
                    rd_nuNhanVien.Checked = true;

            }
        }
        private void btn_themmoiKhachHang_Click(object sender, EventArgs e)
        {
            List<KhachHangBUS> dsKhachHang = (List<KhachHangBUS>)grid_qlKhachHang.DataSource;


            KhachHangBUS khachhang = getKhachHang();

            if (!String.IsNullOrEmpty(khachhang.MaKhachHang.Trim()))
            {
                if (khachhang.them())
                {
                    dsKhachHang.Add(khachhang);
                    loadKhachHang(dsKhachHang);
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại");
                }
            }
            else
            {
                MessageBox.Show("Thêm Khach hang thất bại");
            }
        }
        private void btn_xoaboKhachHang_Click(object sender, EventArgs e)
        {
            if (grid_qlKhachHang.SelectedRows.Count > 0)
            {
                List<KhachHangBUS> dsKhachHang = (List<KhachHangBUS>)grid_qlKhachHang.DataSource;

                KhachHangBUS khachang = (KhachHangBUS)grid_qlKhachHang.CurrentRow.DataBoundItem;

                if (khachang.xoa())
                {
                    dsKhachHang.Remove(khachang);
                    loadKhachHang(dsKhachHang);
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng thất bại");
                }
            }
            else
            {
                MessageBox.Show("Chọn Khách hàng để xóa");
            }
        }
        private void btn_suaKhachHang_Click(object sender, EventArgs e)
        {
            if (grid_qlKhachHang.SelectedRows.Count > 0)
            {
                List<KhachHangBUS> dsKhachHang = (List<KhachHangBUS>)grid_qlKhachHang.DataSource;


                KhachHangBUS khachhangmoi = getKhachHang();


                KhachHangBUS khachhangcu = (KhachHangBUS)grid_qlKhachHang.CurrentRow.DataBoundItem;

                if (khachhangcu.sua(khachhangmoi))
                {
                    //Đặt tất cả thông tin của đoàn cũ thành đoàn mới
                    khachhangcu.MaKhachHang = khachhangmoi.MaKhachHang;
                    khachhangcu.TenKhachHang = khachhangmoi.TenKhachHang;
                    khachhangcu.Sdt = khachhangmoi.Sdt;
                    khachhangcu.Gioitinh = khachhangmoi.Gioitinh;
                    khachhangcu.Diachi = khachhangmoi.Diachi;
                    khachhangcu.Cmnd = khachhangmoi.Cmnd;
                    loadKhachHang(dsKhachHang);

                }
                else
                {
                    MessageBox.Show("Sửa nhân viên thất bại", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Chọn 1 nhân viên để sửa", "Thông báo");
            }
        }
        private void btn_thongkeTour_Click(object sender, EventArgs e)
        {
            DateTime ngaybd = datetime_bdThongketour.Value;
            DateTime ngaykt = datetime_ktThongketour.Value;

            if (ngaybd <= ngaykt)
                loadThongKeTour(TourDAO.ThongKeDoanhThu(ngaybd, ngaykt));
            else
            {
                MessageBox.Show("Ngày bắt đầu không lớn hơn ngày kết thúc");
            }
        }
        private void btn_thongkeDoan_Click(object sender, EventArgs e)
        {
            DateTime ngaybd = datetime_bdThongkedoan.Value;
            DateTime ngaykt = datetime_ktThongkedoan.Value;
            if (ngaybd <= ngaykt)
            {
                String matour = (string)comboBox_ThongkeTour.SelectedValue;
                loadThongKeDoan(DoanDAO.ThongKeDoanhThu(matour, ngaybd, ngaykt));
            }
            else
            {
                MessageBox.Show("Ngày bắt đầu không lớn hơn ngày kết thúc");
            }
        }
        private void grid_thongkeTour_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DateTime ngaybd = datetime_bdThongkedoan.Value;
            DateTime ngaykt = datetime_ktThongkedoan.Value;
            if (grid_thongkeTour.SelectedRows.Count > 0)
            {
                if (ngaybd <= ngaykt)
                {
                    String matour = grid_thongkeTour.CurrentRow.Cells[0].Value.ToString();
                    loadThongKeChiPhi(TourDAO.ThongKeChiPhi(matour, ngaybd, ngaykt));
                }
                else
                {
                    MessageBox.Show("Ngày bắt đầu không lớn hơn ngày kết thúc");
                }
            }
        }
        private void btn_thongkeSoLanDiTour_Click(object sender, EventArgs e)
        {
            DateTime ngaybd = datetime_bdThongkesolandi.Value;
            DateTime ngaykt = datetime_ktThongkesolandi.Value;
            if (ngaybd <= ngaykt)
                loadThongKeSoLanDiTour(NhanVienDAO.ThongKeSoLanDi(ngaybd, ngaykt));
            else
            {
                MessageBox.Show("Ngày bắt đầu không lớn hơn ngày kết thúc");
            }

        }
        private void btn_timkiemDoan_Click(object sender, EventArgs e)
        {
            List<DoanBUS> dsDoan = DoanDAO.timkiemDoan(txt_timkiemDoan.Text);
            foreach (DoanBUS doan in dsDoan)
            {
                doan.DsChiPhi = ChiPhiBUS.getChiPhiByDoan(doan);
                doan.DsKhachHang = KhachHangBUS.getKhachHangByDoan(doan);
                doan.DsNhanVien = NhanVienBUS.getNhanVienByDoan(doan);
            }
            loadDoan(dsDoan);
        }
        private void btn_timkiemKhachHangTrongDoan_Click(object sender, EventArgs e)
        {
            if (grid_dsDoan.SelectedRows.Count > 0)
            {
                DoanBUS doan = (DoanBUS)grid_dsDoan.CurrentRow.DataBoundItem;
                String keyword = txt_timkiemKhachHangTrongDoan.Text;
                loadKhachHangByDoan(KhachHangDAO.timkiemKhachHangTrongDoan(doan, keyword));
            }
            else
            {
                MessageBox.Show("Chọn đoàn để tìm kiếm", "Thông báo");
            }

        }
        private void btn_timkiemNhanVienTrongDoan_Click(object sender, EventArgs e)
        {
            if (grid_dsDoan.SelectedRows.Count > 0)
            {
                DoanBUS doan = (DoanBUS)grid_dsDoan.CurrentRow.DataBoundItem;
                String keyword = txt_timkiemNhanVienTrongDoan.Text;
                loadNhanVienByDoan(NhanVienDAO.timkiemNhanVienTrongDoan(doan, keyword));
            }
            else
            {
                MessageBox.Show("Chọn đoàn để tìm kiếm", "Thông báo");
            }
        }
        private void btn_timkiemKhachHang_Click(object sender, EventArgs e)
        {
            loadKhachHang(KhachHangDAO.timkiemKhachHang(txt_timkiemKhachHang.Text));
        }

        private void btn_timkiemNhanVien_Click(object sender, EventArgs e)
        {
            loadNhanVien(NhanVienDAO.timkiemNhanVien(txt_timkiemNhanVien.Text));

        }
        private void btn_timkiemTour_Click(object sender, EventArgs e)
        {
            loadTour(TourDAO.timkiemTour(txt_timkiemTour.Text));
        }
        #endregion

        #region Hiển thị giao diện

        void loadTour(List<TourBUS> dsTour)
        {
            grid_dsTour.DataSource = null;
            grid_dsTour.DataSource = dsTour;
            grid_dsTour.Columns["giaHienTai"].Visible = false;
            grid_dsTour.Columns["doanhthu"].Visible = false;
            grid_dsTour.Columns["maTour"].HeaderText = "Mã tour";
            grid_dsTour.Columns["tenTour"].HeaderText = "Tên tour";
            grid_dsTour.Columns["loaiTour"].HeaderText = "Loại tour";

            grid_dsTour.Columns["maTour"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid_dsTour.Columns["tenTour"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_dsTour.Columns["loaiTour"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            grid_dsTour.ClearSelection();


            loadCbTour(dsTour);
            loadCbThongKeTour(dsTour);

        }
        void loadLoaiTour(List<LoaiTourBUS> dsLoaiTour)
        {
            comboBox_loaiTour.DataSource = dsLoaiTour;
            comboBox_loaiTour.DisplayMember = "tenLoai";
            comboBox_loaiTour.ValueMember = "maLoai";
        }
        void loadDiaDiemByTour(List<DiaDiemBUS> diadiem)
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
        void loadDiaDiem(List<DiaDiemBUS> dsDiaDiem)
        {
            listBox_dsDiaDiem.Items.Clear();
            foreach (DiaDiemBUS item in dsDiaDiem)
            {
                listBox_dsDiaDiem.Items.Add(item);
            }
        }
        void loadGia(List<GiaBUS> dsGia)
        {
            grid_dsGia.DataSource = null;
            if (dsGia.Count > 0)
            {
                grid_dsGia.DataSource = dsGia;
                grid_dsGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grid_dsGia.Columns["id"].Visible = false;
                grid_dsGia.Columns["maTour"].Visible = false;
                grid_dsGia.Columns["ngayBatDau"].HeaderText = "Ngày bắt đầu";
                grid_dsGia.Columns["ngayKetThuc"].HeaderText = "Ngày kết thúc";
                grid_dsGia.Columns["tien"].HeaderText = "Số tiền";

                grid_dsGia.Columns["tien"].DefaultCellStyle.Format = "N0";
                grid_dsGia.Columns["ngayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
                grid_dsGia.Columns["ngayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";
                grid_dsGia.ClearSelection();
            }
        }
        void loadGiaHienTai(GiaBUS gia)
        {
            txt_Gia.Value = gia.Tien;
            datetime_batdauGia.Value = gia.NgayBatDau;
            datetime_ketthucGia.Value = gia.NgayKetThuc;
        }
        void loadDoan(List<DoanBUS> dsDoan)
        {
            grid_dsDoan.DataSource = null;
            grid_dsDoan.DataSource = dsDoan;

            grid_dsDoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            grid_dsDoan.Columns["tenDoan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_dsDoan.Columns["tour"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grid_dsDoan.Columns["ngayBatDau"].DefaultCellStyle.Format = "dd /MM/yyyy";
            grid_dsDoan.Columns["ngayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";

            grid_dsDoan.Columns["maDoan"].HeaderText = "Mã đoàn";
            grid_dsDoan.Columns["tenDoan"].HeaderText = "Tên đoàn";
            grid_dsDoan.Columns["tour"].HeaderText = "Tên tour";
            grid_dsDoan.Columns["ngayBatDau"].HeaderText = "Ngày bắt đầu";
            grid_dsDoan.Columns["ngayKetThuc"].HeaderText = "Ngày kết thúc";
            grid_dsDoan.ClearSelection();

            loadChiPhi(null);
            loadKhachHangByDoan(null);
            loadNhanVienByDoan(null);
        }
        void loadChiPhi(List<ChiPhiBUS> dsChiPhi)
        {

            grid_dsChiPhi.DataSource = null;
            if (dsChiPhi != null && dsChiPhi.Count > 0)
            {
                grid_dsChiPhi.DataSource = dsChiPhi;
                grid_dsChiPhi.Columns["maChiphi"].Visible = false;
                grid_dsChiPhi.Columns["tien"].DefaultCellStyle.Format = "N0";
                grid_dsChiPhi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                grid_dsChiPhi.Columns["tien"].HeaderText = "Tiền";
                grid_dsChiPhi.Columns["loaichiphi"].HeaderText = "Loại chi phí";
                grid_dsChiPhi.Columns["thoigian"].HeaderText = "Thời gian";


                grid_dsChiPhi.ClearSelection();

            }
            //Xóa dữ liệu chi phí
            txt_sotien.Value = 0;
            datetime_thoigian.Value = DateTime.Now;
        }
        void loadLoaiChiPhi(List<LoaiChiPhiBUS> dsLoaiChiPhi)
        {
            comboBox_loaiChiPhi.DataSource = dsLoaiChiPhi;
            comboBox_loaiChiPhi.DisplayMember = "tenLoaiChiPhi";
            comboBox_loaiChiPhi.ValueMember = "maLoaiChiPhi";
        }
        void loadNhanVien(List<NhanVienBUS> dsNhanVien)
        {
            grid_qlNhanVien.DataSource = null;
            grid_qlNhanVien.DataSource = dsNhanVien;
            grid_qlNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grid_qlNhanVien.Columns["manhanvien"].HeaderText = "Mã nhân viên";
            grid_qlNhanVien.Columns["tennhanvien"].HeaderText = "Họ tên";
            grid_qlNhanVien.Columns["sdt"].HeaderText = "Số điện thoại";
            grid_qlNhanVien.Columns["gioitinh"].HeaderText = "Giới tính";
            grid_qlNhanVien.Columns["cmnd"].HeaderText = "CMND";
            grid_qlNhanVien.Columns["diachi"].HeaderText = "Địa chỉ";
            grid_qlNhanVien.Columns["chucvu"].HeaderText = "Chức vụ";

            grid_qlNhanVien.ClearSelection();

        }
        void loadKhachHang(List<KhachHangBUS> dsKhachHang)
        {
            grid_qlKhachHang.DataSource = null;
            grid_qlKhachHang.DataSource = dsKhachHang;
            grid_qlKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid_qlKhachHang.Columns["doan"].Visible = false;

            grid_qlKhachHang.Columns["makhachhang"].HeaderText = "Mã khách hàng";
            grid_qlKhachHang.Columns["tenkhachhang"].HeaderText = "Họ tên";
            grid_qlKhachHang.Columns["sdt"].HeaderText = "Số điện thoại";
            grid_qlKhachHang.Columns["gioitinh"].HeaderText = "Giới tính";
            grid_qlKhachHang.Columns["cmnd"].HeaderText = "CMND";
            grid_qlKhachHang.Columns["diachi"].HeaderText = "Địa chỉ";

            grid_qlKhachHang.ClearSelection();

        }
        void loadKhachHangByDoan(List<KhachHangBUS> dsKhachHang)
        {
            grid_dsKhachHang.DataSource = null;
            if (dsKhachHang != null && dsKhachHang.Count > 0)
            {
                grid_dsKhachHang.DataSource = dsKhachHang;
                grid_dsKhachHang.Columns["doan"].Visible = false;
                grid_dsKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                grid_dsKhachHang.Columns["makhachhang"].HeaderText = "Mã khách hàng";
                grid_dsKhachHang.Columns["tenkhachhang"].HeaderText = "Họ tên";
                grid_dsKhachHang.Columns["sdt"].HeaderText = "Số điện thoại";
                grid_dsKhachHang.Columns["gioitinh"].HeaderText = "Giới tính";
                grid_dsKhachHang.Columns["cmnd"].HeaderText = "CMND";
                grid_dsKhachHang.Columns["diachi"].HeaderText = "Địa chỉ";

                grid_dsKhachHang.ClearSelection();
            }

        }
        void loadNhanVienByDoan(List<NhanVienBUS> dsNhanVien)
        {
            grid_dsNhanVien.DataSource = null;
            if (dsNhanVien != null && dsNhanVien.Count > 0)
            {
                grid_dsNhanVien.DataSource = dsNhanVien;
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
        }
        void loadCbTour(List<TourBUS> dsTour)
        {
            comboBox_Tour.DataSource = null;
            comboBox_Tour.DataSource = dsTour;
            comboBox_Tour.DisplayMember = "tenTour";
            comboBox_Tour.ValueMember = "maTour";
        }
        void loadCbThongKeTour(List<TourBUS> dsTour)
        {
            comboBox_ThongkeTour.DataSource = null;
            comboBox_ThongkeTour.DataSource = dsTour;
            comboBox_ThongkeTour.DisplayMember = "tenTour";
            comboBox_ThongkeTour.ValueMember = "maTour";
        }
        void loadCbChucVu(List<ChucVuBUS> dsChucVu)
        {
            cb_ChucVu.DataSource = null;
            cb_ChucVu.DataSource = dsChucVu;
            cb_ChucVu.DisplayMember = "tenChucVu";
            cb_ChucVu.ValueMember = "maChucVu";
        }
        void loadThongKeTour(DataTable table)
        {
            grid_thongkeTour.DataSource = null;
            grid_thongkeTour.DataSource = table;
            grid_thongkeTour.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid_thongkeTour.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_thongkeTour.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_thongkeTour.Columns[4].DefaultCellStyle.Format = "N0";
            grid_thongkeTour.Columns[5].DefaultCellStyle.Format = "N0";
            grid_thongkeTour.Columns[6].DefaultCellStyle.Format = "N0";

        }
        void loadThongKeDoan(DataTable table)
        {
            grid_thongkeDoan.DataSource = null;
            grid_thongkeDoan.DataSource = table;
            grid_thongkeDoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid_thongkeDoan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_thongkeDoan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_thongkeDoan.Columns[3].DefaultCellStyle.Format = "N0";
            grid_thongkeDoan.Columns[4].DefaultCellStyle.Format = "N0";
            grid_thongkeDoan.Columns[5].DefaultCellStyle.Format = "N0";
            grid_thongkeDoan.Columns[6].DefaultCellStyle.Format = "N0";

        }
        void loadThongKeChiPhi(Hashtable table)
        {
            chart_thongkechiphi.Series[0].Points.Clear();
            foreach (DictionaryEntry item in table)
            {
                chart_thongkechiphi.Series[0].Points.AddXY(item.Key, item.Value);
            }
        }
        void loadThongKeSoLanDiTour(DataTable table)
        {
            grid_thongkesolanditour.DataSource = null;
            grid_thongkesolanditour.DataSource = table;
            grid_thongkesolanditour.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid_thongkesolanditour.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_thongkesolanditour.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
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
        TourBUS getTour()
        {
            TourBUS tour = new TourBUS();

            tour.MaTour = txt_maTour.Text;
            tour.TenTour = txt_tenTour.Text;
            tour.LoaiTour = (LoaiTourBUS)comboBox_loaiTour.SelectedItem;

            return tour;
        }
        NhanVienBUS getNhanVien()
        {
            NhanVienBUS nhanvien = new NhanVienBUS();

            nhanvien.MaNhanVien = txt_maNhanVien.Text;
            nhanvien.TenNhanVien = txt_tenNhanVien.Text;
            nhanvien.Diachi = txt_diachiNhanVien.Text;
            nhanvien.Sdt = txt_sdtNhanVien.Text;
            nhanvien.Cmnd = txt_cmndNhanVien.Text;
            nhanvien.Chucvu = (ChucVuBUS)cb_ChucVu.SelectedItem;
            if (rd_namNhanVien.Checked)
                nhanvien.Gioitinh = "Nam";
            else
                nhanvien.Gioitinh = "Nữ";


            return nhanvien;
        }
        KhachHangBUS getKhachHang()
        {
            KhachHangBUS khachhang = new KhachHangBUS();

            khachhang.MaKhachHang = txt_maKhachHang.Text;
            khachhang.TenKhachHang = txt_tenKhachHang.Text;
            khachhang.Diachi = txt_diachiKhachHang.Text;
            khachhang.Sdt = txt_sdtKhachHang.Text;
            khachhang.Cmnd = txt_cmndKhachHang.Text;
            if (rd_namKhachHang.Checked)
                khachhang.Gioitinh = "Nam";
            else
                khachhang.Gioitinh = "Nữ";


            return khachhang;
        }

        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //grid_dsDoan.ClearSelection();

        }

        private void grid_dsChiPhi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            gridView.ClearSelection();
        }


    }
}
