using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform.DTO
{
    public class TourDTO
    {
        String matour;
        String tentour;
        String maloai;

        public string Matour { get => matour; set => matour = value; }
        public string Tentour { get => tentour; set => tentour = value; }
        public string Maloai { get => maloai; set => maloai = value; }
    }
}
