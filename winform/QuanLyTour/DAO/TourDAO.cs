using QuanLyTour.BUS;
using System;
using System.Collections;
using System.Collections.Generic;
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
        public static void ThemTour(TourBUS tour)
        {
            String query = "insert into Tour (maTour,tenTour,maLoai) values (@maTour,N'@tenTour',@maLoai)";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@maTour", tour.MaTour);
                command.Parameters.AddWithValue("@tenTour", tour.TenTour);
                command.Parameters.AddWithValue("@maLoai", tour.LoaiTour.MaLoai);
                command.ExecuteNonQuery();
                connection.close();
            }
        }
        public static void CapNhatTour(TourBUS tour)
        {
            String query = "update Tour set tenTour=N'@tenTour',maLoai=@maLoai where  maTour = @maTour ";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@maTour", tour.MaTour);
                command.Parameters.AddWithValue("@tenTour", tour.TenTour);
                command.Parameters.AddWithValue("@maLoai", tour.LoaiTour.MaLoai);
                command.ExecuteNonQuery();
                connection.close();
            }
        }
        public static void XoaTour(TourBUS tour)
        {
            String query = "delete from Tour where  maTour = @maTour ";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@maTour", tour.MaTour);
                command.Parameters.AddWithValue("@tenTour", tour.TenTour);
                command.Parameters.AddWithValue("@maLoai", tour.LoaiTour.MaLoai);
                command.ExecuteNonQuery();
                connection.close();
            }
        }
        public static void themDiaDiemTour(TourBUS tour)
        {
            String query = "insert into ChiTietTour (maTour,maDiaDiem) values ";
            foreach (DiaDiemBUS diadiem in tour.DsDiaDiem)
            {
                String str = String.Format("({0},{1}),", tour.MaTour, diadiem.MaDiaDiem);
                query += str;
            }
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.ExecuteNonQuery();
                connection.close();
            }
        }
        public static void themGiaTour(TourBUS tour)
        {
            String query = "insert into Gia(tien,ngayBatDau,ngayKetThuc,maTour)values ";
            foreach (GiaBUS gia in tour.DsGia)
            {
                String str = String.Format("({0},{1},{2},{3}),", gia.Tien, gia.NgayBatDau.Date, gia.NgayKetThuc.Date, tour.MaTour);
                query += str;
            }
            System.Windows.Forms.MessageBox.Show(query);
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.ExecuteNonQuery();
                connection.close();
            }
        }

    }
}
