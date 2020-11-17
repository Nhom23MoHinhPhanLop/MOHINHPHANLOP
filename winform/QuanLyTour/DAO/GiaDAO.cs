using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTour.BUS;

namespace QuanLyTour.DAO
{
    public class GiaDAO
    {

        public static List<GiaBUS> getGiaByTour(TourBUS tour)
        {
            List<GiaBUS> dsGia = new List<GiaBUS>();
            String query = "select * from Gia where maTour=@tour";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@tour", tour.MaTour);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GiaBUS gia = new GiaBUS();
                    gia.Id = int.Parse(reader["id"].ToString());
                    gia.Tien = long.Parse(reader["tien"].ToString());
                    gia.NgayBatDau = DateTime.Parse(reader["ngayBatDau"].ToString());
                    gia.NgayKetThuc = DateTime.Parse(reader["ngayKetThuc"].ToString());
                    gia.MaTour = tour.MaTour;

                    dsGia.Add(gia);
                }
                reader.Close();
                connection.close();
            }

            return dsGia;
        }
        public static GiaBUS getGiaHienTai(TourBUS tour)
        {
            GiaBUS gia = new GiaBUS();
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand("proc_getCurrentPrice", connection.getConnection()))
            {

                connection.open();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@matour", tour.MaTour);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    gia.Id = int.Parse(reader["id"].ToString());
                    gia.Tien = long.Parse(reader["tien"].ToString());
                    gia.NgayBatDau = DateTime.Parse(reader["ngayBatDau"].ToString());
                    gia.NgayKetThuc = DateTime.Parse(reader["ngayKetThuc"].ToString());
                    gia.MaTour = tour.MaTour;
                }
                reader.Close();
                connection.close();
            }

            return gia;
        }

        public static bool Them(GiaBUS gia)
        {
            int result = 0;
            String query = "insert into Gia (tien,ngayBatDau,ngayKetThuc,maTour) values (@sotien,@ngaybd,@ngaykt,@matour)";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();

                command.Parameters.AddWithValue("@sotien", gia.Tien);
                command.Parameters.AddWithValue("@ngaybd", gia.NgayBatDau);
                command.Parameters.AddWithValue("@ngaykt", gia.NgayKetThuc);
                command.Parameters.AddWithValue("@matour", gia.MaTour);

                result = command.ExecuteNonQuery();

                connection.close();
            }
            if (result == 1)
                using (SqlCommand command = new SqlCommand("select max(id) as myid from Gia", connection.getConnection()))
                {

                    connection.open();

                    var reader = command.ExecuteReader();

                    reader.Read();
                    result = reader.HasRows == true ? 1 : 0;
                    gia.Id = int.Parse(reader["myid"].ToString());

                    connection.close();
                }

            return result == 1;

        }
        public static bool Xoa(GiaBUS gia)
        {
            int result = 0;
            String query = "delete Gia where id=@id";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();

                command.Parameters.AddWithValue("@id", gia.Id);

                result = command.ExecuteNonQuery();

                connection.close();
            }
            return result == 1;
        }
        public static bool Sua(GiaBUS gia)
        {
            int result = 0;
            String query = "update Gia set tien=@sotien,ngayBatDau=@ngaybd,ngayKetThuc=@ngaykt where id=@id ";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();

                command.Parameters.AddWithValue("@id", gia.Id);
                command.Parameters.AddWithValue("@sotien", gia.Tien);
                command.Parameters.AddWithValue("@ngaybd", gia.NgayBatDau);
                command.Parameters.AddWithValue("@ngaykt", gia.NgayKetThuc);

                result = command.ExecuteNonQuery();

                connection.close();
            }
            return result == 1;
        }
    }
}
