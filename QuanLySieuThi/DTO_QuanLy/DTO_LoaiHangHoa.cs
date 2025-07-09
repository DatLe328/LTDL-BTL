using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_LoaiHangHoa
    {
        private int maLoaiHang;
        private string tenLoaiHang;
        public DTO_LoaiHangHoa()
        {
            MaLoaiHang = 0;
            TenLoaiHang = "";
        }
        public DTO_LoaiHangHoa(int maLoaiHang, string tenLoaiHang)
        {
            this.MaLoaiHang = maLoaiHang;
            this.TenLoaiHang = tenLoaiHang;
        }
        public int MaLoaiHang { get => maLoaiHang; set => maLoaiHang = value; }
        public string TenLoaiHang { get => tenLoaiHang; set => tenLoaiHang = value; }
    }
}
