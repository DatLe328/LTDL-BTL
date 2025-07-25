using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_ChiTietLuong
    {
        private DAL_ChiTietLuong dalChiTietLuong;
        public BUS_ChiTietLuong()
        {
            dalChiTietLuong = new DAL_ChiTietLuong();
        }
        public bool AddChiTietLuong(int maLuong, string loaiKhoan, int soTien, string ghiChu)
        {
            return dalChiTietLuong.AddChiTietLuong(maLuong, loaiKhoan, soTien, ghiChu);
        }
        public DataTable GetChiTietLuong(int maNhanVien)
        {
            return dalChiTietLuong.GetChiTietLuong(maNhanVien);
        }
        public int GetTongTienLuong(int maLuong)
        {
            return dalChiTietLuong.GetTongTienLuong(maLuong);
        }
        public bool DeleteChiTietLuong(int maChiTietLuong)
        {
            return dalChiTietLuong.DeleteChiTietLuong(maChiTietLuong);
        }
        public bool UpdateChiTietLuong(int maChiTietLuong, string loaiKhoan, int soTien, string ghiChu)
        {
            return dalChiTietLuong.UpdateChiTietLuong(maChiTietLuong, loaiKhoan, soTien, ghiChu);
        }
        public DataTable ThongKeTatCaLuongTheoLoaiKhoan()
        {
            return dalChiTietLuong.ThongKeTatCaLuongTheoLoaiKhoan();
        }
        public DataTable GetTop5NhanVienLuongCaoNhat()
        {
            return dalChiTietLuong.GetTop5NhanVienLuongCaoNhat();
        }
    
    }
}
