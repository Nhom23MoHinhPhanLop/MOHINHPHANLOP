using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winform.DAO;

namespace winform.BUS
{
   public class GiaBUS
    {
        public static DataTable getGiaById(String matour)
        {
            return GiaDAO.getAllGiaById(matour);
        }
    }
}
