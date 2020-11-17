using QuanLyTour.BUS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTour.DAO
{
    public class NhanVienDAO
    {
        public static List<NhanVienBUS> getAll()
        {
            List<NhanVienBUS> dsNhanVien = new List<NhanVienBUS>();
            String query = "select maNhanVien,tenNhanVien,sdt,gioitinh,diachi,cmnd,NhanVien.maChucVu as machucvu,tenChucVu" +
                        " from NhanVien,ChucVu where NhanVien.maChucVu=ChucVu.maChucVu";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    NhanVienBUS nhanvien = new NhanVienBUS();
                    nhanvien.MaNhanVien = reader["maNhanVien"].ToString();
                    nhanvien.TenNhanVien = reader["tenNhanVien"].ToString();
                    nhanvien.Gioitinh = reader["gioitinh"].ToString();
                    nhanvien.Cmnd = reader["cmnd"].ToString();
                    nhanvien.Diachi = reader["diachi"].ToString();
                    nhanvien.Sdt = reader["sdt"].ToString();
                    nhanvien.Chucvu.MaChucVu = reader["machucvu"].ToString();
                    nhanvien.Chucvu.TenChucVu = reader["tenChucVu"].ToString();
                    dsNhanVien.Add(nhanvien);
                }
                reader.Close();
                connection.close();
            }
            return dsNhanVien;
        }
        public static List<NhanVienBUS> getNhanVienByDoan(DoanBUS doan)
        {
            List<NhanVienBUS> dsNhanVien = new List<NhanVienBUS>();
            String query = "select * from NhanVien,PhanCong,ChucVu where NhanVien.maChucVu=ChucVu.maChucVu and NhanVien.maNhanVien=PhanCong.maNhanVien and maDoan=@madoan";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    NhanVienBUS nhanvien = new NhanVienBUS();
                    nhanvien.MaNhanVien = reader["maNhanVien"].ToString();
                    nhanvien.TenNhanVien = reader["tenNhanVien"].ToString();
                    nhanvien.Gioitinh = reader["gioitinh"].ToString();
                    nhanvien.Cmnd = reader["cmnd"].ToString();
                    nhanvien.Diachi = reader["diachi"].ToString();
                    nhanvien.Sdt = reader["sdt"].ToString();
                    nhanvien.Chucvu.MaChucVu = reader["maChucVu"].ToString();
                    nhanvien.Chucvu.TenChucVu = reader["tenChucVu"].ToString();

                    dsNhanVien.Add(nhanvien);
                }
                reader.Close();
                connection.close();
            }
            return dsNhanVien;
        }
        public static List<NhanVienBUS> getNhanVienKhongCoDoan(DoanBUS doan)
        {
            List<NhanVienBUS> dsNhanVien = new List<NhanVienBUS>();
            String query = "select * from NhanVien ,ChucVu where NhanVien.maChucVu=ChucVu.maChucVu and maNhanVien not in (select maNhanVien from PhanCong where maDoan=@madoan) ";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    NhanVienBUS nhanvien = new NhanVienBUS();
                    nhanvien.MaNhanVien = reader["maNhanVien"].ToString();
                    nhanvien.TenNhanVien = reader["tenNhanVien"].ToString();
                    nhanvien.Gioitinh = reader["gioitinh"].ToString();
                    nhanvien.Cmnd = reader["cmnd"].ToString();
                    nhanvien.Diachi = reader["diachi"].ToString();
                    nhanvien.Sdt = reader["sdt"].ToString();
                    nhanvien.Chucvu.MaChucVu = reader["maChucVu"].ToString();
                    nhanvien.Chucvu.TenChucVu = reader["tenChucVu"].ToString();

                    dsNhanVien.Add(nhanvien);
                }
                reader.Close();
                connection.close();
            }
            return dsNhanVien;
        }


        public static bool XoaKhoiDoan(NhanVienBUS nhanvien, DoanBUS doan)
        {
            int result = 0;
            String query = "delete phancong where maNhanVien=@manhanvien and maDoan=@madoan";
            Connection connect = new Connection();
            using (SqlCommand command = new SqlCommand(query, connect.getConnection()))
            {
                command.Parameters.AddWithValue("@manhanvien", nhanvien.MaNhanVien);
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);

                connect.open();

                result = command.ExecuteNonQuery();

                connect.close();
            }
            return result == 1;
        }
        public static bool ThemVaoDoan(NhanVienBUS nhanvien, DoanBUS doan)
        {
            int result = 0;

            String query = "insert into phancong (maNhanVien,maDoan) values (@manhanvien,@madoan)";
            Connection connect = new Connection();
            using (SqlCommand command = new SqlCommand(query, connect.getConnection()))
            {
                command.Parameters.AddWithValue("@manhanvien", nhanvien.MaNhanVien);
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);

                connect.open();
                command.ExecuteNonQuery();
            }
            using (SqlCommand command = new SqlCommand("select count(*) as counts from phancong where maNhanVien=@manhanvien and maDoan=@madoan", connect.getConnection()))
            {
                command.Parameters.AddWithValue("@manhanvien", nhanvien.MaNhanVien);
                command.Parameters.AddWithValue("@madoan", doan.MaDoan);

                var reader = command.ExecuteReader();

                reader.Read();

                result = int.Parse(reader["counts"].ToString());
                connect.close();
            }
            return result == 1;
        }
        public static bool KiemTraTonTai(NhanVienBUS nhanvien)
        {
            int result = 0;
            String query = "select count(*) as counts from NhanVien where maNhanVien=@manhanvien";
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                command.Parameters.AddWithValue("@manhanvien", nhanvien.MaNhanVien);
                var reader = command.ExecuteReader();
                reader.Read();

                result = int.Parse(reader["counts"].ToString());

                reader.Close();
                connection.close();
            }

            return result == 1;
        }
        public static bool them(NhanVienBUS nhanvien)
        {
            int result = 0;
            String query = "insert into NhanVien (maNhanVien,tenNhanVien,sdt,cmnd,diachi,gioitinh,maChucVu) " +
                                         "values (@manhanvien,@tennhanvien,@sdt,@cmnd,@diachi,@gioitinh,@machucvu)";
            Connection connect = new Connection();
            using (SqlCommand command = new SqlCommand(query, connect.getConnection()))
            {
                command.Parameters.AddWithValue("@manhanvien", nhanvien.MaNhanVien);
                command.Parameters.AddWithValue("@tennhanvien", nhanvien.TenNhanVien);
                command.Parameters.AddWithValue("@sdt", nhanvien.Sdt);
                command.Parameters.AddWithValue("@cmnd", nhanvien.Cmnd);
                command.Parameters.AddWithValue("@diachi", nhanvien.Diachi);
                command.Parameters.AddWithValue("@gioitinh", nhanvien.Gioitinh);
                command.Parameters.AddWithValue("@machucvu", nhanvien.Chucvu.MaChucVu);

                connect.open();
                result = command.ExecuteNonQuery();

                connect.close();
            }
            return result == 1;
        }
        public static bool xoa(NhanVienBUS nhanvien)
        {
            int result = 0;

            String query = "delete from NhanVien where maNhanVien=@manhanvien";
            Connection connect = new Connection();
            using (SqlCommand command = new SqlCommand(query, connect.getConnection()))
            {
                command.Parameters.AddWithValue("@manhanvien", nhanvien.MaNhanVien);

                connect.open();
                result = command.ExecuteNonQuery();

                connect.close();
            }
            return result == 1;

        }
        public static bool sua(NhanVienBUS nhanviencu, NhanVienBUS nhanvienmoi)
        {
            int result = 0;

            String query = "update NhanVien set maNhanVien =@manhanvien,tenNhanVien=@tennhanvien,sdt=@sdt,cmnd=@cmnd," +
                "diachi=@diachi,gioitinh=@gioitinh,maChucVu=@machucvu where maNhanVien=@manhanviencu";
            Connection connect = new Connection();
            using (SqlCommand command = new SqlCommand(query, connect.getConnection()))
            {
                command.Parameters.AddWithValue("@manhanvien", nhanvienmoi.MaNhanVien);
                command.Parameters.AddWithValue("@tennhanvien", nhanvienmoi.TenNhanVien);
                command.Parameters.AddWithValue("@sdt", nhanvienmoi.Sdt);
                command.Parameters.AddWithValue("@cmnd", nhanvienmoi.Cmnd);
                command.Parameters.AddWithValue("@diachi", nhanvienmoi.Diachi);
                command.Parameters.AddWithValue("@gioitinh", nhanvienmoi.Gioitinh);
                command.Parameters.AddWithValue("@machucvu", nhanvienmoi.Chucvu.MaChucVu);
                command.Parameters.AddWithValue("@manhanviencu", nhanviencu.MaNhanVien);

                connect.open();
                result = command.ExecuteNonQuery();

                connect.close();
            }
            return result == 1;

        }
        public static DataTable ThongKeSoLanDi(DateTime ngaybd, DateTime ngaykt)
        {
            DataTable result = new DataTable();
            Connection connection = new Connection();
            using (SqlCommand command = new SqlCommand("proc_SoLanDiTour", connection.getConnection()))
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
    }
}

