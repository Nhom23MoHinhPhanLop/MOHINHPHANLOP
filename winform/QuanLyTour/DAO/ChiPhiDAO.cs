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
        public static List<ChiPhiBUS> getChiPhiByDoan(DoanBUS doan)
        {
            List<ChiPhiBUS> dsChiPhi = new List<ChiPhiBUS>();
            Connection connection = new Connection();

            String query = "select * from ChiPhi,LoaiChiPhi where maDoan=@madoan and ChiPhi.maLoaiChiPhi=LoaiChiPhi.maLoaiChiPhi";
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {
                connection.open();
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ChiPhiBUS chiphi = new ChiPhiBUS();

                    chiphi.MaChiPhi = int.Parse(reader["maChiPhi"].ToString());
                    chiphi.Thoigian = DateTime.Parse(reader["thoigian"].ToString());
                    chiphi.Tien = long.Parse(reader["tien"].ToString());
                    chiphi.LoaiChiPhi.MaLoaiChiPhi = reader["maLoaiChiPhi"].ToString();
                    chiphi.LoaiChiPhi.TenLoaiChiPhi = reader["tenLoaiChiPhi"].ToString();
                    dsChiPhi.Add(chiphi);
                }
                connection.close();
            }

            return dsChiPhi;
        }
        public static bool Them(ChiPhiBUS chiphi, DoanBUS doan)
        {
            int result = 0;
            Connection connection = new Connection();

            String query = "insert into ChiPhi (tien,maLoaiChiPhi,maDoan,thoigian) values (@sotien,@maloaichiphi,@madoan,@thoigian)";
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {
                connection.open();
                command.Parameters.AddWithValue("@sotien", chiphi.Tien);
                command.Parameters.AddWithValue("@thoigian", chiphi.Thoigian);
                command.Parameters.AddWithValue("@maloaichiphi", chiphi.LoaiChiPhi.MaLoaiChiPhi);
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);

                result = command.ExecuteNonQuery();

                connection.close();
            }
            if (result == 1)
                using (SqlCommand command = new SqlCommand("select max(maChiPhi) as myid from ChiPhi", connection.getConnection()))
                {
                    connection.open();

                    var reader = command.ExecuteReader();
                    reader.Read();

                    chiphi.MaChiPhi = int.Parse(reader["myid"].ToString());

                    connection.close();

                }
            return result == 1;

        }
        public static bool Xoa(ChiPhiBUS chiphi)
        {
            int result = 0;
            Connection connection = new Connection();

            String query = "delete ChiPhi where maChiphi=@machiphi";
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {
                connection.open();
                command.Parameters.AddWithValue("@machiphi", chiphi.MaChiPhi);
                result = command.ExecuteNonQuery();

                connection.close();
            }
            return result == 1;
        }
        public static bool Sua(ChiPhiBUS chiphi)
        {
            int result = 0;
            Connection connection = new Connection();

            String query = "update ChiPhi set tien=@sotien,thoigian=@thoigian,maLoaiChiPhi=@maloaichiphi where maChiphi=@machiphi";
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {
                connection.open();
                command.Parameters.AddWithValue("@machiphi", chiphi.MaChiPhi);
                command.Parameters.AddWithValue("@sotien", chiphi.Tien);
                command.Parameters.AddWithValue("@thoigian", chiphi.Thoigian);
                command.Parameters.AddWithValue("@maloaichiphi", chiphi.LoaiChiPhi.MaLoaiChiPhi);

                result = command.ExecuteNonQuery();

                connection.close();
            }
            return result == 1;
        }

    }
}
