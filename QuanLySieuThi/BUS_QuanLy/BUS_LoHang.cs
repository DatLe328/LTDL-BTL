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
            return dalLoHang.GetLoHang(maKho);
        }
        public DataTable GetLoHangByMaHoaDon(int maHoaDon)
        {
            return dalLoHang.GetLoHangByMaHoaDon(maHoaDon);
        }
        public bool AddLoHang(DTO_LoHang newLoHang)
        {
            return dalLoHang.AddLoHang(newLoHang);
        }
        public bool AddLoHang(List<DTO_LoHang> newLoHangs)
        {
            bool result = true;
            foreach (var loHang in newLoHangs)
            {
                if (!dalLoHang.AddLoHang(loHang))
                {
                    result = false;
                }
            }
            return result;
        }
        public bool UpdateLoHang(DTO_LoHang loHang)
        {
            return dalLoHang.UpdateLoHang(loHang);
        }
    }
}
