using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_NhaCungCap
    {
        private DAL_NhaCungCap dalNhaCungCap;
        public BUS_NhaCungCap()
        {
            dalNhaCungCap = new DAL_NhaCungCap();
        }
        public DataTable GetNhaCungCap()
        {
            return dalNhaCungCap.GetNhaCungCap();
        }
    }
}
