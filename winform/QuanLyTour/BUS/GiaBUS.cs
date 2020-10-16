using System;
namespace QuanLyTour.BUS
{
    public class GiaBUS
    {
        private int id;
        private long tien;
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;
        TourBUS tour;

        public int Id { get => id; set => id = value; }
        public long Tien { get => tien; set => tien = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public TourBUS Tour { get => tour; set => tour = value; }
    }
}
