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
        DoanBUS doan;
        LoaiChiPhiBUS loaiChiPhi;

        public long Tien { get => tien; set => tien = value; }
        public DoanBUS Doan { get => doan; set => doan = value; }
        public LoaiChiPhiBUS LoaiChiPhi { get => loaiChiPhi; set => loaiChiPhi = value; }
    }
}
