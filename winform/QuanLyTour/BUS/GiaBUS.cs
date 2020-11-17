using QuanLyTour.DAO;
using System;
namespace QuanLyTour.BUS
{
    public class GiaBUS
    {
        private int id;
        private long tien;
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;
        private String maTour;
        public GiaBUS()
        {
            tien = 0;
            ngayBatDau = DateTime.Now;
            ngayKetThuc = DateTime.Now;
        }
        public long Tien { get => tien; set => tien = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public int Id { get => id; set => id = value; }
        public string MaTour { get => maTour; set => maTour = value; }

        public override string ToString()
        {
            return id.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj.ToString() == this.ToString();
        }

        public bool Them()
        {
            return GiaDAO.Them(this);
        }
        public bool Xoa()
        {
            return GiaDAO.Xoa(this);
        }
        public bool Sua()
        {
            return GiaDAO.Sua(this);
        }



    }
}
