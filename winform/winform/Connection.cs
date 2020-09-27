using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform
{
    public class Connection
    {
        SqlConnection connect;

       public Connection()
        {
            try
            {
                connect = new SqlConnection();
                connect.ConnectionString =
                   "Data Source=CHIEN-LT\\SQLEXPRESS;" +
                    "Initial Catalog=QLTOUR;" +
                    "User id=sa;" +
                    "Password=sa;";
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Lỗi kết nối sql server", MessageBoxButtons.OK);
            }
        }
        public void open()
        {
            connect.Open();
        }    
        public void close()
        {
            connect.Close();
        }
    }
}
