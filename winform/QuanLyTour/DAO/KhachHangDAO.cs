using QuanLyTour.BUS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTour.DAO
{
    public class KhachHangDAO
    {
        public static List<KhachHangBUS> getKhachHangByDoan(DoanBUS doan)
        {
            List<KhachHangBUS> dsKhachHang = new List<KhachHangBUS>();
            String query = "select * from KhachHang,ThamGia where Khachhang.maKhachHang=ThamGia.maKhachHang and maDoan=@madoan";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    KhachHangBUS khachhang = new KhachHangBUS();
                    khachhang.MaKhachHang = reader["maKhachHang"].ToString();
                    khachhang.TenKhachHang = reader["tenKhachHang"].ToString();
                    khachhang.Gioitinh = reader["gioitinh"].ToString();
                    khachhang.Cmnd = reader["cmnd"].ToString();
                    khachhang.Diachi = reader["diachi"].ToString();
                    khachhang.Sdt = reader["sdt"].ToString();

                    dsKhachHang.Add(khachhang);
                }
                reader.Close();
                connection.close();
            }
            return dsKhachHang;
        }
        public static List<KhachHangBUS> getKhachHangKhongCoDoan(DoanBUS doan)
        {
            List<KhachHangBUS> dsKhachHang = new List<KhachHangBUS>();
            String query = "select * from KhachHang where maKhachHang not in (select maKhachHang from ThamGia where maDoan=@madoan) ";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    KhachHangBUS khachhang = new KhachHangBUS();
                    khachhang.MaKhachHang = reader["maKhachHang"].ToString();
                    khachhang.TenKhachHang = reader["tenKhachHang"].ToString();
                    khachhang.Gioitinh = reader["gioitinh"].ToString();
                    khachhang.Cmnd = reader["cmnd"].ToString();
                    khachhang.Diachi = reader["diachi"].ToString();
                    khachhang.Sdt = reader["sdt"].ToString();

                    dsKhachHang.Add(khachhang);
                }
                reader.Close();
                connection.close();
            }
            return dsKhachHang;
        }

        public static void ThemKhachHangDoan(DoanBUS doan, List<KhachHangBUS> dsKhachHang)
        {
            String query = "insert into ThamGia (maDoan,maKhachHang) values ";
            foreach (KhachHangBUS khachhang in dsKhachHang)
            {
                query += String.Format("('{0}','{1}'),", doan.MaDoan, khachhang.MaKhachHang);
            }
            query = query.Substring(0, query.Length - 1);

            Connection connection = new Connection();
            using (SqlCommand commmand = new SqlCommand(query, connection.getConnection()))
            {
                connection.open();
                commmand.ExecuteNonQuery();
                connection.close();
            }
        }
    }
}
