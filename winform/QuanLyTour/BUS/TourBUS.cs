
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
        private long doanhthu = 0;
        public TourBUS()
        {
            maTour = "";
            tenTour = "";
            loaiTour = new LoaiTourBUS();
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
        public long Doanhthu { get => doanhthu; set => doanhthu = value; }

        public bool isExist()
        {
            return TourDAO.kiemtraTourTonTai(this);
        }
        public void getGiaHienTai()
        {
            this.GiaHienTai = GiaDAO.getGiaHienTai(this);
        }

        public bool Them()
        {
            return !isExist() && TourDAO.Them(this);
        }
        public bool Xoa()
        {
            return TourDAO.Xoa(this);
        }
        public bool Sua(TourBUS tourmoi)
        {
            if (tourmoi.isExist() && this.MaTour != tourmoi.MaTour)
                return false;
            return TourDAO.Sua(this, tourmoi);
        }

        public void ThemDiaDiem(DiaDiemBUS diadiem)
        {
            this.dsDiaDiem.Add(diadiem);

            diadiem.ThemVaoTour(this);
        }
        public void XoaDiaDiem(DiaDiemBUS diadiem)
        {
            this.dsDiaDiem.Remove(diadiem);

            diadiem.XoaTrongTour(this);
        }
        public bool ThemGia(GiaBUS gia)
        {
            bool result = gia.Them();
            if (result)
            {
                this.dsGia.Add(gia);
                getGiaHienTai();
            }
            return result;
        }
        public bool XoaGia(GiaBUS gia)
        {
            bool result = gia.Xoa();
            if (result)
            {
                this.dsGia.Remove(gia);

                getGiaHienTai();

            }
            return result;
        }
        public bool SuaGia(GiaBUS gia)
        {
            bool result = gia.Sua();
            if (result)
            {
                for (int i = 0; i < this.dsGia.Count; i++)
                {
                    if (dsGia[i].Id == gia.Id)
                    {
                        this.dsGia[i] = gia;
                        break;
                    }
                }
                getGiaHienTai();

            }
            return result;
        }


        public override string ToString()
        {
            return this.TenTour;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
