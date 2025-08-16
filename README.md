# Hệ thống Quản lý Nội vụ Siêu thị (C# WinForms + SQL Server)

> Một ứng dụng desktop hỗ trợ quản lý **nhân sự, ca làm, hàng hóa/kho, đặt hàng – hóa đơn – lô hàng, chi phí và báo cáo thống kê** cho siêu thị. Dự án được xây dựng bằng C# (.NET) và Microsoft SQL Server.

## 💡 Điểm nhấn nhanh
- Tổ chức dữ liệu chuẩn hoá theo ERD/RD, phân quyền theo vai trò (quản lý, thủ kho, nhân sự, kế toán).  
- Các phân hệ đầy đủ: đăng nhập – chấm công – quản lý hàng hóa/lô hàng – hóa đơn mua – đặt hàng – nhân viên – ca làm – tính lương – báo cáo – chi phí.
- Kiến trúc tách lớp **UI (WinForms) / Services / Data Access**; có thể mở rộng sang WPF hoặc Web sau này.
- Tài liệu phân tích đi kèm: sơ đồ ngữ cảnh, DFD, ERD; kế hoạch mở rộng (POS, cảnh báo tồn kho, AI gợi ý lịch/nhập hàng).

## 🧰 Công nghệ
- **Ngôn ngữ**: C# (.NET Desktop)
- **UI**: WinForms
- **DB**: Microsoft SQL Server
- **ORM**: ADO.NET

## 🖼️ Ảnh màn hình

![login.png](docs/screenshots/Screenshot%202025-08-13%20161153.png)
![main.png](docs/screenshots/Screenshot%202025-08-13%20161819.png)
![order.png](docs/screenshots/Screenshot%202025-08-13%20162533.png)
![payrool.png](docs/screenshots/Screenshot%202025-08-13%20163247.png)
![chart.png](docs/screenshots/Screenshot%202025-08-13%20163353.png)

## 🧰 Công nghệ
- **Ngôn ngữ**: C# (.NET Desktop)
- **UI**: WinForms (có thể thay bằng WPF)
- **DB**: Microsoft SQL Server
- **ORM/Truy vấn**: ADO.NET/Repository pattern (hoặc Dapper/EF – tuỳ lựa chọn)

## ⚙️ Cài đặt & chạy

1. Cài **.NET Desktop Development** và **SQL Server** (Developer/Express).
2. Tạo DB:
   - Mở SQL Server Management Studio (SSMS)
   - Tạo DB `SupermarketMgmt`
   - Chạy `init.sql`
- Tạo file `.env` trong thư mục `DAL_QuanLy` 
```text
DB_SERVER=(localdb)\localhost
DB_DATABASE=QLST
```