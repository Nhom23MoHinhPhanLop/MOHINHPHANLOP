using QuanLyTour.DAO;
using System;

namespace QuanLyTour.BUS
{
    public class DiaDiemBUS
    {
        private String maDiaDiem;
        private String tenDiaDiem;
        private String diaphuong;
        public string MaDiaDiem { get => maDiaDiem; set => maDiaDiem = value; }
        public string TenDiaDiem { get => tenDiaDiem; set => tenDiaDiem = value; }
        public string Diaphuong { get => diaphuong; set => diaphuong = value; }

        public override string ToString()
        {
            return maDiaDiem;
        }
        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }

        public void ThemVaoTour(TourBUS tour)
        {
            DiaDiemDAO.ThemVaoTour(this, tour);
        }
        public void XoaTrongTour(TourBUS tour)
        {
            DiaDiemDAO.XoaTrongTour(this, tour);
        }
    }
}
