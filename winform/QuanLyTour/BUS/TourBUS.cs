
using QuanLyTour.BUS;
using QuanLyTour.DAO;
using System;
using System.Collections.Generic;

namespace QuanLyTour.BUS
{
    public class TourBUS
    {
        private String maTour;
        private String tenTour;
        LoaiTourBUS loaiTour;
        GiaBUS giaHienTai;
        List<GiaBUS> dsGia;
        List<DoanBUS> dsDoan;
        List<DiaDiemBUS> dsDiaDiem;
        public TourBUS()
        {
            dsDiaDiem = new List<DiaDiemBUS>();
            dsDoan = new List<DoanBUS>();
            dsGia = new List<GiaBUS>();
            giaHienTai = new GiaBUS();
        }
        public string MaTour { get => maTour; set => maTour = value; }
        public string TenTour { get => tenTour; set => tenTour = value; }
        public LoaiTourBUS LoaiTour { get => loaiTour; set => loaiTour = value; }
        public List<GiaBUS> DsGia { get => dsGia; set => dsGia = value; }
        public List<DoanBUS> DsDoan { get => dsDoan; set => dsDoan = value; }
        public List<DiaDiemBUS> DsDiaDiem { get => dsDiaDiem; set => dsDiaDiem = value; }
        public GiaBUS GiaHienTai { get => giaHienTai; set => giaHienTai = value; }

        public void Delete()
        {
            TourDAO.XoaTour(this);
        }

        public void ThemMoi()
        {
            if (isExist())
            {
                TourDAO.themTour(this);
                TourDAO.themGiaTour(this);
                TourDAO.themDiaDiemTour(this);
            }
        }
        public bool isExist()
        {
            return TourDAO.kiemtraTourTonTai(this);
        }
    }
}
