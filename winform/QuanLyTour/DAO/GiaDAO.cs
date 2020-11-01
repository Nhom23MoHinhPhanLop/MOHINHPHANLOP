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
        //public static List<GiaBUS> getAll()
        //{
        //    List<DiaDiemBUS> dsDiaDiem = new List<DiaDiemBUS>();
        //    String query = "select * from DiaDiem";
        //    Connection connection = new Connection();
        //    using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
        //    {

        //        connection.open();
        //        var reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            DiaDiemBUS diadiem = new DiaDiemBUS();
        //            diadiem.MaDiaDiem = reader["maDiaDiem"].ToString();
        //            diadiem.TenDiaDiem = reader["tenDiaDiem"].ToString();
        //            diadiem.Diaphuong = reader["diaphuong"].ToString();

        //            dsDiaDiem.Add(diadiem);
        //        }
        //        reader.Close();
        //        connection.close();
        //    }

        //    return dsDiaDiem;
        //}
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
                    gia.Tien = long.Parse(reader["tien"].ToString());
                    gia.NgayBatDau = DateTime.Parse(reader["ngayBatDau"].ToString());
                    gia.NgayKetThuc = DateTime.Parse(reader["ngayKetThuc"].ToString());

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
            String query = "select * from gia where ngayBatDau <= getdate() and ngayKetThuc >= getDate() and maTour = @tour";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@tour", tour.MaTour);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    gia.Tien = long.Parse(reader["tien"].ToString());
                    gia.NgayBatDau = DateTime.Parse(reader["ngayBatDau"].ToString());
                    gia.NgayKetThuc = DateTime.Parse(reader["ngayKetThuc"].ToString());
                }
                reader.Close();
                connection.close();
            }

            return gia;
        }
    }
}
