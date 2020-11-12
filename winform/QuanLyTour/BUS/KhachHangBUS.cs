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
        #region Properties
        private String maKhachHang;
        private String tenKhachHang;
        private String cmnd;
        private String diachi;
        private String sdt;
        private String gioitinh;
        private String quoctich;

        DoanBUS doan;
        public KhachHangBUS()
        {
            doan = new DoanBUS();
        }
        #endregion

        #region Get set
        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Quoctich { get => quoctich; set => quoctich = value; }
        public DoanBUS Doan { get => doan; set => doan = value; }
        #endregion

        #region Function
        public static List<KhachHangBUS> getKhachHangByDoan(DoanBUS doan)
        {
            return DAO.KhachHangDAO.getKhachHangByDoan(doan);
        }
        public static List<KhachHangBUS> getKhachHangKhongCoDoan(DoanBUS doan)
        {
            return DAO.KhachHangDAO.getKhachHangKhongCoDoan(doan);
        }
        public static void ThemKhachHangDoan(DoanBUS doan, List<KhachHangBUS> dsKhachHang)
        {
            DAO.KhachHangDAO.ThemKhachHangDoan(doan, dsKhachHang);
        }
       
        public void Xoa(DoanBUS doan)
        {
            DAO.KhachHangDAO.Xoa(this, doan);
        }

        public void Them(DoanBUS doan)
        {
            DAO.KhachHangDAO.Them(this, doan);
        }
        #endregion




    }
}
