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
        #region Properties
        private int maChiPhi;
        private long tien;
        private DateTime thoigian;
        LoaiChiPhiBUS loaiChiPhi;
        public ChiPhiBUS()
        {
            this.LoaiChiPhi = new LoaiChiPhiBUS();
        }
        #endregion

        #region Get Set
        public long Tien { get => tien; set => tien = value; }
        public LoaiChiPhiBUS LoaiChiPhi { get => loaiChiPhi; set => loaiChiPhi = value; }
        public DateTime Thoigian { get => thoigian; set => thoigian = value; }
        public int MaChiPhi { get => maChiPhi; set => maChiPhi = value; }

        #endregion

        #region Function
        public static List<ChiPhiBUS> getChiPhiByDoan(DoanBUS doan)
        {
            return ChiPhiDAO.getChiPhiByDoan(doan);
        }
     

        public void Them(DoanBUS doan)
        {
            ChiPhiDAO.Them(this, doan);
        }
        public void Xoa()
        {
            ChiPhiDAO.Xoa(this);
        }
        public void Sua()
        {
            ChiPhiDAO.Sua(this);
        }
        #endregion



    }
}
