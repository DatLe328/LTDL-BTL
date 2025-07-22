using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_ChucVu
    {
        private DAL_ChucVu dalChucVu;
        public BUS_ChucVu()
        {
            dalChucVu = new DAL_ChucVu();
        }
        public DataSet GetChucVu()
        {
            return dalChucVu.GetChucVu();
        }
        public bool AddChucVu(string maChucVu, string tenChucVu, string moTa)
        {
            return dalChucVu.AddChucVu(maChucVu, tenChucVu, moTa);
        }
        public bool UpdateChucVu(string maChucVu, string tenChucVu, string moTa)
        {
            return dalChucVu.UpdateChucVu(maChucVu, tenChucVu, moTa);
        }
        public bool DeleteChucVu(string maChucVu)
        {
            return dalChucVu.DeleteChucVu(maChucVu);
        }
    }
}
