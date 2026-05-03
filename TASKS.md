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

## 🔜 Giai đoạn 2: Xây dựng Giao diện & Hiển thị sản phẩm (Tiếp theo)
- [ ] Thiết kế Layout chung (`_Layout.cshtml`).
- [ ] Tạo các trang giao diện (Front-end) bằng HTML/CSS/JS.
- [ ] Xây dựng `HomeController` để lấy dữ liệu từ Database.
- [ ] Hiển thị danh sách món ăn và danh mục lên trang chủ.
- [ ] Cấu hình Routing cho đường dẫn đẹp.

## 📅 Giai đoạn 3: Giỏ hàng & Đặt hàng
- [ ] Xử lý logic Giỏ hàng (Session/Cookie).
- [ ] Tạo `CartController`.
- [ ] Xây dựng Form đặt hàng và kiểm tra dữ liệu (Validation).
- [ ] Lưu đơn hàng vào cơ sở dữ liệu.

## 🛡️ Giai đoạn 4: Bảo mật & Quản trị
- [ ] Tích hợp Đăng nhập/Đăng ký.
- [ ] Phân quyền Admin và Khách hàng.
- [ ] Xây dựng khu vực Quản trị (CRUD sản phẩm, quản lý đơn hàng).
- [ ] Kiểm thử cuối cùng và đóng gói báo cáo.
