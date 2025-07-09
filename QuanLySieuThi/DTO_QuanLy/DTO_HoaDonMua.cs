using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_HoaDonMua
    {
        private int maHoaDon;
        private int maNhanVien;
        private int maNCC;
        private int maKho;
        private string ghiChu;
        private DateTime ngayLap;
        private int tongTien;
        public DTO_HoaDonMua()
        {
            MaHoaDon = 0;
            MaKhachHang = 0;
            NgayLap = DateTime.Now;
            TongTien = 0;
        }
        public DTO_HoaDonMua(int maHoaDon, int maKhachHang, DateTime ngayLap, int tongTien, int maNCC, int maKho, string ghiChu = "")
        {
            this.MaHoaDon = maHoaDon;
            this.MaKhachHang = maKhachHang;
            this.NgayLap = ngayLap;
            this.TongTien = tongTien;
            this.MaNCC = maNCC;
            this.MaKho = maKho;
            this.GhiChu = ghiChu;
        }
        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public int MaKhachHang { get => maNhanVien; set => maNhanVien = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
        public int MaNCC { get => maNCC; set => maNCC = value; }
        public int MaKho { get => maKho; set => maKho = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
