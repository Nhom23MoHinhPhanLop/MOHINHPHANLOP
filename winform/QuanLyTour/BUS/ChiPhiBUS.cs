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
        private long tien;
        private DateTime thoigian = DateTime.Now;
        DoanBUS doan;
        LoaiChiPhiBUS loaiChiPhi;
        public ChiPhiBUS()
        {
            this.Doan = new DoanBUS();
            this.LoaiChiPhi = new LoaiChiPhiBUS();
        }
        public long Tien { get => tien; set => tien = value; }
        public DoanBUS Doan { get => doan; set => doan = value; }
        public LoaiChiPhiBUS LoaiChiPhi { get => loaiChiPhi; set => loaiChiPhi = value; }
        public DateTime Thoigian { get => thoigian; set => thoigian = value; }


        public static List<ChiPhiBUS> getChiPhiByDoan(DoanBUS doan)
        {
            return ChiPhiDAO.getChiPhiByDoan(doan);
        }
    }
}
