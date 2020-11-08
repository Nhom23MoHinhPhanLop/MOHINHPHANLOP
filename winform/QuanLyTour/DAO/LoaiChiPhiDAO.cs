using QuanLyTour.BUS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTour.DAO
{
    public class LoaiChiPhiDAO
    {
        public static List<LoaiChiPhiBUS> getAll()
        {
            List<LoaiChiPhiBUS> dsLoaiChiPhi = new List<LoaiChiPhiBUS>();
            Connection connection = new Connection();

            String query = "select * from LoaiChiPhi";
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {
                connection.open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    LoaiChiPhiBUS chiphi = new LoaiChiPhiBUS();
                    chiphi.MaLoaiChiPhi = reader["maLoaiChiPhi"].ToString();
                    chiphi.TenLoaiChiPhi = reader["tenLoaiChiPhi"].ToString();
                    dsLoaiChiPhi.Add(chiphi);
                }
                connection.close();
            }

            return dsLoaiChiPhi;
        }
    }
}
