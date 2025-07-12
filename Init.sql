CREATE DATABASE QLST
GO
USE QLST
-- Bảng nhà cung cấp
CREATE TABLE NhaCungCap (
    MaNCC VARCHAR(20) PRIMARY KEY,
    TenNCC VARCHAR(100),
    SDT VARCHAR(15),
    Email VARCHAR(100),
    DiaChi TEXT,
    GiayPhepKD VARCHAR(50),
    MaSoThue VARCHAR(50),
    STK VARCHAR(50)
);

-- Bảng hóa đơn mua
CREATE TABLE HoaDonMua (
    MaPhieuNhap VARCHAR(20) PRIMARY KEY,
    MaNCC VARCHAR(20),
    NgayNhap DATE,
    TongTien DECIMAL(15,2),
    GhiChu TEXT,
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);

-- Bảng kho hàng
CREATE TABLE KhoHang (
    MaKho VARCHAR(20) PRIMARY KEY,
    TenKho VARCHAR(100),
    DiaChi TEXT
);

-- Bảng loại hàng hóa
CREATE TABLE LoaiHangHoa (
    MaLoaiHangHoa NVARCHAR(20) PRIMARY KEY,
    TenLoaiHangHoa NVARCHAR(100)
);
drop table LoaiHangHoa
drop table HangHoa
-- Bảng hàng hóa
CREATE TABLE HangHoa (
    MaHangHoa int PRIMARY KEY IDENTITY,
    TenHangHoa VARCHAR(100),
    GiaBan int,
    DonViTinh VARCHAR(50),
    MaLoaiHangHoa NVARCHAR(20),
    FOREIGN KEY (MaLoaiHangHoa) REFERENCES LoaiHangHoa(MaLoaiHangHoa)
);

insert into LoaiHangHoa 
values(2, N'Bánh')
insert into HangHoa(TenHangHoa, GiaBan, DonViTinh, MaLoaiHangHoa)
values(N'sting', 10, 'Chai', 1)
insert into HangHoa(TenHangHoa, GiaBan, DonViTinh, MaLoaiHangHoa)
values(N'7up', 7, 'Chai', 2)
-- Chi tiết hóa đơn mua
CREATE TABLE ChiTietDonMua (
    MaPhieuNhap VARCHAR(20),
    MaHangHoa VARCHAR(20),
    SoLuong INT,
    DonGia DECIMAL(15,2),
    NSX DATE,
    HSD DATE,
    PRIMARY KEY (MaPhieuNhap, MaHangHoa),
    FOREIGN KEY (MaPhieuNhap) REFERENCES HoaDonMua(MaPhieuNhap),
    FOREIGN KEY (MaHangHoa) REFERENCES HangHoa(MaHangHoa)
);

-- Nhập kho
CREATE TABLE NhapKho (
    MaPhieuNhap VARCHAR(20),
    MaKho VARCHAR(20),
    PRIMARY KEY (MaPhieuNhap, MaKho),
    FOREIGN KEY (MaPhieuNhap) REFERENCES HoaDonMua(MaPhieuNhap),
    FOREIGN KEY (MaKho) REFERENCES KhoHang(MaKho)
);

-- Thuộc hàng hóa trong kho
CREATE TABLE Thuoc (
    MaHangHoa VARCHAR(20),
    MaKho VARCHAR(20),
    SoLuongTonKho INT,
    SoLuongTrungBay INT,
    PRIMARY KEY (MaHangHoa, MaKho),
    FOREIGN KEY (MaHangHoa) REFERENCES HangHoa(MaHangHoa),
    FOREIGN KEY (MaKho) REFERENCES KhoHang(MaKho)
);

-- Bảng khuyến mãi
CREATE TABLE KhuyenMai (
    MaGiamGia VARCHAR(20) PRIMARY KEY,
    NgayBatDau DATE,
    NgayKetThuc DATE
);

