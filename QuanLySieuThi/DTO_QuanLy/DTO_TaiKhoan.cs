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
        private int maNhanVien;
        private string tenDangNhap;
        private string matKhau;
        public DTO_TaiKhoan()
        {
            MaTaiKhoan = 0;
            TenDangNhap = "";
            MatKhau = "";
        }
        public DTO_TaiKhoan(int maTaiKhoan, int maNhanVien, string tenDangNhap, string matKhau)
        {
            this.MaTaiKhoan = maTaiKhoan;
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
            this.MaNhanVien = maNhanVien;
        }
        public int MaTaiKhoan { get => maTaiKhoan; set => maTaiKhoan = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
    }
}
