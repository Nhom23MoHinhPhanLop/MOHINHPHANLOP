using QuanLyTour.BUS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTour.DAO
{
    public class LoaiTourDAO
    {
        public static List<LoaiTourBUS> getAll()
        {
            List<LoaiTourBUS> dsLoaiTour = new List<LoaiTourBUS>();
            String query = "select * from LoaiTour";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    LoaiTourBUS loaiTour = new LoaiTourBUS();
                    loaiTour.MaLoai = reader["maLoai"].ToString();
                    loaiTour.TenLoai = reader["tenLoai"].ToString();
                    dsLoaiTour.Add(loaiTour);
                }
                reader.Close();
                connection.close();
            }

            return dsLoaiTour;
        }
        public static LoaiTourBUS getLoaiTourByTour(TourBUS tour)
        {
            LoaiTourBUS loaiTour = new LoaiTourBUS();
            String query = "select tenLoai,LoaiTour.maLoai from LoaiTour,Tour where Tour.maLoai=LoaiTour.maLoai and maTour=@maTour";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@maTour", tour.MaTour);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {

                    loaiTour.MaLoai = reader["maLoai"].ToString();
                    loaiTour.TenLoai = reader["tenLoai"].ToString();
                }
                reader.Close();
                connection.close();
            }

            return loaiTour;
        }
    }
}
