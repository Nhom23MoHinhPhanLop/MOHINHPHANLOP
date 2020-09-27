
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform.DTO
{
    public class ChiTietTourDTO
    {
        String matour;
        String madiadiem;
        String tt;

        public ChiTietTourDTO(string matour, string madiadiem, string tt)
        {
            this.matour = matour;
            this.madiadiem = madiadiem;
            this.tt = tt;
        }

        public string Matour { get => matour; set => matour = value; }
        public string Madiadiem { get => madiadiem; set => madiadiem = value; }
        public string Tt { get => tt; set => tt = value; }
    }
}
