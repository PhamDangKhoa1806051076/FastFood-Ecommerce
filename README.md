# FastFood Ecommerce - ASP.NET Core MVC

Dự án Thương mại điện tử FastFood (Bài tập báo cáo chuyên môn môn Lập trình Web). Đây là một ứng dụng Web hoàn chỉnh được xây dựng với kiến trúc 3 lớp hiện đại, giao diện Premium và đầy đủ các tính năng nghiệp vụ.

## 1. CÔNG NGHỆ SỬ DỤNG (TECH STACK)
*   **Framework**: ASP.NET Core 9.0 MVC.
*   **Backend**: C# / .NET.
*   **Database**: SQL Server.
*   **ORM**: Entity Framework Core (Code-First approach).
*   **Frontend**: HTML5, CSS3, JavaScript (AJAX, jQuery).
*   **Aesthetics**: Vanilla CSS (Custom Premium Design), FontAwesome, Google Fonts, Animate.css.
*   **Analytics**: Chart.js (Real-time data visualization).

## 2. TÍNH NĂNG NỔI BẬT (KEY FEATURES)

### 🛒 Khách hàng (User Experience)
*   **Trang chủ Dynamic**: Hiển thị món ăn theo danh mục với hiệu ứng AJAX mượt mà.
*   **Bộ lọc nâng cao**: Tìm kiếm món ăn theo khoảng giá, mức đánh giá (số sao) và sắp xếp thông minh.
*   **Giỏ hàng & Thanh toán**: Xử lý Session, tích hợp hệ thống **Voucher** giảm giá theo %.
*   **Hệ thống Đánh giá**: Xem đánh giá trung bình và gửi nhận xét cá nhân cho từng món ăn.
*   **Lịch sử đơn hàng**: Theo dõi các đơn hàng đã đặt kèm trạng thái chi tiết.
*   **Đa ngôn ngữ**: Hỗ trợ toàn diện Tiếng Việt, Tiếng Anh, Tiếng Hàn.
*   **Hệ thống cửa hàng**: Tích hợp Google Maps để tìm kiếm chi nhánh gần nhất.

### 🛡️ Quản trị viên (Admin Dashboard)
*   **Dashboard Thông minh**: Thống kê doanh thu thực tế, số lượng đơn hàng, sản phẩm và Voucher.
*   **Biểu đồ Doanh thu**: Trực quan hóa dữ liệu bằng Chart.js (Sản phẩm bán chạy & Xu hướng).
*   **Quản lý CRUD**: Quản lý danh mục, sản phẩm, Voucher và hệ thống cửa hàng.
*   **Quản lý đơn hàng**: Theo dõi và cập nhật trạng thái đơn hàng của khách hàng.

## 3. CẤU TRÚC THƯ MỤC (PROJECT STRUCTURE)
*   `/Models`: Các thực thể dữ liệu (`Product`, `Review`, `Voucher`, `Order`, etc.).
*   `/Data`: `ApplicationDbContext` và `DbInitializer` (Nạp dữ liệu mẫu).
*   `/Controllers`: Điều hướng logic nghiệp vụ (`Home`, `Cart`, `Admin`, `Product`, etc.).
*   `/Views`: Giao diện người dùng và trang quản trị Dashboard.
*   `/Helpers`: Các tiện ích mở rộng (Session, Đa ngôn ngữ).
*   `/wwwroot`: Tài nguyên tĩnh (CSS, JS, Hình ảnh).

## 4. HƯỚNG DẪN CÀI ĐẶT (SETUP)
1.  **Clone dự án**: `git clone [URL_GITHUB]`
2.  **Cấu hình Database**: Cập nhật Connection String trong `appsettings.json`.
3.  **Migration**: 
    ```bash
    dotnet ef database update
    ```
4.  **Chạy ứng dụng**: Nhấn `F5` hoặc `dotnet run`. Hệ thống sẽ tự động nạp dữ liệu mẫu (Seed Data) trong lần chạy đầu tiên.

## 5. LỘ TRÌNH PHÁT TRIỂN (ROADMAP)
*   ✅ **Giai đoạn 1-4**: Khởi tạo, Giao diện, Giỏ hàng & Bảo mật.
*   ✅ **Giai đoạn 5**: Voucher, Store Locator & Đa ngôn ngữ.
*   ✅ **Giai đoạn 6-7**: Lịch sử đơn hàng & Hệ thống Đánh giá (Rating).
*   ✅ **Giai đoạn 8**: Dashboard Admin & Biểu đồ Chart.js.
*   ✅ **Giai đoạn 9**: Hoàn thiện Bộ lọc nâng cao & Tối ưu hóa UI/UX.

## 6. NHẬT KÝ CẬP NHẬT GẦN ĐÂY (CHANGELOG)
**Tháng 5/2026:**
*   **Tinh chỉnh UI/UX Trang chủ**: Xóa bỏ tab "Tất cả sản phẩm" để tập trung hiển thị danh mục đầu tiên, tối ưu thời gian cuộn slide của Banner (5 giây/lượt) giúp giao diện gọn gàng và chuyên nghiệp.
*   **Hoàn thiện Chế độ Tối (Dark Mode)**: Thêm nút chuyển đổi giao diện Sáng/Tối trực quan trên thanh công cụ. Tối ưu hóa triệt để độ tương phản của mã màu CSS (`site.css`) đảm bảo toàn bộ menu, chữ, nội dung đều rõ nét và tự động đảo màu nền khi sử dụng ban đêm.
*   **Sửa lỗi & Cập nhật Dữ liệu (Database)**: Xử lý dứt điểm tình trạng lỗi bộ mã UTF-8 tiếng Việt. Cấu hình lại bộ dữ liệu mẫu (Seed Data) với hệ thống hình ảnh sản phẩm (Burger, Cơm, Mì Ý, Tráng miệng,...) chất lượng cao từ Unsplash, khắc phục tình trạng hiển thị sai hình ảnh.
