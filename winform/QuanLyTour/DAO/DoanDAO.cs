using Newtonsoft.Json.Linq;
using QuanLyTour.BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTour.DAO
{
    public class DoanDAO
    {
        public static List<DoanBUS> getAll()
        {
            List<DoanBUS> list = new List<DoanBUS>();
            String query = "select * from Doan,Tour where Doan.maTour=Tour.maTour";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DoanBUS doan = new DoanBUS();
                    doan.MaDoan = reader["maDoan"].ToString();
                    doan.TenDoan = reader["tenDoan"].ToString();
                    doan.NgayBatDau = DateTime.Parse(reader["ngayBatDau"].ToString());
                    doan.NgayKetThuc = DateTime.Parse(reader["ngayKetThuc"].ToString());
                    doan.Tour.MaTour = reader["maTour"].ToString();
                    doan.Tour.TenTour = reader["tenTour"].ToString();
                    list.Add(doan);
                }
                reader.Close();
                connection.close();
            }
            return list;
        }
        public static List<DoanBUS> timkiemDoan(String keyword)
        {
            List<DoanBUS> list = new List<DoanBUS>();
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand("proc_timkiemDoan", connection.getConnection()))
            {

                connection.open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@keyword", keyword.ToUpper());
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DoanBUS doan = new DoanBUS();
                    doan.MaDoan = reader["maDoan"].ToString();
                    doan.TenDoan = reader["tenDoan"].ToString();
                    doan.NgayBatDau = DateTime.Parse(reader["ngayBatDau"].ToString());
                    doan.NgayKetThuc = DateTime.Parse(reader["ngayKetThuc"].ToString());
                    doan.Tour.MaTour = reader["maTour"].ToString();
                    doan.Tour.TenTour = reader["tenTour"].ToString();
                    list.Add(doan);
                }
                reader.Close();
                connection.close();
            }
            return list;
        }

        public static bool KiemTraTonTai(DoanBUS doan)
        {
            int result = 0;
            String query = "select COUNT(*) as counts from Doan where maDoan=@madoan";
            Connection connect = new Connection();
            using (SqlCommand command = new SqlCommand(query, connect.getConnection()))
            {
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);

                connect.open();

                var reader = command.ExecuteReader();
                reader.Read();
                result = int.Parse(reader["counts"].ToString());

                connect.close();
            }

            return result == 1;
        }
        public static bool Them(DoanBUS doan)
        {
            int result = 0;
            String query = "insert into doan (maDoan,tenDoan,ngayBatDau,ngayKetThuc,maTour) values( @madoan,@tendoan,@ngaybatdau,@ngayketthuc,@matour)";
            Connection connect = new Connection();
            using (SqlCommand command = new SqlCommand(query, connect.getConnection()))
            {
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);
                command.Parameters.AddWithValue("@tendoan", doan.TenDoan);
                command.Parameters.AddWithValue("@ngaybatdau", doan.NgayBatDau);
                command.Parameters.AddWithValue("@ngayketthuc", doan.NgayKetThuc);
                command.Parameters.AddWithValue("@matour", doan.Tour.MaTour);

                connect.open();

                result = command.ExecuteNonQuery();

                connect.close();
            }
            return result == 1;
        }
        public static bool Xoa(DoanBUS doan)
        {
            int result = 0;
            String query = "delete doan where maDoan=@madoan";
            Connection connect = new Connection();
            using (SqlCommand command = new SqlCommand(query, connect.getConnection()))
            {
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);

                connect.open();

                result = command.ExecuteNonQuery();

                connect.close();
            }
            return result == 1;
        }
        public static bool Sua(DoanBUS doancu, DoanBUS doan)
        {
            int result = 0;
            String query = "update doan set maDoan=@madoan, tenDoan=@tendoan, ngayBatDau=@ngaybatdau, ngayKetThuc=@ngayketthuc, maTour=@matour where maDoan=@madoancu";
            Connection connect = new Connection();
            using (SqlCommand command = new SqlCommand(query, connect.getConnection()))
            {
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);
                command.Parameters.AddWithValue("@tendoan", doan.TenDoan);
                command.Parameters.AddWithValue("@ngaybatdau", doan.NgayBatDau);
                command.Parameters.AddWithValue("@ngayketthuc", doan.NgayKetThuc);
                command.Parameters.AddWithValue("@matour", doan.Tour.MaTour);
                command.Parameters.AddWithValue("@madoancu", doancu.MaDoan);

                connect.open();

                result = command.ExecuteNonQuery();

                connect.close();
            }
            return result == 1;
        }


        public static DataTable ThongKeDoanhThu(String matour, DateTime ngaybd, DateTime ngaykt)
        {
            DataTable result = new DataTable();
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand("proc_thongkedoanhthudoanbytour", connection.getConnection()))
            {

                connection.open();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ngaybd", ngaybd);
                command.Parameters.AddWithValue("@ngaykt", ngaykt);
                command.Parameters.AddWithValue("@matour", matour);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(result);
                connection.close();
            }

            return result;
        }

    }
}
