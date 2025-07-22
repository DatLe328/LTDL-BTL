using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_ChiTietLuong
    {
        private int maChiTietLuong;
        private int maLuong;
        private string loaiKhoan;
        private int soTien;
        private string ghiChu;

        public DTO_ChiTietLuong()
        {
            maChiTietLuong = 0;
            maLuong = 0;
            loaiKhoan = string.Empty;
            soTien = 0;
            ghiChu = string.Empty;
        }
        public DTO_ChiTietLuong(int maChiTietLuong, int maLuong, string loaiKhoan, int soTien, string ghiChu)
        {
            this.maChiTietLuong = maChiTietLuong;
            this.maLuong = maLuong;
            this.loaiKhoan = loaiKhoan;
            this.soTien = soTien;
            this.ghiChu = ghiChu;
        }
        public int MaChiTietLuong { get => maChiTietLuong; set => maChiTietLuong = value; }
        public int MaLuong { get => maLuong; set => maLuong = value; }
        public string LoaiKhoan { get => loaiKhoan; set => loaiKhoan = value; }
        public int SoTien { get => soTien; set => soTien = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
