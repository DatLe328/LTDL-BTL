using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_HangHoa
    {
        private int maHangHoa;
        private string tenHangHoa;
        private int maLoaiHangHoa;
        private string donViTinh;
        private int soLuong;
        private int giaBan;
        public DTO_HangHoa()
        {
            MaHangHoa = 0;
            TenHangHoa = "";
            DonViTinh = "";
            SoLuong = 0;
            GiaBan = 0;
        }
        public DTO_HangHoa(int maHangHoa, int maLoaiHangHoa, string tenHangHoa, string donViTinh, int soLuong, int donGia)
        {
            this.MaHangHoa = maHangHoa;
            this.TenHangHoa = tenHangHoa;
            this.DonViTinh = donViTinh;
            this.SoLuong = soLuong;
            this.GiaBan = donGia;
            this.MaLoaiHangHoa = maLoaiHangHoa;
        }
        public int MaHangHoa { get => maHangHoa; set => maHangHoa = value; }
        public string TenHangHoa { get => tenHangHoa; set => tenHangHoa = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int GiaBan { get => giaBan; set => giaBan = value; }
        public int MaLoaiHangHoa { get => maLoaiHangHoa; set => maLoaiHangHoa = value; }
    }
}
