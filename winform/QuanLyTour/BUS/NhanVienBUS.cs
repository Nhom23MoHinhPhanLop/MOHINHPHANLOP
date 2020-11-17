using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTour.DAO;

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
        public ChucVuBUS Chucvu { get => chucvu; set => chucvu = value; }

        public static List<NhanVienBUS> getNhanVienByDoan(DoanBUS doan)
        {
            return DAO.NhanVienDAO.getNhanVienByDoan(doan);
        }

        public bool XoaKhoiDoan(DoanBUS doan)
        {
            return NhanVienDAO.XoaKhoiDoan(this, doan);
        }
        public bool ThemVaoDoan(DoanBUS doan)
        {
            return NhanVienDAO.ThemVaoDoan(this, doan);
        }
        public bool KiemTraTonTai()
        {
            return NhanVienDAO.KiemTraTonTai(this);
        }
        public bool them()
        {

            return !KiemTraTonTai() && NhanVienDAO.them(this);

        }
        public bool xoa()
        {
            return NhanVienDAO.xoa(this);
        }
        public bool sua(NhanVienBUS nhanvienmoi)
        {
            if (nhanvienmoi.KiemTraTonTai() && this.MaNhanVien != nhanvienmoi.MaNhanVien)
                return false;
            return NhanVienDAO.sua(this, nhanvienmoi);
        }
    }
}
