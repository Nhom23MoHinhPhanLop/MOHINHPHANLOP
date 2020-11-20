using Newtonsoft.Json.Linq;
using QuanLyTour.BUS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        public static List<TourBUS> timkiemTour(String keyword)
        {
            List<TourBUS> tours = new List<TourBUS>();
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand("proc_timkiemTour", connection.getConnection()))
            {

                connection.open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@keyword", keyword.ToUpper());
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TourBUS tour = new TourBUS();
                    tour.MaTour = reader["maTour"].ToString();
                    tour.TenTour = reader["tenTour"].ToString();
                    tour.LoaiTour.MaLoai = reader["maLoai"].ToString();
                    tour.LoaiTour.TenLoai = reader["tenLoai"].ToString();
                    tour.DsDiaDiem = DiaDiemDAO.getDiaDiemByTour(tour);
                    tour.GiaHienTai = GiaDAO.getGiaHienTai(tour);
                    tour.DsGia = GiaDAO.getGiaByTour(tour);

                    tours.Add(tour);
                }
                reader.Close();
                connection.close();
            }

            return tours;
        }

        public static bool kiemtraTourTonTai(TourBUS tour)
        {
            String query = "select COUNT(*) as counts from Tour where maTour=@maTour";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@maTour", tour.MaTour);
                var reader = command.ExecuteReader();
                reader.Read();
                int count = int.Parse(reader["counts"].ToString());

                connection.close();
                return count == 1;
            }
        }
        public static bool Them(TourBUS tour)
        {
            int result = 0;
            String query = "insert into Tour (maTour,tenTour,maLoai) values (@maTour,@tenTour,@maLoai)";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@maTour", tour.MaTour);
                command.Parameters.AddWithValue("@tenTour", tour.TenTour);
                command.Parameters.AddWithValue("@maLoai", tour.LoaiTour.MaLoai);

                result = command.ExecuteNonQuery();
                connection.close();
            }

            return result == 1;
        }
        public static bool Sua(TourBUS tourcu, TourBUS tourmoi)
        {
            int result = 0;
            String query = "update Tour set maTour=@maTour, tenTour=@tenTour,maLoai=@maLoai where  maTour = @maTourCu ";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@maTour", tourmoi.MaTour);
                command.Parameters.AddWithValue("@tenTour", tourmoi.TenTour);
                command.Parameters.AddWithValue("@maLoai", tourmoi.LoaiTour.MaLoai);
                command.Parameters.AddWithValue("@maTourCu", tourcu.MaTour);
                result = command.ExecuteNonQuery();
                connection.close();
            }
            return result == 1;
        }
        public static bool Xoa(TourBUS tour)
        {
            int result = 0;
            String query = "delete from Tour where  maTour = @maTour ";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {
                connection.open();
                command.Parameters.AddWithValue("@maTour", tour.MaTour);
                result = command.ExecuteNonQuery();
                connection.close();
            }
            return result == 1;
        }

        public static DataTable ThongKeDoanhThu(DateTime ngaybd, DateTime ngaykt)
        {
            DataTable result = new DataTable();
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand("proc_thongkedoanhthutour", connection.getConnection()))
            {

                connection.open();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ngaybd", ngaybd);
                command.Parameters.AddWithValue("@ngaykt", ngaykt);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(result);
                connection.close();
            }

            return result;

        }
        public static Hashtable ThongKeChiPhi(String matour, DateTime ngaybd, DateTime ngaykt)
        {
            Hashtable result = new Hashtable();
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand("proc_thongkechiphicuatour", connection.getConnection()))
            {

                connection.open();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ngaybd", ngaybd);
                command.Parameters.AddWithValue("@ngaykt", ngaykt);
                command.Parameters.AddWithValue("@matour", matour);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(reader["tenLoaiChiPhi"].ToString(), int.Parse(reader["sotien"].ToString()));
                }

                reader.Close();
                connection.close();
            }

            return result;
        }

    }
}
