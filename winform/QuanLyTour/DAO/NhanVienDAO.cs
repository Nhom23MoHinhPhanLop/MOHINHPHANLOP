using QuanLyTour.BUS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTour.DAO
{
    public class NhanVienDAO
    {
        public static List<NhanVienBUS> getNhanVienByDoan(DoanBUS doan)
        {
            List<NhanVienBUS> dsNhanVien = new List<NhanVienBUS>();
            String query = "select * from NhanVien,PhanCong where NhanVien.maNhanVien=PhanCong.maNhanVien and maDoan=@madoan";
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
            String query = "select * from NhanVien where maNhanVien not in (select maNhanVien from PhanCong where maDoan=@madoan) ";
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

                    dsNhanVien.Add(nhanvien);
                }
                reader.Close();
                connection.close();
            }
            return dsNhanVien;
        }
    }
}
