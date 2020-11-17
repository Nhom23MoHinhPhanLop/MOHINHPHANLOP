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
        public static List<ChucVuBUS> getAll()
        {
            List<ChucVuBUS> dsChucVu = new List<ChucVuBUS>();
            String query = "select * from ChucVu";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ChucVuBUS chucvu = new ChucVuBUS();
                    chucvu.TenChucVu = reader["tenChucVu"].ToString();
                    chucvu.MaChucVu = reader["maChucVu"].ToString();
                    dsChucVu.Add(chucvu);
                }
                reader.Close();
                connection.close();
            }
            return dsChucVu;
        }
    }
}
