using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winform.DAO;
using winform.DTO;

namespace winform.BUS
{
    public class TourBUS
    {
        public  List<TourDTO> getAllTour()
        {
            return TourDAO.getAllTours();
        }
        public  void delete(String matour)
        {
            TourDAO.delete(matour);
        }
        public Boolean isTourExists(String matour)
        {
            return TourDAO.isTourExists(matour);
        }

        public void insert(TourDTO tour)
        {
            if(!isTourExists(tour.Matour))
            {
                TourDAO.insert(tour);
            }
            else
            {

            }
        }

        public void update(TourDTO tour)
        {
            TourDAO.update(tour);
        }

        public TourDTO getTourById(String matour)
        {
            return TourDAO.getTourById(matour);
        }
    }
}
