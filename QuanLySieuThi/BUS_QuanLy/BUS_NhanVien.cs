using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_NhanVien
    {
        private DAL_QuanLy.DAL_NhanVien dalNhanVien;
        public BUS_NhanVien()
        {
            dalNhanVien = new DAL_QuanLy.DAL_NhanVien();
        }
        public DataTable GetNhanVien()
        {
            return dalNhanVien.GetNhanVien();
        }
        public DataTable GetNhanVien(int maNhanVien)
        {
            return dalNhanVien.GetNhanVien(maNhanVien);
        }
        public DTO_ChucVu GetChucVu(int maNhanVien)
        {
            return dalNhanVien.GetChucVu(maNhanVien);
        }
        public int GetLastMaNhanVien()
        {
            return dalNhanVien.GetLastMaNhanVien();
        }
        public bool AddNhanVien(string hoTenNV, string soDienThoai, string email, DateTime ngaySinh, int maChucVu)
        {
            return dalNhanVien.AddNhanVien(hoTenNV, soDienThoai, email, ngaySinh, maChucVu);
        }
        public bool UpdateNhanVien(int maNhanVien, string hoTenNV, string soDienThoai, string email, DateTime ngaySinh, int maChucVu)
        {
            return dalNhanVien.UpdateNhanVien(maNhanVien, hoTenNV, soDienThoai, email, ngaySinh, maChucVu);
        }
        public bool DeleteNhanVien(int maNhanVien)
        {
            return dalNhanVien.DeleteNhanVien(maNhanVien);
        }
    }
}
