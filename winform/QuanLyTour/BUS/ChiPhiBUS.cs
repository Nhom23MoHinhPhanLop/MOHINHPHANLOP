using QuanLyTour.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTour.BUS
{
    public class ChiPhiBUS
    {
        private int maChiPhi;
        private long tien;
        private DateTime thoigian;
        LoaiChiPhiBUS loaiChiPhi;
        public ChiPhiBUS()
        {
            this.LoaiChiPhi = new LoaiChiPhiBUS();
        }

        public long Tien { get => tien; set => tien = value; }
        public LoaiChiPhiBUS LoaiChiPhi { get => loaiChiPhi; set => loaiChiPhi = value; }
        public DateTime Thoigian { get => thoigian; set => thoigian = value; }
        public int MaChiPhi { get => maChiPhi; set => maChiPhi = value; }
        

        public static List<ChiPhiBUS> getChiPhiByDoan(DoanBUS doan)
        {
            return ChiPhiDAO.getChiPhiByDoan(doan);
        }
        public bool Them(DoanBUS doan)
        {
            return ChiPhiDAO.Them(this, doan);
        }
        public bool Xoa()
        {
            return ChiPhiDAO.Xoa(this);
        }
        public bool Sua()
        {
            return ChiPhiDAO.Sua(this);
        }

       
    }
}
