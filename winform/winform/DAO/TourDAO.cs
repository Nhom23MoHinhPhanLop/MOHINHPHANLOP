using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winform.DTO;

namespace winform.DAO
{
    public static class TourDAO
    {
        public static DataTable getAllTours()
        {
            Connection connection = new Connection();
            connection.open();
            String sql = "select * from TOUR";
            SqlDataAdapter data = new SqlDataAdapter(sql, connection.getConnection());
            DataTable dataTable = new DataTable();
            data.Fill(dataTable);
            connection.close();
            return dataTable;
        }
        public static TourDTO getTourById(String matour)
        {
            return new TourDTO();
        }
        public static Boolean isTourExists(String matour)
        {
            Connection connection = new Connection();
            connection.open();
            // Dùng SqlCommand thi hành SQL  - sẽ  tìm hiểu sau
            using (SqlCommand command = connection.getConnection().CreateCommand())
            {

                // Câu truy vấn SQL
                command.CommandText = "select * from TOUR where matour='" + matour + "'";
                var reader = command.ExecuteReader();

                if (reader.FieldCount != 0)
                    return true;
            }
            connection.close();

            return false;
        }

        public static void update(TourDTO tour)
        {
            Connection connection = new Connection();

            String query = "update TOUR set tentour=N'@tentour', maloai='@maloai' where matour='@matour'";

            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {
                command.Parameters.AddWithValue("@tentour", tour.Tentour);
                command.Parameters.AddWithValue("@maloai", tour.Maloai);
                command.Parameters.AddWithValue("@matour", tour.Matour);

                connection.open();
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    MessageBox.Show("TOURDAO: Lỗi cập nhật", "Thông báo");
                }
                connection.close();
            }
        }

        public static void insert(TourDTO tour)
        {
            Connection connection = new Connection();

            String query = "insert into TOUR (matour,tentour,maloai) values (@matour,N'@tentour', @maloai)";

            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {
                command.Parameters.AddWithValue("@tentour", tour.Tentour);
                command.Parameters.AddWithValue("@maloai", tour.Maloai);
                command.Parameters.AddWithValue("@matour", tour.Matour);

                connection.open();
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    MessageBox.Show("TOURDAO: Lỗi thêm mới", "Thông báo");
                }
                connection.close();
            }
        }
        public static void delete(TourDTO tour)
        {

        }
        public static void delete(String matour)
        {
            Connection connection = new Connection();

            String query = "delete TOUR where matour=@matour ";

            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {
                command.Parameters.AddWithValue("@matour", matour);

                connection.open();
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    MessageBox.Show("TOURDAO: Lỗi Xóa", "Thông báo");
                }
                connection.close();
            }
        }
    }
}
