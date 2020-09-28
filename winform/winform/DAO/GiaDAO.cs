using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform.DAO
{
    public class GiaDAO
    {
        public static DataTable getAllGiaById(String matour)
        {
            Connection connection = new Connection();

            String query = "select * from GIA where matour = '" + matour+"'";
            DataTable result = new DataTable();
            using (SqlDataAdapter data = new SqlDataAdapter(query, connection.getConnection()))
            {

                connection.open();
                data.Fill(result);

                connection.close();
            }
            return result;
        }
    }
}
