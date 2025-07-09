using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_KhachHang
    {
        private int maKhachHang;
        private string hoTenKH;
        private string soDienThoai;
        private string diaChi;
        private string email;
        DTO_KhachHang()
        {
            MaKhachHang = 0;
            HoTenKH = "";
            SoDienThoai = "";
            DiaChi = "";
            Email = "";
        }
        DTO_KhachHang(int maKhachHang, string hoTenKH, string soDienThoai, string diaChi, string email)
        {
            this.MaKhachHang = maKhachHang;
            this.HoTenKH = hoTenKH;
            this.SoDienThoai = soDienThoai;
            this.DiaChi = diaChi;
            this.Email = email;
        }

        public int MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string HoTenKH { get => hoTenKH; set => hoTenKH = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Email { get => email; set => email = value; }
    }
}
