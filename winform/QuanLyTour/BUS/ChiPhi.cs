using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTour.BUS
{
    public class ChiPhi
    {
        private String maChi;
        private String mucdich;
        private long tien;
        DoanBUS doan;
        public string MaChi { get => maChi; set => maChi = value; }
        public string Mucdich { get => mucdich; set => mucdich = value; }
        public long Tien { get => tien; set => tien = value; }
        public DoanBUS Doan { get => doan; set => doan = value; }
    }
}
