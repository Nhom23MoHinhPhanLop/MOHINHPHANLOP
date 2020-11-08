using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTour.BUS;

namespace QuanLyTour.DAO
{
    public class ChiPhiDAO
    {
        public static  List<ChiPhiBUS> getChiPhiByDoan(DoanBUS doan)
        {
            List<ChiPhiBUS> dsChiPhi = new List<ChiPhiBUS>();
            Connection connection = new Connection();

            String query = "select * from ChiPhi where maDoan=@madoan";
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {
                connection.open();
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ChiPhiBUS chiphi = new ChiPhiBUS();
                 
                    //chiphi.Thoigian = DateTime.Parse(reader["thoigian"].ToString());
                    chiphi.Tien = long.Parse(reader["tien"].ToString());
                    chiphi.LoaiChiPhi.MaLoaiChiPhi = reader["maLoaiChiPhi"].ToString();
                    chiphi.Doan.MaDoan = reader["maDoan"].ToString();
                    dsChiPhi.Add(chiphi);
                }
                connection.close();
            }

            return dsChiPhi;
        }


    }
}
