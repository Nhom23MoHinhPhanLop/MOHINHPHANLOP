using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override bool Equals(object obj)
        {
            return obj.ToString() == this.ToString();
        }

        public override string ToString()
        {
            return MaDoan;
        }
        public void setData()
        {
            //this.DsNhanVien = NhanVienBUS.getNhanVienByDoan(this);
            //this.DsKhachHang = BUS.KhachHangBUS.getKhachHangByDoan(this);
            //this.DsChiPhi = BUS.ChiPhiBUS.getChiPhiByDoan(this);

        }

        public List<NhanVienBUS> getNhanVienKhongCoDoan()
        {
            return DAO.NhanVienDAO.getNhanVienKhongCoDoan(this);
        }
    }
}
