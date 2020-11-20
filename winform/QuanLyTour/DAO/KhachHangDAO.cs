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
        public static List<KhachHangBUS> timkiemKhachHangTrongDoan(DoanBUS doan, String keyword)
        {
            List<KhachHangBUS> dsKhachHang = new List<KhachHangBUS>();
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand("proc_timkiemKhachHangTrongDoan", connection.getConnection()))
            {
                connection.open();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);
                command.Parameters.AddWithValue("@keyword", keyword.ToUpper());

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

        public static List<KhachHangBUS> timkiemKhachHang(String keyword)
        {
            List<KhachHangBUS> dsKhachHang = new List<KhachHangBUS>();
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand("proc_timkiemKhachHang", connection.getConnection()))
            {
                connection.open();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@keyword", keyword.ToUpper());

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
        public static List<KhachHangBUS> getAll()
        {
            List<KhachHangBUS> dsKhachHang = new List<KhachHangBUS>();
            String query = "select maKhachHang,tenKhachHang, sdt,gioitinh,diachi,cmnd" +
                        " from KhachHang ";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
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
        public static bool XoaKhoiDoan(KhachHangBUS khachhang, DoanBUS doan)
        {
            int result = 0;
            String query = "delete thamgia where maKhachHang=@makhachhang and maDoan=@madoan";
            Connection connect = new Connection();
            using (SqlCommand command = new SqlCommand(query, connect.getConnection()))
            {
                command.Parameters.AddWithValue("@makhachhang", khachhang.MaKhachHang);
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);

                connect.open();

                result = command.ExecuteNonQuery();

                connect.close();
            }
            return result == 1;
        }
        public static bool ThemVaoDoan(KhachHangBUS khachhang, DoanBUS doan)
        {
            int result = 0;
            String query = "insert into thamgia (maKhachHang,maDoan) values (@makhachhang,@madoan)";
            Connection connect = new Connection();
            using (SqlCommand command = new SqlCommand(query, connect.getConnection()))
            {
                command.Parameters.AddWithValue("@makhachhang", khachhang.MaKhachHang);
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);

                connect.open();
                result = command.ExecuteNonQuery();

                connect.close();
            }
            return result == 1;
        }
        public static bool KiemTraTonTai(KhachHangBUS khachhang)
        {
            int result = 0;
            String query = "select count(*) as counts from KhachHang where maKhachHang=@maKhachHang";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@maKhachHang", khachhang.MaKhachHang);
                var reader = command.ExecuteReader();
                reader.Read();

                result = int.Parse(reader["counts"].ToString());

                reader.Close();
                connection.close();
            }

            return result == 1;
        }
        public static bool them(KhachHangBUS khachhang)
        {
            int result = 0;
            String query = "insert into KhachHang (maKhachHang,tenKhachHang,sdt,cmnd,diachi,gioitinh) " +
                                         "values (@maKhachHang,@tenKhachHang,@sdt,@cmnd,@diachi,@gioitinh)";
            Connection connect = new Connection();
            using (SqlCommand command = new SqlCommand(query, connect.getConnection()))
            {
                command.Parameters.AddWithValue("@maKhachHang", khachhang.MaKhachHang);
                command.Parameters.AddWithValue("@tenKhachHang", khachhang.TenKhachHang);
                command.Parameters.AddWithValue("@sdt", khachhang.Sdt);
                command.Parameters.AddWithValue("@cmnd", khachhang.Cmnd);
                command.Parameters.AddWithValue("@diachi", khachhang.Diachi);
                command.Parameters.AddWithValue("@gioitinh", khachhang.Gioitinh);

                connect.open();
                result = command.ExecuteNonQuery();

                connect.close();
            }
            return result == 1;
        }
        public static bool xoa(KhachHangBUS khachhang)
        {
            int result = 0;

            String query = "delete from KhachHang where maKhachHang=@makhachhang";
            Connection connect = new Connection();
            using (SqlCommand command = new SqlCommand(query, connect.getConnection()))
            {
                command.Parameters.AddWithValue("@makhachhang", khachhang.MaKhachHang);

                connect.open();
                result = command.ExecuteNonQuery();

                connect.close();
            }
            return result == 1;

        }
        public static bool sua(KhachHangBUS khachhangcu, KhachHangBUS khachhangmoi)
        {
            int result = 0;

            String query = "update KhachHang set maKhachHang =@maKhachHang,tenKhachHang=@tenKhachHang,sdt=@sdt,cmnd=@cmnd," +
                "diachi=@diachi,gioitinh=@gioitinh where maKhachHang=@maKhachHangcu";
            Connection connect = new Connection();
            using (SqlCommand command = new SqlCommand(query, connect.getConnection()))
            {
                command.Parameters.AddWithValue("@maKhachHang", khachhangmoi.MaKhachHang);
                command.Parameters.AddWithValue("@tenKhachHang", khachhangmoi.TenKhachHang);
                command.Parameters.AddWithValue("@sdt", khachhangmoi.Sdt);
                command.Parameters.AddWithValue("@cmnd", khachhangmoi.Cmnd);
                command.Parameters.AddWithValue("@diachi", khachhangmoi.Diachi);
                command.Parameters.AddWithValue("@gioitinh", khachhangmoi.Gioitinh);
                command.Parameters.AddWithValue("@maKhachHangcu", khachhangcu.MaKhachHang);

                connect.open();
                result = command.ExecuteNonQuery();

                connect.close();
            }
            return result == 1;

        }
    }
}
