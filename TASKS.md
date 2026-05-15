# 🚀 Kế hoạch Phát triển Dự án FastFood Ecommerce (Consolidated)

Tài liệu này tổng hợp các giai đoạn phát triển trọng tâm, giúp theo dõi tiến độ một cách tinh gọn và hiệu quả.

## ✅ Giai đoạn 1: Nền tảng & Cấu trúc Dữ liệu Core
> **Mục tiêu:** Thiết lập môi trường, cấu trúc DB và giao diện nền tảng.
- [x] Khởi tạo dự án ASP.NET Core MVC (net9.0) & EF Core.
- [x] Định nghĩa Model: `Category`, `Product`, `Order`, `OrderDetail`, `Banner`.
- [x] Cấu hình Database (LocalDB) & thực hiện Migration.
- [x] Xây dựng Layout Premium & Trang chủ hiển thị danh mục/sản phẩm.
- [x] Thiết lập hệ thống nạp dữ liệu mẫu (Seed Data) phong phú.

## ✅ Giai đoạn 2: Lõi Thương mại điện tử (Mua hàng & Đơn hàng)
> **Mục tiêu:** Hoàn thiện luồng mua sắm từ giỏ hàng đến lịch sử đơn hàng.
- [x] Xử lý logic Giỏ hàng (Session/Cookie) & `CartController`.
- [x] Xây dựng Form đặt hàng, Validation & Lưu trữ đơn hàng vào DB.
- [x] Tích hợp hệ thống Đánh giá & Xếp hạng sản phẩm (Backend & UI).
- [x] Xây dựng trang Lịch sử đơn hàng và theo dõi trạng thái.
- [x] Tối ưu hóa bộ lọc món ăn (Giá, Đánh giá) & sắp xếp (Mới nhất, Giá tăng/giảm).

## ✅ Giai đoạn 3: Bảo mật & Hệ thống Khách hàng Thân thiết (Loyalty)
> **Mục tiêu:** Quản lý người dùng và giữ chân khách hàng bằng điểm thưởng.
- [x] Tích hợp Đăng nhập/Đăng ký (Session-based Auth & Luồng OTP).
- [x] Phân quyền Admin/User & Bảo mật các Action nhạy cảm.
- [x] Xây dựng hệ thống Loyalty: Tích điểm (1.000đ = 1 điểm) & Đổi điểm lấy Voucher.
- [x] Trang quản lý thành viên: Hiển thị hạng (Đồng/Bạc/Vàng) & Lịch sử điểm.
- [x] Hệ thống thông báo nội bộ (In-App) khi thăng hạng hoặc cộng điểm.

## ✅ Giai đoạn 4: Trải nghiệm Người dùng & Hệ thống Cửa hàng
> **Mục tiêu:** Nâng cao tương tác và hỗ trợ đa nền tảng/ngôn ngữ.
- [x] Đa ngôn ngữ toàn diện (VI/EN/KO) & Chuyển đổi ngôn ngữ thời gian thực.
- [x] Bản đồ tương tác Leaflet.js: Hiển thị 30+ chi nhánh với tọa độ thực tế.
- [x] Tích hợp Geolocation: Định vị người dùng & tìm cửa hàng gần nhất.
- [x] Nâng cấp Trang chi tiết sản phẩm: Gallery ảnh, Thông tin dinh dưỡng, Sản phẩm gợi ý.
- [x] Tính năng Yêu thích (Wishlist) & Chia sẻ mạng xã hội.

## ✅ Giai đoạn 5: Tiếp thị & Tối ưu hóa Kỹ thuật (SEO/Performance)
> **Mục tiêu:** Tăng tốc độ ứng dụng và khả năng tiếp cận người dùng.
- [x] Hệ thống Voucher: Quản lý mã giảm giá, tự động tính hạn dùng & áp dụng vào thanh toán.
- [x] Cấu hình **Response Caching** & Output Caching tối ưu hiệu suất server.
- [x] Tối ưu SEO: Auto-generated `sitemap.xml`, Meta Tags động cho từng sản phẩm.
- [x] Tích hợp Structured Data (Schema.org) giúp Google hiểu nội dung món ăn.
- [x] Tối ưu Frontend: Nén ảnh WebP, Lazy Loading & Bundle/Minify JS/CSS.

## ✅ Giai đoạn 6: Quản trị & Vận hành Nâng cao (Admin Pro)
> **Mục tiêu:** Cung cấp bộ công cụ quản lý chuyên nghiệp cho chủ cửa hàng.
- [x] Dashboard thời gian thực: Biểu đồ doanh thu (Chart.js), thống kê đơn hàng/khách hàng.
- [x] Quản lý Kho hàng: Cập nhật tồn kho nhanh, cảnh báo "Sắp hết hàng" (<10).
- [x] Quản lý Banner & Slider: Admin tự thay đổi nội dung trang chủ.
- [x] Nhật ký hoạt động (Audit Log): Ghi lại mọi thao tác thêm/xóa/sửa của Admin.
- [x] Xuất báo cáo Sales: Trích xuất dữ liệu đơn hàng ra file Excel (ClosedXML).
- [x] Hệ thống thông báo đẩy (Push) cho Admin khi có đơn hàng mới.

## 🏁 Giai đoạn 7: Hoàn thiện & Triển khai (Production)
> **Mục tiêu:** Đóng gói dự án và đưa lên môi trường thực tế.
- [x] Kiểm thử toàn diện (Smoke Test) & Sửa lỗi cú pháp/cảnh báo.
- [x] Tối ưu hóa UX cuối cùng & Đồng bộ tính nhất quán giữa View/Controller.
- [x] Viết tài liệu hướng dẫn vận hành & triển khai chi tiết (`DEPLOYMENT.md`).
- [x] Cấu hình `appsettings.Production.json` & Biến môi trường bảo mật.
- [ ] Triển khai lên Server (Azure/AWS/VPS) & SQL Server Production.
