using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_BangChamCong
    {
        private int maChamCong;
        private int maNhanVien;
        private int maCa;
        private DateTime ngayChamCong;
        private TimeSpan gioVao;
        private TimeSpan gioRa;
        private string trangThai;
        public DTO_BangChamCong()
        {
            maChamCong = 0;
            maNhanVien = 0;
            ngayChamCong = DateTime.Now;
            gioVao = new TimeSpan(0, 0, 0);
            gioRa = new TimeSpan(0, 0, 0);
            trangThai = "Chưa chấm công";
        }
        public DTO_BangChamCong(int maChamCong, int maNhanVien, DateTime ngayChamCong, TimeSpan gioVao, TimeSpan gioRa, string trangThai, int maCa)
        {
            this.maChamCong = maChamCong;
            this.maNhanVien = maNhanVien;
            this.ngayChamCong = ngayChamCong;
            this.gioVao = gioVao;
            this.gioRa = gioRa;
            this.trangThai = trangThai;
            this.maCa = maCa;
        }

        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public DateTime NgayChamCong { get => ngayChamCong; set => ngayChamCong = value; }
        public TimeSpan GioVao { get => gioVao; set => gioVao = value; }
        public TimeSpan GioRa { get => gioRa; set => gioRa = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public int MaChamCong { get => maChamCong; set => maChamCong = value; }
        public int MaCa
        {
            get => maCa; set => maCa = value;
        }
    }
}
