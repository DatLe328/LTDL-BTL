using DAL_QuanLy;
using System;
using System.Data;

namespace BUS_QuanLy
{
    public class BUS_HoaDonMua
    {
        DAL_HoaDonMua dalHoaDonMua;

        public BUS_HoaDonMua()
        {
            dalHoaDonMua = new DAL_HoaDonMua();
        }
        public DataTable GetHoaDonMua()
        {
            return dalHoaDonMua.GetHoaDonMua();
        }

        public DataTable GetHoaDonMuaByDate(DateTime ngayNhap)
        {
            return dalHoaDonMua.GetHoaDonMuaByDate(ngayNhap);
        }


    }
}