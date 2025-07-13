using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_ChiPhi
    {
        private int maChiPhi;
        private int maNhanVien;
        private string tenChiPhi;
        private DateTime ngayLap;
        private int soTien;
        private string moTa;
        public DTO_ChiPhi()
        {
            MaChiPhi = 0;
            TenChiPhi = "";
            NgayLap = DateTime.Now;
            SoTien = 0;
            MoTa = "";
        }
        public DTO_ChiPhi(int maChiPhi, string tenChiPhi, DateTime ngayLap, int soTien, string moTa, int maNhanVien)
        {
            this.MaChiPhi = maChiPhi;
            this.TenChiPhi = tenChiPhi;
            this.NgayLap = ngayLap;
            this.SoTien = soTien;
            this.MoTa = moTa;
            this.MaNhanVien = maNhanVien;
        }
        public int MaChiPhi { get => maChiPhi; set => maChiPhi = value; }
        public string TenChiPhi { get => tenChiPhi; set => tenChiPhi = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public int SoTien { get => soTien; set => soTien = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public int MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
    }
}
