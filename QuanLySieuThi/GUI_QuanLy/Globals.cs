using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_QuanLy
{
    public class Globals
    {
        public static string TenDangNhap { get; set; } = "Tester";
        public static string ChucVu { get; set; } = "Tester";
        public static int MaNhanVien { get; set; } = -1;
        public static int MaChamCong { get; set; } = -1;
        public static TimeSpan ThoiGianTreToiDa { get; } = new TimeSpan(0, 15, 0); // 15 minutes
        public static DayOfWeek StartWorkDay { get; } = DayOfWeek.Monday;
        public static DayOfWeek EndWorkDay { get; } = DayOfWeek.Friday;
        public static bool TuDongTaoCaLamViec { get; set; } = true;
        public static int PhutChoTre { get; set; } = 15;
        public static int TienPhatMoiPhut { get; set; } = 1000;
    }
}
