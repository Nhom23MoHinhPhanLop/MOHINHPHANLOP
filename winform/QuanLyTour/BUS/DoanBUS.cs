using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTour.BUS
{
    public class DoanBUS
    {
        #region Properties
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
            dsNhanVien = new List<NhanVienBUS>();
            dsKhachHang = new List<KhachHangBUS>();
            dsChiPhi = new List<ChiPhiBUS>();
            tour = new TourBUS();
        }
        #endregion

        #region Get set


        public string MaDoan { get => maDoan; set => maDoan = value; }
        public string TenDoan { get => tenDoan; set => tenDoan = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public List<ChiPhiBUS> DsChiPhi { get => dsChiPhi; set => dsChiPhi = value; }
        public List<KhachHangBUS> DsKhachHang { get => dsKhachHang; set => dsKhachHang = value; }
        public List<NhanVienBUS> DsNhanVien { get => dsNhanVien; set => dsNhanVien = value; }
        public TourBUS Tour { get => tour; set => tour = value; }
        #endregion

        #region Override

        public override bool Equals(object obj)
        {
            return obj.ToString() == this.ToString();
        }

        public override string ToString()
        {
            return MaDoan;
        }

        #endregion



        #region Function

        public List<NhanVienBUS> getNhanVienKhongCoDoan()
        {
            return DAO.NhanVienDAO.getNhanVienKhongCoDoan(this);
        }
        public void XoaNhanVien(NhanVienBUS nhanvien)
        {
            nhanvien.XoaNhanVienByDoan(this);
        }
        public void ThemNhanVien(NhanVienBUS nhanvien)
        {
            nhanvien.Them(this);
        }
        public void XoaKhachHang(KhachHangBUS khachhang)
        {
            khachhang.Xoa(this);
        }
        public void ThemKhachHang(KhachHangBUS khachhang)
        {
            khachhang.Them(this);
        }
        public void ThemChiPhi(ChiPhiBUS chiphi)
        {

            chiphi.Them(this);

        }
        public void XoaChiPhi(ChiPhiBUS chiphi)
        {
            chiphi.Xoa();
        }
        public void SuaChiPhi(ChiPhiBUS chiphi)
        {
            chiphi.Sua();
        }


        public bool KiemTraTonTai()
        {
            return DAO.DoanDAO.KiemTraTonTai(this);
        }
        public void Them()
        {
            DAO.DoanDAO.Them(this);
        }
        public void Xoa()
        {
            DAO.DoanDAO.Xoa(this);
        }
        public void Sua(DoanBUS doanmoi)
        {
            DAO.DoanDAO.Sua(this, doanmoi);
        }
        #endregion
    }
}
