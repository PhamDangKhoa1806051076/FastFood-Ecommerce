# Tiến độ dự án FastFood Ecommerce

Tài liệu này dùng để theo dõi các đầu việc đã hoàn thành và các việc cần làm tiếp theo.

## ✅ Giai đoạn 1: Cấu hình Database & Model (Hoàn thành)
- [x] Khởi tạo dự án ASP.NET Core MVC (net9.0).
- [x] Cài đặt thư viện Entity Framework Core & SQL Server.
- [x] Định nghĩa các lớp Model: `Category`, `Product`, `Order`, `OrderDetail`.
- [x] Tạo `ApplicationDbContext` để kết nối cơ sở dữ liệu.
- [x] Cấu hình Connection String (LocalDB) trong `appsettings.json`.
- [x] Đăng ký dịch vụ Database trong `Program.cs`.
- [x] Chạy Migration và cập nhật Database lên SQL Server.
- [x] Đồng bộ toàn bộ mã nguồn lên GitHub.

## ✅ Giai đoạn 2: Xây dựng Giao diện & Hiển thị sản phẩm (Hoàn thành)
- [x] Thiết kế Layout chung (`_Layout.cshtml`).
- [x] Tạo các trang giao diện (Front-end) bằng HTML/CSS/JS phong cách Premium.
- [x] Xây dựng `HomeController` để lấy dữ liệu từ Database.
- [x] Hiển thị danh sách món ăn và danh mục lên trang chủ.
- [x] Cấu hình nạp dữ liệu mẫu (Seed Data).
- [x] Đồng bộ toàn bộ mã nguồn lên GitHub.

## ✅ Giai đoạn 3: Giỏ hàng & Đặt hàng (Hoàn thành)
- [x] Xử lý logic Giỏ hàng (Session/Cookie).
- [x] Tạo `CartController`.
- [x] Xây dựng Form đặt hàng và kiểm tra dữ liệu (Validation).
- [x] Lưu đơn hàng vào cơ sở dữ liệu.
- [x] Đồng bộ toàn bộ mã nguồn lên GitHub.

## 🌟 Giai đoạn 5: Tính năng mở rộng (Hoàn thành)
- [x] Hệ thống Voucher: Tự động tính hạn dùng (2 tuần cho lễ, 3-7 ngày cho ngày thường).
- [x] Hệ thống Cửa hàng: Tích hợp bản đồ Google Maps và danh sách cơ sở.
- [x] Đa ngôn ngữ: Hỗ trợ Tiếng Anh, Tiếng Việt, Tiếng Hàn qua Cookie.
- [x] Luồng Đăng nhập mới: Giao diện Split-screen, xác thực qua Số điện thoại (OTP).
- [x] Menu mở rộng (Hamburger): Sidebar danh mục món ăn và thông tin liên hệ.
- [x] Đồng bộ toàn bộ mã nguồn lên GitHub.
