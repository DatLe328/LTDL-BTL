using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_BangChamCong
    {
        private int maNhanVien;
        private DateTime ngayGioVao;
        private DateTime ngayGioRa;
        private bool trangThai;
        public DTO_BangChamCong()
        {
            MaNhanVien = 0;
            NgayChamCong = DateTime.Now;
            TrangThai = false;
        }
        public DTO_BangChamCong(int maNhanVien, DateTime ngayChamCong, bool trangThai, DateTime ngayGioRa)
        {
            this.MaNhanVien = maNhanVien;
            this.NgayChamCong = ngayChamCong;
            this.TrangThai = trangThai;
            NgayGioRa = ngayGioRa;
        }
        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public DateTime NgayChamCong { get => ngayGioVao; set => ngayGioVao = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
        public DateTime NgayGioRa { get => ngayGioRa; set => ngayGioRa = value; }
    }
}
