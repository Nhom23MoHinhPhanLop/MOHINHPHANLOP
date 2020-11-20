using QuanLyTour.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTour.BUS
{
    public class KhachHangBUS
    {

        private String maKhachHang;
        private String tenKhachHang;
        private String cmnd;
        private String diachi;
        private String sdt;
        private String gioitinh;

        DoanBUS doan;
        public KhachHangBUS()
        {
            doan = new DoanBUS();
        }

        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public DoanBUS Doan { get => doan; set => doan = value; }

        public static List<KhachHangBUS> getKhachHangByDoan(DoanBUS doan)
        {
            return DAO.KhachHangDAO.getKhachHangByDoan(doan);
        }
        public static List<KhachHangBUS> getKhachHangKhongCoDoan(DoanBUS doan)
        {
            return DAO.KhachHangDAO.getKhachHangKhongCoDoan(doan);
        }


        public bool XoaKhoiDoan(DoanBUS doan)
        {
            return KhachHangDAO.XoaKhoiDoan(this, doan);
        }

        public bool ThemVaoDoan(DoanBUS doan)
        {
            return KhachHangDAO.ThemVaoDoan(this, doan);
        }

        public bool KiemTraTonTai()
        {
            return KhachHangDAO.KiemTraTonTai(this);
        }
        public bool them()
        {

            return !KiemTraTonTai() && KhachHangDAO.them(this);

        }
        public bool xoa()
        {
            return KhachHangDAO.xoa(this);
        }
        public bool sua(KhachHangBUS khachhangmoi)
        {
            if (khachhangmoi.KiemTraTonTai() && this.MaKhachHang != khachhangmoi.MaKhachHang)
                return false;
            return KhachHangDAO.sua(this, khachhangmoi);
        }




    }
}
