using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_LoHang
    {
        private int maLoHang;
        private DateTime ngaySanXuat;
        private DateTime hanSuDung;
        private int soLuong;
        private int soLuongTonKho;
        private int donGia;
        private int maHoaDonMua;
        private int maHangHoa;
        private int maKho;
        public DTO_LoHang()
        {
            MaLoHang = 0;
            NgaySanXuat = DateTime.Now;
            HanSuDung = DateTime.Now.AddMonths(6);
            SoLuong = 0;
            MaHoaDonMua = 0;
        }
        public DTO_LoHang(int maLoHang,DateTime ngaySanXuat, DateTime ngayHetHan, int soLuong, int soLuongTonKho, int donGia, int maNCC, int maSanPham, int maKho)
        {
            this.MaLoHang = maLoHang;
            this.NgaySanXuat = ngaySanXuat;
            this.HanSuDung = ngayHetHan;
            this.SoLuong = soLuong;
            this.MaHangHoa = maSanPham;
            this.MaKho = maKho;
            this.SoLuongTonKho = soLuongTonKho;
            this.DonGia = donGia;
        }

        public int MaLoHang { get => maLoHang; set => maLoHang = value; }
        public DateTime NgaySanXuat { get => ngaySanXuat; set => ngaySanXuat = value; }
        public DateTime HanSuDung { get => hanSuDung; set => hanSuDung = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int MaHoaDonMua { get => maHoaDonMua; set => maHoaDonMua = value; }
        public int MaHangHoa { get => maHangHoa; set => maHangHoa = value; }
        public int MaKho { get => maKho; set => maKho = value; }
        public int SoLuongTonKho { get => soLuongTonKho; set => soLuongTonKho = value; }
        public int DonGia { get => donGia; set => donGia = value; }
    }
}
