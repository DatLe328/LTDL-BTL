using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_NhaCungCap
    {
        private int maNCC;
        private string tenNCC;
        private string diaChi;
        private string soDienThoai;
        private string email;
        private string maSoThue;

        public DTO_NhaCungCap()
        {
            MaNCC = 0;
            TenNCC = "";
            DiaChi = "";
            SoDienThoai = "";
            Email = "";
        }
        public DTO_NhaCungCap(int maNCC, string tenNCC, string diaChi, string soDienThoai, string email, string maSoThue)
        {
            this.MaNCC = maNCC;
            this.TenNCC = tenNCC;
            this.DiaChi = diaChi;
            this.SoDienThoai = soDienThoai;
            this.Email = email;
            this.MaSoThue = maSoThue;
        }
        public int MaNCC { get => maNCC; set => maNCC = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string Email { get => email; set => email = value; }
        public string MaSoThue { get => maSoThue; set => maSoThue = value; }
    }
}
