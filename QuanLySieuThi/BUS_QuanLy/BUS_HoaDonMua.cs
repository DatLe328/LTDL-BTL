<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
﻿using DAL_QuanLy;
using System;
using System.Data;
>>>>>>> d5d342419bc507a45661d7dd19d37b585cc2ebd9

namespace BUS_QuanLy
{
    public class BUS_HoaDonMua
    {
<<<<<<< HEAD
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
=======
        DAL_HoaDonMua dalHoaDonMua;

        public BUS_HoaDonMua()
        {
            dalHoaDonMua = new DAL_HoaDonMua();
>>>>>>> d5d342419bc507a45661d7dd19d37b585cc2ebd9
        }
        public DataTable GetHoaDonMua()
        {
            return dalHoaDonMua.GetHoaDonMua();
        }

        public DataTable GetHoaDonMuaByDate(DateTime ngayNhap)
        {
            return dalHoaDonMua.GetHoaDonMuaByDate(ngayNhap);
        }
<<<<<<< HEAD
    }
}
=======


    }
}
>>>>>>> d5d342419bc507a45661d7dd19d37b585cc2ebd9
