using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_CaLamViec
    {
        private int maCa;
        private DateTime ngayLamViec;
        private TimeSpan gioBatDau;
        private TimeSpan gioKetThuc;
        private string ghiChu;

        public DTO_CaLamViec()
        {
            MaCa = 0;
            NgayLamViec = DateTime.Now;
            GioBatDau = TimeSpan.Zero;
            GioKetThuc = TimeSpan.Zero;
            GhiChu = string.Empty;
        }
        public DTO_CaLamViec(int maCa, DateTime ngayLamViec, TimeSpan gioBatDau, TimeSpan gioKetThuc, string ghiChu)
        {
            this.MaCa = maCa;
            this.NgayLamViec = ngayLamViec;
            this.GioBatDau = gioBatDau;
            this.GioKetThuc = gioKetThuc;
            this.GhiChu = ghiChu;
        }

        public int MaCa { get => maCa; set => maCa = value; }
        public DateTime NgayLamViec { get => ngayLamViec; set => ngayLamViec = value; }
        public TimeSpan GioBatDau { get => gioBatDau; set => gioBatDau = value; }
        public TimeSpan GioKetThuc { get => gioKetThuc; set => gioKetThuc = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
