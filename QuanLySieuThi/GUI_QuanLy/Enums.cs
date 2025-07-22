using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_QuanLy
{
    public enum LoaiKhoan
    {
        [Description("Lương cơ bản")]
        LuongCoBan = 0,
        [Description("Thưởng")]
        Thuong = 1,
        [Description("Phụ cấp")]
        PhuCap = 2,
        [Description("Phạt")]
        Phat = 3,
        [Description("Khác")]
        Khac = 4
    }
    public enum PhanQuyen
    {
        [Description("Quản lý nhân viên")]
        QuanLyNhanVien = 0,
        [Description("Quản lý lương")]
        QuanLyLuong = 1,
        [Description("Quản lý kho")]
        QuanLyKho = 2,
        [Description("Quản lý bán hàng")]
        QuanLyBanHang = 3,
        [Description("Quản lý báo cáo")]
        QuanLyBaoCao = 4
    }
    public enum TrangThaiBangLuong
    {
        [Description("Đang xử lý")]
        DangXuLy = 0,
        [Description("Đã xử lý")]
        DaXuLy = 1,
    }
    public enum TrangThaiChamCong
    {
        [Description("Đang làm việc")]
        DangLamViec = 0,
        [Description("Đã chấm công")]
        DaChamCong = 1
    }
}
