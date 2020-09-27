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
    public class LoaiTourDAO
    {
        public static List<LoaiTourDTO> getAll()
        {
            Connection connection = new Connection();

            String query = "select * from LOAITOUR";
            List<LoaiTourDTO> listLoaiTour = new List<LoaiTourDTO>(5);

            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listLoaiTour.Add(new LoaiTourDTO(reader["maloai"].ToString(), reader["tenloai"].ToString()));
                }
                reader.Close();
                connection.close();
            }
            return listLoaiTour;
        }
    }
}
