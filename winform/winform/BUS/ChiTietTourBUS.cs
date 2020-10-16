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
        public static List<ChiTietTourDTO> getTourDetailById(String matour)
        {
            return ChiTietTourDAO.getTourDetailById(matour);
        }
        public static void insert(ChiTietTourDTO chiTietTour)
        {
            ChiTietTourDAO.insert(chiTietTour);
        }
        public static  void update(ChiTietTourDTO chiTietTour)
        {
            ChiTietTourDAO.update(chiTietTour);
        }
        public static  void delete(String matour, String madiadiem)
        {
            //xóa 1 chi tiết 
            ChiTietTourDAO.delete(matour, madiadiem);
        }

    }
}
