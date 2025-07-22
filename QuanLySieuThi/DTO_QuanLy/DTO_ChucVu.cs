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
        private int mucLuong;
        public DTO_ChucVu()
        {
            MaChucVu = 0;
            TenChucVu = "";
            MucLuong = 0;
        }
        public DTO_ChucVu(int maChucVu, string tenChucVu, int mucLuong)
        {
            this.MaChucVu = maChucVu;
            this.TenChucVu = tenChucVu;
            this.MucLuong = mucLuong;
        }

        public int MaChucVu { get => maChucVu; set => maChucVu = value; }
        public string TenChucVu { get => tenChucVu; set => tenChucVu = value; }
        public int MucLuong { get => mucLuong; set => mucLuong = value; }
    }
}
