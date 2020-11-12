﻿
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
            maTour = "";
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


        public bool isExist()
        {
            return TourDAO.kiemtraTourTonTai(this);
        }

        public void Them()
        {
            TourDAO.Them(this);
        }
        public void Xoa()
        {
            TourDAO.Xoa(this);
        }
        public void Sua(TourBUS tourmoi)
        {
            TourDAO.Sua(this, tourmoi);
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

        public void ThemGia(GiaBUS gia)
        {
            this.dsGia.Add(gia);

            gia.Them();
        }
        public void XoaGia(GiaBUS gia)
        {
            this.dsGia.Remove(gia);

            gia.Xoa();
        }
        public void SuaGia(GiaBUS gia)
        {

            for (int i = 0; i < this.dsGia.Count; i++)
            {
                if (dsGia[i].Id == gia.Id)
                {
                    this.dsGia[i] = gia;
                    break;
                }
            }

            gia.Sua();
        }


    }
}
