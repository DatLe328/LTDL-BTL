using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_KhoHang
    {
        private DAL_KhoHang dalKhoHang;
        public BUS_KhoHang()
        {
            dalKhoHang = new DAL_KhoHang();
        }
        public DataTable GetKhoHang()
        {
            return dalKhoHang.GetKhoHang();
        }
    }
}
