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
    public class BUS_BangLuong
    {
        private DAL_BangLuong dalBangLuong;
        public BUS_BangLuong()
        {
            dalBangLuong = new DAL_BangLuong();
        }
        public DataTable GetBangLuong()
        {
            return dalBangLuong.GetBangLuong();
        }
        public DataTable GetBangLuong(int maNhanVien)
        {
            return dalBangLuong.GetBangLuong(maNhanVien);
        }
        public int GetLastMaLuongNhanVien(int maNhanVien)
        {
            return dalBangLuong.GetLastMaLuongNhanVien(maNhanVien);
        }
        public DTO_BangLuong GetLastBangLuongByMaNhanVien(int maNhanVien)
        {
            return dalBangLuong.GetLastBangLuongByMaNhanVien(maNhanVien);
        }
        public DTO_BangLuong GetBangLuongByMaLuong(int maLuong)
        {
            return dalBangLuong.GetBangLuongByMaLuong(maLuong);
        }
        public DataTable GetBangLuong(int maNhanVien, int thang, int nam)
        {
            return dalBangLuong.GetBangLuong(maNhanVien, thang, nam);
        }
        public bool AddBangLuong(int maNhanVien, int thang, int nam, int tongLuong, string trangThai)
        {
            return dalBangLuong.AddBangLuong(maNhanVien, thang, nam, tongLuong, trangThai);
        }
        public bool UpdateBangLuong(int maLuong, int soNgayCong, DateTime ngayChoLuong, string trangThai)
        {
            return dalBangLuong.UpdateBangLuong(maLuong, soNgayCong, ngayChoLuong, trangThai);
        }
        public bool UpdateBangLuong(int maLuong, int soNgayCong)
        {
            return dalBangLuong.UpdateBangLuong(maLuong, soNgayCong);
        }
        public int GetLastMaLuong()
        {
            return dalBangLuong.GetLastMaLuong();
        }
    }
}
