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

            String procName = "proc_getTourProgram";
            List<LoaiTourDTO> listLoaiTour = new List<LoaiTourDTO>(5);

            using (SqlCommand command = new SqlCommand(procName, connection.getConnection()))
            {

                connection.open();
                command.CommandType = CommandType.StoredProcedure;
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

        public static void capnhatLoaiTour(LoaiTourDTO loaiTour)
        {
            Connection connection = new Connection();

            String procName = "proc_updateTourProgram";

            using (SqlCommand cmd = new SqlCommand(procName, connection.getConnection()))
            {

                connection.open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maloai", loaiTour.Maloai);
                cmd.Parameters.AddWithValue("@tenloai", loaiTour.Tenloai);

                cmd.ExecuteNonQuery();

                connection.close();
            }
        }
    }
}
