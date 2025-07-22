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
    public class BUS_CaLamViec
    {
        private DAL_CaLamViec dalCaLamViec;
        public BUS_CaLamViec()
        {
            dalCaLamViec = new DAL_CaLamViec();
        }
        public DataTable GetCaLamViec()
        {
            return dalCaLamViec.GetCaLamViec();
        }
        public DataTable GetCaLamViec(DateTime tuNgay, DateTime denNgay)
        {
            return dalCaLamViec.GetCaLamViec(tuNgay, denNgay);
        }
        public bool AddCaLamViec(DTO_CaLamViec caLamViec)
        {
            return dalCaLamViec.AddCaLamViec(caLamViec);
        }
        public bool UpdateCaLamViec(DTO_CaLamViec caLamViec)
        {
            return dalCaLamViec.UpdateCaLamViec(caLamViec);
        }
        public bool DeleteCaLamViec(int maCaLamViec)
        {
            return dalCaLamViec.DeleteCaLamViec(maCaLamViec);
        }
    }
}
