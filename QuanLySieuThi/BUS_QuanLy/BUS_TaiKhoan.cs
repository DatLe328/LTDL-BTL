using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan dAL_TaiKhoan;
        public BUS_TaiKhoan()
        {
            dAL_TaiKhoan = new DAL_TaiKhoan();
        }
        public bool Authenticate(string username, string password)
        {
            return dAL_TaiKhoan.Authenticate(username, password);
        }
        public int GetMaNhanVienByTenDangNhap(string tenDangNhap)
        {
            return dAL_TaiKhoan.GetMaNhanVienByTenDangNhap(tenDangNhap);
        }
        public bool AddTaiKhoan(string tenDangNhap = "", string matKhau = "123456", int maNhanVien = 0)
        {
            return dAL_TaiKhoan.AddTaiKhoan(tenDangNhap, matKhau, maNhanVien);
        }
        public bool UpdateTaiKhoan(int maTaiKhoan, string tenDangNhap = "", string matKhau = "123456", int maNhanVien = 0)
        {
            return dAL_TaiKhoan.UpdateTaiKhoan(maTaiKhoan, tenDangNhap, matKhau, maNhanVien);
        }
        public bool DeleteTaiKhoanByUserName(int tenDanhNhap)
        {
            return dAL_TaiKhoan.DeleteTaiKhoanByUserName(tenDanhNhap);
        }
        public bool CheckUsernameExists(string username)
        {
            return dAL_TaiKhoan.CheckUsernameExists(username);
        }
    }
}
