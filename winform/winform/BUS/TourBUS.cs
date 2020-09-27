using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winform.DAO;
using winform.DTO;

namespace winform.BUS
{
    public class TourBUS
    {
        public static DataTable getAllTour()
        {
            return TourDAO.getAllTours();
        }
        public void delete(String matour)
        {
            TourDAO.delete(matour);
        }
        public static Boolean isTourExists(String matour)
        {
            return TourDAO.isTourExists(matour);
        }

        public static void insert(TourDTO tour)
        {
            if (!isTourExists(tour.Matour))
            {
                TourDAO.insert(tour);
            }
            else
            {

            }
        }

        public static void update(TourDTO tour)
        {
            TourDAO.update(tour);
        }

        public static TourDTO getTourById(String matour)
        {
            return TourDAO.getTourById(matour);
        }
    }
}
