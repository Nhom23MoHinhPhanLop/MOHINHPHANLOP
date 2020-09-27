using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform.DTO
{
    public class DiaDiemDTO
    {
        String madiadiem;
        String tendiadiem;

        public DiaDiemDTO(string madiadiem, string tendiadiem)
        {
            this.madiadiem = madiadiem;
            this.tendiadiem = tendiadiem;
        }

        public String Madiadiem { get => madiadiem; set => madiadiem = value; }
        public String Tendiadiem { get => tendiadiem; set => tendiadiem = value; }
        public String toString()
        {
            return this.Tendiadiem;
        }
    }
}
