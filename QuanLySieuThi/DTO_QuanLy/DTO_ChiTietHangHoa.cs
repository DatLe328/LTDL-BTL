using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_ChiTietHangHoa
    {
        private int maKho;
        private int maHangHoa;
        private int soLuongTrungBay;
        private int soLuongTonKho;
        public DTO_ChiTietHangHoa()
        {
            MaKho = 0;
            MaHangHoa = 0;
            SoLuongTrungBay = 0;
            SoLuongTonKho = 0;
        }
        public DTO_ChiTietHangHoa(int maKho, int maHangHoa, int soLuongTrungBay, int soLuongTonKho)
        {
            this.MaKho = maKho;
            this.MaHangHoa = maHangHoa;
            this.SoLuongTrungBay = soLuongTrungBay;
            this.SoLuongTonKho = soLuongTonKho;
        }
        public int MaKho { get => maKho; set => maKho = value; }
        public int MaHangHoa { get => maHangHoa; set => maHangHoa = value; }
        public int SoLuongTrungBay { get => soLuongTrungBay; set => soLuongTrungBay = value; }
        public int SoLuongTonKho { get => soLuongTonKho; set => soLuongTonKho = value; }
    }
}
