# FastFood Ecommerce - Lập Trình Web

Dự án Thương mại điện tử FastFood (Bài tập báo cáo chuyên môn môn Lập trình Web).

## 1. CÔNG NGHỆ SỬ DỤNG (TECH STACK)
*   **Kiến trúc**: ASP.NET Core MVC.
*   **Backend**: C#.
*   **Database**: SQL Server.
*   **ORM**: Entity Framework Core (Tiếp cận Code-First).
*   **Frontend**: HTML5, CSS3, JavaScript/TypeScript.

## 2. YÊU CẦU NỘI DUNG MÔN HỌC (10 MỤC BẮT BUỘC)
*   **01.** Thiết kế website với HTML, CSS và JavaScript.
*   **02.** Tạo ứng dụng web với ASP.NET Core MVC.
*   **03.** Controller và Action xử lý logic nghiệp vụ.
*   **04.** View và Layout (`_Layout.cshtml`) để đồng bộ giao diện.
*   **05.** Model và Entity Framework Core để quản lý Database SQL Server.
*   **06.** Form và Validation (kiểm tra dữ liệu đầu vào đơn hàng).
*   **07.** Routing (định tuyến đường dẫn thân thiện).
*   **08.** Authentication và Authorization (Đăng nhập & Phân quyền Admin/User).
*   **09.** Dependency Injection (Cấu hình dịch vụ trong `Program.cs`).
*   **10.** Kiểm thử và triển khai ứng dụng.

## 3. CẤU TRÚC THƯ MỤC (PROJECT STRUCTURE)
Cấu trúc dự án theo chuẩn ASP.NET Core MVC (Đơn giản, gọn gàng và chuyên nghiệp):
*   `/Models`: Chứa các thực thể dữ liệu (`Product`, `Category`, `Order`, `OrderDetail`).
*   `/Data`: Chứa `ApplicationDbContext` để kết nối SQL Server qua EF Core.
*   `/Controllers`: Chứa các bộ điều khiển logic (`Home`, `Cart`, `Admin`).
*   `/Views`: Chứa giao diện người dùng (Front-end) và trang quản trị (Admin).
*   `/wwwroot`: Chứa tài nguyên tĩnh (`Images`, `CSS`, `JS`).

## 4. CÁC TÍNH NĂNG CHÍNH CỦA WEB BÁN THỨC ĂN NHANH
*   **Khách hàng (User)**:
    *   Xem danh mục món ăn, tìm kiếm.
    *   Quản lý Giỏ hàng (sử dụng Session/Cookie).
    *   Đặt hàng và theo dõi tình trạng đơn hàng.
*   **Quản trị viên (Admin)**:
    *   Dashboard thống kê cơ bản.
    *   CRUD món ăn (Thêm/Sửa/Xóa sản phẩm, danh mục).
    *   Quản lý trạng thái các đơn hàng.

## 5. LỘ TRÌNH THỰC THI (ROADMAP)
*   **Giai đoạn 1**: Thiết kế Model và cấu hình Database SQL Server bằng EF Core.
*   **Giai đoạn 2**: Xây dựng giao diện Layout và trang danh sách món ăn (Frontend).
*   **Giai đoạn 3**: Xử lý logic giỏ hàng và đặt hàng (Backend).
*   **Giai đoạn 4**: Tích hợp bảo mật, phân quyền Admin và kiểm thử toàn bộ hệ thống.