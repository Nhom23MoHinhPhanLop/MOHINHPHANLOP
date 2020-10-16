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
        private String quoctich;
        DoanBUS doan;
        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Quoctich { get => quoctich; set => quoctich = value; }
        public DoanBUS Doan { get => doan; set => doan = value; }
    }
}
