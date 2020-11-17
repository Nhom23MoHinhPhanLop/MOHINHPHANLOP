using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTour.BUS
{
    public class ChucVuBUS
    {
        private String maChucVu;
        private String tenChucVu;

        public ChucVuBUS()
        {
            maChucVu = "null";
            tenChucVu = "NULL";
        }
        public string MaChucVu { get => maChucVu; set => maChucVu = value; }
        public string TenChucVu { get => tenChucVu; set => tenChucVu = value; }

        public override string ToString()
        {
            return this.tenChucVu;
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
