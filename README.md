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

## Các bước tiến hành (Implementation Steps)

Quá trình phát triển dự án được chia thành các giai đoạn sau:

1.  **Thiết kế Front-End**: Thiết kế giao diện website với HTML, CSS và JavaScript.
2.  **Khởi tạo Backend**: Tạo ứng dụng web với cấu trúc ASP.NET Core MVC.
3.  **Xây dựng Controller & Action**: Xử lý logic điều hướng và các yêu cầu từ phía người dùng.
4.  **Tích hợp View & Layout**: Kết nối giao diện (Front-End) với ứng dụng thông qua Razor.
5.  **Thiết kế Database (Model & EF Core)**: Xây dựng cơ sở dữ liệu và ánh xạ bằng Entity Framework Core.
6.  **Xử lý Form & Validation**: Xác thực dữ liệu đầu vào.
7.  **Cấu hình Routing**: Xây dựng URL thân thiện và điều hướng người dùng.
8.  **Authentication & Authorization**: Hệ thống đăng nhập, đăng ký và phân quyền người dùng (Admin/Khách hàng).
9.  **Dependency Injection**: Cấu hình các services, kết nối các layer (BUS, DAL).
10. **Kiểm thử & Triển khai**: Thực hiện testing và deploy (triển khai) ứng dụng.