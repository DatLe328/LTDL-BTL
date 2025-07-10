using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_NhanVien
    {
        private int maNhanVien;
        private int maChucVu;
        private string tenNhanVien;
        private string diaChi;
        private string soDienThoai;
        private DateTime ngaySinh;
        private bool gioiTinh;
        public DTO_NhanVien()
        {
            MaNhanVien = 0;
            TenNhanVien = "";
            DiaChi = "";
            SoDienThoai = "";
            NgaySinh = DateTime.Now;
            GioiTinh = true;
        }
        public DTO_NhanVien(int maNhanVien, int maTaiKhoan, int maChucVu, string tenNhanVien, string diaChi, string soDienThoai, DateTime ngaySinh, bool gioiTinh)
        {
            this.MaNhanVien = maNhanVien;
            this.TenNhanVien = tenNhanVien;
            this.DiaChi = diaChi;
            this.SoDienThoai = soDienThoai;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.MaChucVu = maChucVu;
        }
        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public int MaChucVu { get => maChucVu; set => maChucVu = value; }
    }
}
