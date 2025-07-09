using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_KhachHang
    {
        DAL_KhachHang dalKhachHang;
        public BUS_KhachHang()
        {
            dalKhachHang = new DAL_KhachHang();
        }
        public DataTable GetAllKhachHang()
        {
            return dalKhachHang.GetAllKhachHang();
        }
        public bool AddKhachHang(string ten, string diaChi, string soDienThoai)
        {
            return dalKhachHang.AddKhachHang(ten, diaChi, soDienThoai);
        }
        public bool UpdateKhachHang(int maKhachHang, string ten, string diaChi, string soDienThoai)
        {
            return dalKhachHang.UpdateKhachHang(maKhachHang, ten, diaChi, soDienThoai);
        }
        public bool DeleteKhachHang(int maKhachHang)
        {
            return dalKhachHang.DeleteKhachHang(maKhachHang);
        }
        public DataTable SearchKhachHang(string keyword)
        {
            return dalKhachHang.SearchKhachHang(keyword);
        }
    }
}
