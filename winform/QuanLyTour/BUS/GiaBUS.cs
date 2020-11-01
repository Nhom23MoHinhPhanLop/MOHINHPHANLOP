using System;
namespace QuanLyTour.BUS
{
    public class GiaBUS
    {
        private long tien;
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;


        public long Tien { get => tien; set => tien = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
      

        public override string ToString()
        {
            return ""+Tien+NgayBatDau+NgayKetThuc;
        }

        public override bool Equals(object obj)
        {
            return obj.ToString() == this.ToString();
        }
    }
}
