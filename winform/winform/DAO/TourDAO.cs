using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winform.DTO;

namespace winform.DAO
{
    public static class TourDAO
    {
        public  static List<TourDTO> getAllTours()
        {
            return new List<TourDTO>();
        }
        public static TourDTO getTourById(String matour)
        {
            return new TourDTO();
        }
        public static Boolean isTourExists(String matour)
        {
            return true;
        }

        public static void update(TourDTO tour)
        {
            
        }

        public static void insert(TourDTO tour)
        { 

        }
        public static void delete(TourDTO tour)
        { 

        }
        public static void delete(String matour)
        {

        }
    }
}
