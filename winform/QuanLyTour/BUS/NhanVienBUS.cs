using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTour.BUS
{
    public class NhanVienBUS
    {
        #region Properties
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
        #endregion

        #region Get set
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Quoctich { get => quoctich; set => quoctich = value; }
        public ChucVuBUS Chucvu { get => chucvu; set => chucvu = value; }

        #endregion

        #region Function
        public static List<NhanVienBUS> getNhanVienByDoan(DoanBUS doan)
        {
            return DAO.NhanVienDAO.getNhanVienByDoan(doan);
        }


        public void XoaNhanVienByDoan(DoanBUS doan)
        {
            DAO.NhanVienDAO.XoaNhanVienByDoan(this, doan);
        }

        public void Them(DoanBUS doan)
        {
            DAO.NhanVienDAO.Them(this, doan);
        }
        #endregion





    }
}
