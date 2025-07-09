using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_KhoHang
    {
        private int maKho;
        private string tenKho;
        private string diaChiKho;
        public DTO_KhoHang()
        {
            MaKho = 0;
            TenKho = "";
            DiaChiKho = "";
        }
        public DTO_KhoHang(int maKho, string tenKho, string diaChiKho)
        {
            this.MaKho = maKho;
            this.TenKho = tenKho;
            this.DiaChiKho = diaChiKho;
        }
        public int MaKho { get => maKho; set => maKho = value; }
        public string TenKho { get => tenKho; set => tenKho = value; }
        public string DiaChiKho { get => diaChiKho; set => diaChiKho = value; }
    }
}
