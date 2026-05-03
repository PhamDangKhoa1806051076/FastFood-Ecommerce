# FastFood Ecommerce - Lập Trình Web

Dự án Thương mại điện tử FastFood được xây dựng theo lộ trình học tập "Lập trình Web" với ASP.NET Core MVC.

## Lộ trình học tập (Curriculum)

Repository này được tổ chức thành các bài học tương ứng với 10 module chính:

1.  **01-HTML-CSS-JS**: Thiết kế website cơ bản với HTML, CSS và JavaScript.
2.  **02-Intro-ASPNetCore-MVC**: Giới thiệu và tạo ứng dụng web với ASP.NET Core MVC.
3.  **03-Controller-Action**: Xây dựng Controller và các Action xử lý yêu cầu.
4.  **04-View-Layout**: Thiết kế giao diện với View và Layout (Razor).
5.  **05-Model-EFCore**: Quản lý dữ liệu với Model và Entity Framework Core.
6.  **06-Form-Validation**: Xử lý Form và kiểm tra dữ liệu (Validation).
7.  **07-Routing**: Cấu hình điều hướng (Routing) trong ứng dụng.
8.  **08-Authentication-Authorization**: Hệ thống đăng nhập và phân quyền.
9.  **09-Dependency-Injection**: Áp dụng Dependency Injection trong .NET.
10. **10-Testing-Deployment**: Kiểm thử ứng dụng và triển khai (Deployment).

## Cấu trúc thư mục

*   `Docs/`: Tài liệu tham khảo và hình ảnh bài học.
*   `Lessons/`: Chứa mã nguồn thực hành cho từng bài học.
*   `Src/`: Mã nguồn chính dự án theo mô hình 3 lớp (3-Layer Architecture):
    *   `GUI/`: Lớp giao diện (Presentation Layer) - ASP.NET Core MVC.
    *   `BUS/`: Lớp xử lý nghiệp vụ (Business Logic Layer).
    *   `DAL/`: Lớp truy cập dữ liệu (Data Access Layer).
    *   `DTO/`: Lớp chứa các đối tượng chuyển đổi dữ liệu và Models dùng chung.

## Công nghệ sử dụng

*   **Front-End**: HTML, CSS, TypeScript, React (optional).
*   **Back-End**: C#, ASP.NET Core MVC.
*   **Database**: SQL Server.
*   **ORM**: Entity Framework Core.