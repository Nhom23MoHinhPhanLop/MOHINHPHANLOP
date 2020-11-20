using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTour.DAO;

namespace QuanLyTour.BUS
{
    public class DoanBUS
    {
        private String maDoan;
        private String tenDoan;
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;
        List<ChiPhiBUS> dsChiPhi;
        List<KhachHangBUS> dsKhachHang;
        List<NhanVienBUS> dsNhanVien;
        TourBUS tour;
        public DoanBUS()
        {
            tenDoan = "";
            dsNhanVien = new List<NhanVienBUS>();
            dsKhachHang = new List<KhachHangBUS>();
            dsChiPhi = new List<ChiPhiBUS>();
            tour = new TourBUS();
        }

        public string MaDoan { get => maDoan; set => maDoan = value; }
        public string TenDoan { get => tenDoan; set => tenDoan = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public List<ChiPhiBUS> DsChiPhi { get => dsChiPhi; set => dsChiPhi = value; }
        public List<KhachHangBUS> DsKhachHang { get => dsKhachHang; set => dsKhachHang = value; }
        public List<NhanVienBUS> DsNhanVien { get => dsNhanVien; set => dsNhanVien = value; }
        public TourBUS Tour { get => tour; set => tour = value; }


        public override string ToString()
        {
            return this.TenDoan;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

       
        public bool XoaNhanVien(NhanVienBUS nhanvien)
        {
            return nhanvien.XoaKhoiDoan(this);
        }
        public bool ThemNhanVien(NhanVienBUS nhanvien)
        {
            return nhanvien.ThemVaoDoan(this);
        }
        public bool XoaKhachHang(KhachHangBUS khachhang)
        {
            return khachhang.XoaKhoiDoan(this);
        }
        public bool ThemKhachHang(KhachHangBUS khachhang)
        {
            return khachhang.ThemVaoDoan(this);
        }
        public bool ThemChiPhi(ChiPhiBUS chiphi)
        {

            return chiphi.Them(this);

        }
        public bool XoaChiPhi(ChiPhiBUS chiphi)
        {
            return chiphi.Xoa();
        }
        public bool SuaChiPhi(ChiPhiBUS chiphi)
        {
            return chiphi.Sua();
        }

        public bool KiemTraTonTai()
        {
            return DoanDAO.KiemTraTonTai(this);
        }
        public bool Them()
        {
            return DoanDAO.Them(this) && this.KiemTraTonTai();
        }
        public bool Xoa()
        {
            return DoanDAO.Xoa(this);
        }
        public bool Sua(DoanBUS doanmoi)
        {
            if (doanmoi.KiemTraTonTai() && this.MaDoan != doanmoi.MaDoan)
                return false;
            return DoanDAO.Sua(this, doanmoi);
        }
    }
}
