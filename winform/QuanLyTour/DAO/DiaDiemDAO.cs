using QuanLyTour.BUS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTour.DAO
{
    public class DiaDiemDAO
    {
        public static List<DiaDiemBUS> getAll()
        {
            List<DiaDiemBUS> dsDiaDiem = new List<DiaDiemBUS>();
            String query = "select * from DiaDiem";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DiaDiemBUS diadiem = new DiaDiemBUS();
                    diadiem.MaDiaDiem = reader["maDiaDiem"].ToString();
                    diadiem.TenDiaDiem = reader["tenDiaDiem"].ToString();
                    diadiem.Diaphuong = reader["diaphuong"].ToString();

                    dsDiaDiem.Add(diadiem);
                }
                reader.Close();
                connection.close();
            }

            return dsDiaDiem;
        }
        public static List<DiaDiemBUS> getDiaDiemByTour(TourBUS tour)
        {
            List<DiaDiemBUS> dsDiaDiem = new List<DiaDiemBUS>();
            String query = "select * from DiaDiem d,ChiTietTour c where d.maDiaDiem=c.maDiaDiem and c.maTour=@tour";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@tour", tour.MaTour);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DiaDiemBUS diadiem = new DiaDiemBUS();
                    diadiem.MaDiaDiem = reader["maDiaDiem"].ToString();
                    diadiem.TenDiaDiem = reader["tenDiaDiem"].ToString();
                    diadiem.Diaphuong = reader["diaphuong"].ToString();

                    dsDiaDiem.Add(diadiem);
                }
                reader.Close();
                connection.close();
            }

            return dsDiaDiem;
        }
    }
}
