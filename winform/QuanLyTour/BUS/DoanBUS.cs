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
        List<ChiPhi> dsChiPhi;
        List<KhachHangBUS> dsKhachHang;
        List<NhanVienBUS> dsNhanVien;
        TourBUS tour;

        public string MaDoan { get => maDoan; set => maDoan = value; }
        public string TenDoan { get => tenDoan; set => tenDoan = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public List<ChiPhi> DsChiPhi { get => dsChiPhi; set => dsChiPhi = value; }
        public List<KhachHangBUS> DsKhachHang { get => dsKhachHang; set => dsKhachHang = value; }
        public TourBUS Tour { get => tour; set => tour = value; }
        public List<NhanVienBUS> DsNhanVien { get => dsNhanVien; set => dsNhanVien = value; }
    }
}
