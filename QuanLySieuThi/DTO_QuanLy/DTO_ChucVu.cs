using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_ChucVu
    {
        private int maChucVu;
        private string tenChucVu;
        public DTO_ChucVu()
        {
            MaChucVu = 0;
            TenChucVu = "";
        }
        public DTO_ChucVu(int maChucVu, string tenChucVu)
        {
            this.MaChucVu = maChucVu;
            this.TenChucVu = tenChucVu;
        }

        public int MaChucVu { get => maChucVu; set => maChucVu = value; }
        public string TenChucVu { get => tenChucVu; set => tenChucVu = value; }
    }
}
