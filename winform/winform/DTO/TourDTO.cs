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

        public TourDTO() { }
        public TourDTO(string matour, string tentour, string maloai)
        {
            this.matour = matour;
            this.tentour = tentour;
            this.maloai = maloai;
        }

        public String Matour { get => matour; set => matour = value; }
        public String Tentour { get => tentour; set => tentour = value; }
        public String Maloai { get => maloai; set => maloai = value; }
        public String toString()
        {
            return this.Tentour;
        }
    }
}
