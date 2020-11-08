using QuanLyTour.BUS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTour.DAO
{
    public class ChucVuDAO
    {
        public static ChucVuBUS getChucVuById(ChucVuBUS chucvu)
        {

            String query = "select * from ChucVu where maChucVu=@machucvu";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@machucvu", chucvu.MaChucVu);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    chucvu.TenChucVu = reader["tenChucVu"].ToString();
                }
                reader.Close();
                connection.close();
            }
            return chucvu;
        }
    }
}
