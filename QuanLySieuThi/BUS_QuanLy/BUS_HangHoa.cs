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
    public class BUS_HangHoa
    {
        DAL_HangHoa dalHangHoa;
        public BUS_HangHoa()
        {
            dalHangHoa = new DAL_HangHoa();
        }
        public bool AddHangHoa(DTO_HangHoa newHangHoa)
        {
            return dalHangHoa.AddHangHoa(newHangHoa);
        }
        public bool UpdateHangHoa(DTO_HangHoa updatedHangHoa)
        {
            return dalHangHoa.UpdateHangHoa(updatedHangHoa);
        }
        public bool DeleteHangHoa(int maHangHoa)
        {
            return dalHangHoa.DeleteHangHoa(maHangHoa);
        }
        public DataTable GetHangHoa(string maHangHoa = "", string tenHangHoa = "")
        {
            Console.WriteLine("Getting in BUS_HangHoa");
            return dalHangHoa.GetHangHoa(maHangHoa: maHangHoa, tenHangHoa: tenHangHoa);
        }
    }
}
