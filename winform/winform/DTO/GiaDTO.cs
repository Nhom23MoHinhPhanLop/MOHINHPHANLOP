using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform.DTO
{
    public class GiaDTO
    {
        String magia;
        Double gia;
        String ngaybatdau;
        String ngayketthuc;
        String matour;

        public GiaDTO(string magia, double gia, string ngaybatdau, string ngayketthuc, string matour)
        {
            this.Magia = magia;
            this.Gia = gia;
            this.Ngaybatdau = ngaybatdau;
            this.Ngayketthuc = ngayketthuc;
            this.Matour = matour;
        }

        public double Gia { get => gia; set => gia = value; }
        public string Ngaybatdau { get => ngaybatdau; set => ngaybatdau = value; }
        public string Ngayketthuc { get => ngayketthuc; set => ngayketthuc = value; }
        public string Matour { get => matour; set => matour = value; }
        public string Magia { get => magia; set => magia = value; }
    }
}
