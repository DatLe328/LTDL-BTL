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
        private DateTime ngayGioBatDau;
        private DateTime ngayGioKetThuc;
        public DTO_CaLamViec()
        {
            MaCa = 0;
            NgayGioBatDau = DateTime.Now;
            NgayGioKetThuc = DateTime.Now;
        }
        public DTO_CaLamViec(int maCa, DateTime ngayGioBatDau, DateTime ngayGioKetThuc)
        {
            this.MaCa = maCa;
            this.NgayGioBatDau = ngayGioBatDau;
            this.NgayGioKetThuc = ngayGioKetThuc;
        }

        public int MaCa { get => maCa; set => maCa = value; }
        public DateTime NgayGioBatDau { get => ngayGioBatDau; set => ngayGioBatDau = value; }
        public DateTime NgayGioKetThuc { get => ngayGioKetThuc; set => ngayGioKetThuc = value; }
    }
}
