using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTour.BUS
{
    public class LoaiChiPhiBUS
    {
        private String maLoaiChiPhi;
        private String tenLoaiChiPhi;
        public LoaiChiPhiBUS()
        {
            this.maLoaiChiPhi = "null";
            this.tenLoaiChiPhi = "NULL";
        }
        public string MaLoaiChiPhi { get => maLoaiChiPhi; set => maLoaiChiPhi = value; }
        public string TenLoaiChiPhi { get => tenLoaiChiPhi; set => tenLoaiChiPhi = value; }
        public override string ToString()
        {
            return this.TenLoaiChiPhi;
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
