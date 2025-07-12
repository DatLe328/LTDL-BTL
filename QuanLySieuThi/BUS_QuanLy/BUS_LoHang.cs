using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_LoHang
    {
        private DAL_LoHang dalLoHang;
        public BUS_LoHang()
        {
            dalLoHang = new DAL_LoHang();
        }
        public DataTable GetLoHang()
        {
            return dalLoHang.GetLoHang();
        }
        public DataTable GetLoHang(int maKho)
        {
            return dalLoHang.GetLoHang();
        }
        public bool UpdateLoHang(DTO_LoHang newLoHang)
        {
            return dalLoHang.UpdateLoHang(newLoHang);
        }
        public bool DeleteLoHang(DTO_LoHang newLoHang)
        {
            return dalLoHang.DeleteLoHang(newLoHang);
        }
    }
}
