using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winform.DAO;
using winform.DTO;

namespace winform.BUS
{
    public class LoaiTourBUS
    {
        public List<LoaiTourDTO> getAll()
        {
            return LoaiTourDAO.getAll();
        }
    }
}
