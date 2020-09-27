using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winform.DAO;
using winform.DTO;

namespace winform.BUS
{
    public class ChiTietTourBUS
    {
        public List<ChiTietTourDTO> getChiTietById(String matour)
        {
            return ChiTietTourDAO.getChiTietById(matour);
        }
        public void insert(ChiTietTourDTO chiTietTour)
        {
            ChiTietTourDAO.insert(chiTietTour);
        }
        public void update(ChiTietTourDTO chiTietTour)
        {
            ChiTietTourDAO.update(chiTietTour);
        }
        public void delete(String matour, String madiadiem)
        {
            //xóa 1 chi tiết 
            ChiTietTourDAO.delete(matour,madiadiem);
        }
       
    }
}