-- Chi tiết khuyến mãi
CREATE TABLE ChiTietKhuyenMai (
    MaHangHoa VARCHAR(20),
    MaGiamGia VARCHAR(20),
    GiamGia DECIMAL(5,2),
    MoTa TEXT,
    LoaiGiamGia VARCHAR(50),
    PRIMARY KEY (MaHangHoa, MaGiamGia),
    FOREIGN KEY (MaHangHoa) REFERENCES HangHoa(MaHangHoa),
    FOREIGN KEY (MaGiamGia) REFERENCES KhuyenMai(MaGiamGia)
);

-- Khách hàng
CREATE TABLE KhachHang (
    MaKhachHang VARCHAR(20) PRIMARY KEY,
    HoTenKH VARCHAR(100),
    SDT VARCHAR(15),
    Email VARCHAR(100),
    DiaChi TEXT
);

-- Hóa đơn bán
CREATE TABLE HoaDonBan (
    MaHD VARCHAR(20) PRIMARY KEY,
    MaKhachHang VARCHAR(20),
    TongTien DECIMAL(15,2),
    TrangThai VARCHAR(20),
    ThoiGianDat DATETIME,
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);

-- Chi tiết đơn bán
CREATE TABLE ChiTietDonBan (
    MaHD VARCHAR(20),
    MaHangHoa VARCHAR(20),
    SoLuong INT,
    DonGia DECIMAL(15,2),
    PRIMARY KEY (MaHD, MaHangHoa),
    FOREIGN KEY (MaHD) REFERENCES HoaDonBan(MaHD),
    FOREIGN KEY (MaHangHoa) REFERENCES HangHoa(MaHangHoa)
);

-- Tài khoản
CREATE TABLE TaiKhoan (
    MaTaiKhoan VARCHAR(20) PRIMARY KEY,
    TenTaiKhoan VARCHAR(50),
    MatKhau VARCHAR(100)
);

-- Nhân viên
CREATE TABLE NhanVien (
    MaNhanVien VARCHAR(20) PRIMARY KEY,
    TenNV VARCHAR(100),
    Email VARCHAR(100),
    NgaySinh DATE,
    MaTaiKhoan VARCHAR(20),
    FOREIGN KEY (MaTaiKhoan) REFERENCES TaiKhoan(MaTaiKhoan)
);

-- Chức vụ
CREATE TABLE ChucVu (
    MaChucVu VARCHAR(20) PRIMARY KEY,
    TenChucVu VARCHAR(100),
    MucLuong DECIMAL(15,2)
);

-- Xác nhận nhân viên - chức vụ
CREATE TABLE XacNhan (
    MaNhanVien VARCHAR(20),
    MaChucVu VARCHAR(20),
    PRIMARY KEY (MaNhanVien, MaChucVu),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaChucVu) REFERENCES ChucVu(MaChucVu)
);

-- Chấm công
CREATE TABLE ChamCong (
    MaChamCong VARCHAR(20) PRIMARY KEY,
    MaNhanVien VARCHAR(20),
    HoTenNV VARCHAR(100),
    TrangThai VARCHAR(50),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

-- Bảng chấm công (chi tiết theo ngày)
CREATE TABLE BangChamCong (
    MaChamCong VARCHAR(20),
    NgayGioVao DATETIME,
    NgayGioRa DATETIME,
    PRIMARY KEY (MaChamCong, NgayGioVao),
    FOREIGN KEY (MaChamCong) REFERENCES ChamCong(MaChamCong)
);

-- Ca làm việc
CREATE TABLE CaLamViec (
    MaCa VARCHAR(20) PRIMARY KEY,
    Ngay DATE,
    GioBatDau TIME,
    GioKetThuc TIME
);

-- Giao ca làm việc
CREATE TABLE ThuocCa (
    MaChamCong VARCHAR(20),
    MaCa VARCHAR(20),
    PRIMARY KEY (MaChamCong, MaCa),
    FOREIGN KEY (MaChamCong) REFERENCES ChamCong(MaChamCong),
    FOREIGN KEY (MaCa) REFERENCES CaLamViec(MaCa)
);
