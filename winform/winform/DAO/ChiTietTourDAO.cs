using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winform.DTO;

namespace winform.DAO
{
    public class ChiTietTourDAO
    {
        public static List<ChiTietTourDTO> getTourDetailById(String matour)
        {
            //Hàm này sẽ trả về danh sách các địa điểm và thông tin của 1 tour
            String query = "Select * from CHITIETTOUR where matour='@matour'";
            List<ChiTietTourDTO> result = new List<ChiTietTourDTO>();
            Connection connection = new Connection();


            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new ChiTietTourDTO(reader["matour"].ToString(), reader["madiadiem"].ToString(),reader["tt"].ToString()));
                }
                reader.Close();
                connection.close();
            }
            return result;
        }
        public static void insert(ChiTietTourDTO chiTietTour)
        {

        }
        public static void update(ChiTietTourDTO chiTietTour)
        {

        }
        public static void delete(String matour, String madiadiem)
        {

        }
    }
}
