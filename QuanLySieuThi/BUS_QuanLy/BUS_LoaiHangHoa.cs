using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_LoaiHangHoa
    {
        DAL_LoaiHangHoa dalLoaiHangHoa;
        public BUS_LoaiHangHoa()
        {
            dalLoaiHangHoa = new DAL_LoaiHangHoa();
        }
        public DataTable GetLoaiHangHoa()
        {
            return dalLoaiHangHoa.GetLoaiHangHoa();
        }
    }
}
