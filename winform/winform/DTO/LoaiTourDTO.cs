using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform.DTO
{
    public class LoaiTourDTO
    {
        String maloai;
        String tenloai;

        public LoaiTourDTO(string maloai, string tenloai)
        {
            this.maloai = maloai;
            this.tenloai = tenloai;
        }

        public String Maloai { get => maloai; set => maloai = value; }
        public String Tenloai { get => tenloai; set => tenloai = value; }
        public String toString()
        {
            return this.Tenloai;
        }
    }
}
