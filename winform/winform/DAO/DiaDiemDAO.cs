using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winform.DTO;

namespace winform.DAO
{
    public class DiaDiemDAO
    {
        public static List<DiaDiemDTO> getAll()
        {
            Connection connection = new Connection();

            String query = "select * from DIADIEM";
            List<DiaDiemDTO> listDiadiem = new List<DiaDiemDTO>(5);

            using (SqlCommand command = new SqlCommand(query, connection.getConnection()))
            {

                connection.open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listDiadiem.Add(new DiaDiemDTO(reader["madiadiem"].ToString(), reader["tendiadiem"].ToString()));
                }
                reader.Close();
                connection.close();
            }
            return listDiadiem;
        }
    }
}
