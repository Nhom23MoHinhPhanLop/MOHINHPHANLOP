using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTour.BUS
{
    public class NhanVienBUS
    {

        private String maNhanVien;
        private String tenNhanVien;
        private String cmnd;
        private String diachi;
        private String sdt;
        private String gioitinh;
        private String quoctich;
        ChucVuBUS chucvu;
        public NhanVienBUS()
        {
            this.Chucvu = new ChucVuBUS();
        }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Quoctich { get => quoctich; set => quoctich = value; }
        public ChucVuBUS Chucvu { get => chucvu; set => chucvu = value; }
        public static  List<NhanVienBUS> getNhanVienByDoan(DoanBUS doan)
        {
            return DAO.NhanVienDAO.getNhanVienByDoan(doan);
        }

    }
}
