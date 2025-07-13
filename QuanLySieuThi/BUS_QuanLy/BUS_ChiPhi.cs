using System;
using System.Data;

namespace BUS_QuanLy
{
    public class BUS_ChiPhi
    {
        private DAL_QuanLy.DAL_ChiPhi dalChiPhi;

        public BUS_ChiPhi()
        {
            dalChiPhi = new DAL_QuanLy.DAL_ChiPhi();
        }

        public bool AddChiPhi(DTO_QuanLy.DTO_ChiPhi newChiPhi)
        {
            return dalChiPhi.AddChiPhi(newChiPhi);
        }

        public bool UpdateChiPhi(DTO_QuanLy.DTO_ChiPhi updatedChiPhi)
        {
            return dalChiPhi.UpdateChiPhi(updatedChiPhi);
        }

        public bool DeleteChiPhi(int maChiPhi)
        {
            return dalChiPhi.DeleteChiPhi(maChiPhi);
        }

        public DataTable GetChiPhi()
        {
            return dalChiPhi.GetChiPhi();
        }

        public DataTable GetChiPhiByDate(DateTime ngayLap)
        {
            return dalChiPhi.GetChiPhiByDate(ngayLap);
        }
    }
}
