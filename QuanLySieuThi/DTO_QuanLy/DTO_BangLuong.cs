using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_BangLuong
    {
        private int maLuong;
        private int maNhanVien;
        private int thang;
        private int nam;
        private int tongLuong;
        private int soNgayCong;
        private DateTime ngayChotLuong;
        private string trangThai;
        public DTO_BangLuong()
        {
            maLuong = 0;
            maNhanVien = 0;
            thang = 0;
            nam = 0;
            soNgayCong = 0;
            ngayChotLuong = DateTime.Now;
            trangThai = string.Empty;
        }
        public DTO_BangLuong(int maLuong, int maNhanVien, int thang, int nam, int tongLuong, int soNgayCong, DateTime ngayChotLuong, string trangThai)
        {
            this.maLuong = maLuong;
            this.maNhanVien = maNhanVien;
            this.thang = thang;
            this.tongLuong = tongLuong;
            this.nam = nam;
            this.soNgayCong = soNgayCong;
            this.ngayChotLuong = ngayChotLuong;
            this.trangThai = trangThai;
        }

        public int MaLuong { get => maLuong; set => maLuong = value; }
        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public int Thang { get => thang; set => thang = value; }
        public int Nam { get => nam; set => nam = value; }
        public int SoNgayCong { get => soNgayCong; set => soNgayCong = value; }
        public DateTime NgayChotLuong { get => ngayChotLuong; set => ngayChotLuong = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public int TongLuong
        {
            get => tongLuong;
            set
            {
                if (value < 0)
                    throw new ArgumentException("TongLuong cannot be negative.");
                tongLuong = value;
            }
        }
    }
}
