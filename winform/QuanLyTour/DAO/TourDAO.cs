using QuanLyTour.BUS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTour.DAO
{
    public class TourDAO
    {
        public static List<TourBUS> getAll()
        {
            List<TourBUS> tours = new List<TourBUS>();
            String query = "select * from Tour";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TourBUS tour = new TourBUS();
                    tour.MaTour = reader["maTour"].ToString();
                    tour.TenTour = reader["tenTour"].ToString();
                    tours.Add(tour);
                }
                reader.Close();
                connection.close();
            }

            return tours;
        }

    }
}
