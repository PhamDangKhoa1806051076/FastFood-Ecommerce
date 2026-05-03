# FastFood Ecommerce

Dự án Thương mại điện tử FastFood (Bài tập/Báo cáo).

## Công nghệ sử dụng

*   **Front-End**: HTML, CSS, JavaScript (React/Vue/Angular - optional).
*   **Back-End**: C#, ASP.NET Core MVC.
*   **Database**: SQL Server.
*   **ORM**: Entity Framework Core.

## Cấu trúc thư mục

Dự án được tổ chức theo mô hình 3 lớp (3-Layer Architecture):

*   `Docs/`: Tài liệu tham khảo, báo cáo và thiết kế.
*   `Src/`: Mã nguồn chính của dự án:
    *   `GUI/`: Lớp giao diện (Presentation Layer) - ASP.NET Core MVC.
    *   `BUS/`: Lớp xử lý nghiệp vụ (Business Logic Layer).
    *   `DAL/`: Lớp truy cập dữ liệu (Data Access Layer).
    *   `DTO/`: Lớp chứa các đối tượng chuyển đổi dữ liệu và Models.

## Các bước tiến hành (Implementation Details)

Quá trình phát triển dự án được chia thành các giai đoạn chi tiết như sau:

1.  **Thiết kế Front-End (Giao diện người dùng)**:
    *   Thiết kế layout các trang: Trang chủ, Danh mục sản phẩm, Chi tiết sản phẩm, Giỏ hàng, Thanh toán.
    *   Sử dụng HTML, CSS và JavaScript để xây dựng giao diện tương tác.
2.  **Khởi tạo Backend (GUI Layer)**:
    *   Tạo dự án ASP.NET Core MVC trong thư mục `GUI`.
    *   Thiết lập cấu hình ban đầu (Middleware, appsettings.json).
3.  **Xây dựng Controller & Action**:
    *   Tạo các Controller cơ bản (`HomeController`, `ProductController`, `CartController`).
    *   Định nghĩa các Action methods xử lý các HTTP Request (GET, POST).
4.  **Tích hợp View & Layout (Razor)**:
    *   Tạo `_Layout.cshtml` để tái sử dụng giao diện (Header, Footer, Navigation).
    *   Chuyển đổi giao diện HTML thuần thành các Razor Views để hiển thị dữ liệu động.
5.  **Thiết kế Database & Tích hợp SQL Server (DAL & DTO)**:
    *   Phân tích và thiết kế cơ sở dữ liệu: Bảng `Products` (Sản phẩm), `Categories` (Danh mục), `Users` (Người dùng), `Orders` (Đơn hàng).
    *   Cài đặt **Entity Framework Core** và Provider cho **SQL Server**.
    *   Tạo các lớp Entity/Model trong thư mục `DTO`.
    *   Sử dụng phương pháp **Code-First Migrations** để tạo tự động Database trên **SQL Server** từ các class C#.
    *   Viết các hàm truy vấn dữ liệu (CRUD) trong lớp `DAL`.
6.  **Xử lý Form & Validation**:
    *   Xử lý dữ liệu từ các Form (Đăng nhập, Đăng ký, Cập nhật thông tin, Đặt hàng).
    *   Áp dụng Data Annotations để Validation ở Server-side và JavaScript cho Client-side.
7.  **Cấu hình Routing**:
    *   Thiết lập URL thân thiện với SEO (vd: `/san-pham/burger-bo` thay vì `/Product/Detail/1`).
8.  **Authentication & Authorization (Bảo mật)**:
    *   Xây dựng chức năng Đăng nhập, Đăng ký, Đăng xuất sử dụng Cookie Authentication.
    *   Phân quyền ứng dụng: Khu vực dành riêng cho Quản trị viên (Admin Area) và khu vực cho Khách hàng.
9.  **Xử lý Nghiệp vụ & Dependency Injection (BUS Layer)**:
    *   Chuyển logic nghiệp vụ (tính toán giỏ hàng, xử lý thanh toán, giảm giá) vào lớp `BUS`.
    *   Cấu hình Dependency Injection (DI) để tiêm `DAL` vào `BUS` và `BUS` vào `GUI` (Controller), đảm bảo tính lỏng lẻo (loose coupling) của mô hình 3 lớp.
10. **Kiểm thử & Báo cáo**:
    *   Test toàn bộ luồng chức năng (User flow) từ xem hàng đến thanh toán.
    *   Hoàn thiện mã nguồn và chuẩn bị tài liệu báo cáo.