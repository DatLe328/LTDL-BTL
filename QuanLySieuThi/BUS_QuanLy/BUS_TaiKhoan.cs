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
    }
}
