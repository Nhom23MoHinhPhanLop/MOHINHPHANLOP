﻿using System;



namespace QuanLyTour.BUS
{
    public class LoaiTourBUS
    {
        private String maLoai;
        private String tenLoai;

        public string MaLoai { get => maLoai; set => maLoai = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return tenLoai.ToString();
        }
    }
}
