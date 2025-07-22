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
    public class BUS_BangChamCong
    {
        private DAL_BangChamCong dalBangChamCong;
        public BUS_BangChamCong()
        {
            dalBangChamCong = new DAL_BangChamCong();
        }
        public DataTable GetBangChamCong(int maNhanVien)
        {
            return dalBangChamCong.GetBangChamCong(maNhanVien);
        }
        public DTO_BangChamCong GetBangChamCongByMaChamCong(int maChamCong)
        {
            return dalBangChamCong.GetBangChamCongByMaChamCong(maChamCong);
        }
        public DataTable GetBangChamCong(int maNhanVien, DateTime tuNgay, DateTime denNgay)
        {
            return dalBangChamCong.GetBangChamCong(maNhanVien, tuNgay, denNgay);
        }
        public bool AddBangChamCong(DTO_BangChamCong newBangChamCong)
        {
            return dalBangChamCong.AddBangChamCong(newBangChamCong);
        }
        public bool AddBangChamCong(int maNhanVien, DateTime ngayChamCong, TimeSpan gioVao, string trangThai, int maCa)
        {
            return dalBangChamCong.AddBangChamCong(maNhanVien, ngayChamCong, gioVao, trangThai, maCa);
        }
        public bool UpdateBangChamCong(int maChamCong, DateTime ngayGioRa, string trangThai)
        {
            return dalBangChamCong.UpdateBangChamCong(maChamCong, ngayGioRa, trangThai);
        }
        public DTO_BangChamCong GetBangChamCongToDay(int maNhanVien)
        {
            return dalBangChamCong.GetBangChamCongToDay(maNhanVien);
        }
        public int GetMaChamCongLatest(int maNhanVien)
        {
            return dalBangChamCong.GetMaChamCongLatest(maNhanVien);
        }
    }
}
