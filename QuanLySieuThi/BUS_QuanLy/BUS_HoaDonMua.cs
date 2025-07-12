using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_HoaDonMua
    {
        private DAL_QuanLy.DAL_HoaDonMua dalHoaDonMua;
        public BUS_HoaDonMua()
        {
            dalHoaDonMua = new DAL_QuanLy.DAL_HoaDonMua();
        }
        public bool AddHoaDonMua(DTO_QuanLy.DTO_HoaDonMua newHoaDonMua)
        {
            return dalHoaDonMua.AddHoaDonMua(newHoaDonMua);
        }
        public int GetLastHoaDonMuaId()
        {
            return dalHoaDonMua.GetLastHoaDonMuaId();
        }
        public bool UpdateHoaDonMua(DTO_QuanLy.DTO_HoaDonMua updatedHoaDonMua)
        {
            return dalHoaDonMua.UpdateHoaDonMua(updatedHoaDonMua);
        }
    }
}
