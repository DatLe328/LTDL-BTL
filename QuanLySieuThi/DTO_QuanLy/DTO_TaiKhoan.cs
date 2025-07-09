using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_TaiKhoan
    {
        private int maTaiKhoan;
        private string tenDangNhap;
        private string matKhau;
        public DTO_TaiKhoan()
        {
            MaTaiKhoan = 0;
            TenDangNhap = "";
            MatKhau = "";
        }
        public DTO_TaiKhoan(int maTaiKhoan, string tenDangNhap, string matKhau)
        {
            this.MaTaiKhoan = maTaiKhoan;
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
        }
        public int MaTaiKhoan { get => maTaiKhoan; set => maTaiKhoan = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
    }
}
