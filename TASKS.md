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

## ✅ Giai đoạn 4: Bảo mật & Quản trị (Hoàn thành)
- [x] Tích hợp Đăng nhập/Đăng ký (Giao diện & Luồng OTP).
- [x] Phân quyền Admin và Khách hàng (Session-based Auth).
- [x] Xây dựng khu vực Quản trị (Dashboard, CRUD sản phẩm, Quản lý đơn hàng).
- [x] Kiểm thử toàn diện các luồng nghiệp vụ.
- [x] Đồng bộ toàn bộ mã nguồn lên GitHub.

## ✅ Giai đoạn 5: Tính năng mở rộng (Hoàn thành)
- [x] Hệ thống Voucher: Tự động tính hạn dùng.
- [x] Hệ thống Cửa hàng: Bản đồ Google Maps.
- [x] Đa ngôn ngữ (Toàn diện): Hỗ trợ Tiếng Anh, Tiếng Việt, Tiếng Hàn + Flags.
- [x] Menu mở rộng (Hamburger): Sidebar danh mục món ăn.
- [x] Thiết kế Footer Premium (Phong cách KFC).
- [x] Đồng bộ toàn bộ mã nguồn lên GitHub.

## 🏆 Giai đoạn 6: Hoàn thiện & Đóng gói (Hoàn thành)
- [x] Tối ưu hóa hiệu suất và trải nghiệm người dùng (UX).
- [x] Kiểm tra tính tương thích đa ngôn ngữ trên mọi trang.
- [x] Chuẩn bị dữ liệu mẫu (Seed Data) phong phú cho báo cáo.
- [x] Tổng kết dự án và đẩy bản phát hành cuối cùng lên GitHub.

## ✅ Giai đoạn 7: Nâng cao Trải nghiệm Khách hàng (Hoàn thành)
- [x] Xây dựng trang Lịch sử đơn hàng (Hoàn thành UI & Logic).
- [x] Tích hợp hệ thống Đánh giá & Xếp hạng (Hoàn thành Backend & UI).
- [x] Tối ưu hóa bộ lọc món ăn nâng cao (Giá, Đánh giá).

## ✅ Giai đoạn 8: Phân tích Dữ liệu & Báo cáo Thông minh (Hoàn thành)
- [x] Tích hợp biểu đồ doanh thu Chart.js (Hoàn thành UI & Dữ liệu thực tế).
- [x] Thống kê sản phẩm bán chạy và xu hướng đặt hàng thực tế.

## ✅ Giai đoạn 9: Hoàn thiện Voucher & Bộ lọc (Hoàn thành)
- [x] Tích hợp Voucher vào luồng Thanh toán (Áp dụng mã & Trừ tiền).
- [x] Xây dựng giao diện Bộ lọc Nâng cao (Giá, Đánh giá) trên trang chủ.
- [x] Tối ưu hóa logic sắp xếp sản phẩm (Mới nhất, Giá tăng/giảm).
- [x] Cập nhật Database để lưu trữ thông tin giảm giá trong Đơn hàng.
- [x] Đồng bộ toàn bộ mã nguồn lên GitHub.

## ✅ Giai đoạn 10: Bản đồ Cửa hàng Tương tác (Hoàn thành)
- [x] Thay thế Google Maps Embed tĩnh bằng bản đồ Leaflet.js tương tác.
- [x] Hiển thị toàn bộ 30 chi nhánh trên cùng một bản đồ với Marker màu đỏ.
- [x] Bổ sung tọa độ Latitude/Longitude thực tế cho 30 chi nhánh TP.HCM.
- [x] Tích hợp HTML5 Geolocation API để định vị người dùng và tìm cửa hàng gần nhất.
- [x] Sắp xếp danh sách chi nhánh theo khoảng cách sau khi định vị.
- [x] Live Search đồng bộ ẩn/hiện Marker trực tiếp trên bản đồ theo từ khóa tìm kiếm.
- [x] Nâng cấp giao diện danh sách cửa hàng với hiệu ứng hover, badge khoảng cách.
- [x] Đồng bộ toàn bộ mã nguồn lên GitHub.

---

## ✅ Giai đoạn 11: Nâng cấp Trang Chi tiết Sản phẩm & Trải nghiệm Mua hàng (Hoàn thành)
> **Mục tiêu:** Làm phong phú trang sản phẩm giống Shopee/Grab Food — phần này hiện đang khá đơn giản so với thị trường.
- [x] Thêm **Gallery ảnh nhiều hình** cho từng sản phẩm (carousel slideshow).
- [x] Hiển thị **Thông tin dinh dưỡng** (Calo, Protein, Chất béo) dạng bảng trực quan.
- [x] Thêm **"Combo gợi ý" / Sản phẩm thường mua kèm** ngay dưới trang chi tiết.
- [x] Tích hợp **Số lượng tồn kho thực tế** — hiển thị "Sắp hết" khi còn < 10.
- [x] Thêm **nút Yêu thích (Wishlist)** — lưu món ăn vào danh sách để xem lại sau.
- [x] Hiển thị **Nhận xét & Đánh giá** ngay tại trang chi tiết theo dạng phân trang.
- [x] Thêm tính năng **Chia sẻ lên mạng xã hội** (Facebook, Zalo, Copy link).
- [x] Đồng bộ toàn bộ mã nguồn lên GitHub.

## 🔲 Giai đoạn 12: Hệ thống Thành viên & Tích điểm (Loyalty Program)
> **Mục tiêu:** Xây dựng hệ thống giống KFC Rewards / McDonald's App để giữ chân khách hàng quay lại.
- [ ] Tạo Model `LoyaltyPoint` với các cột: `UserId`, `Points`, `ExpiryDate`, `Source`.
- [ ] Tự động cộng điểm sau mỗi đơn hàng thành công (ví dụ: 1 điểm = 1.000đ).
- [ ] Xây dựng trang **"Điểm thưởng của tôi"** trong tài khoản người dùng.
- [ ] Tích hợp **đổi điểm lấy Voucher** giảm giá (Ví dụ: 100 điểm = giảm 20.000đ).
- [ ] Hiển thị **lịch sử cộng/trừ điểm** theo từng đơn hàng.
- [ ] Thêm **Bảng xếp hạng khách hàng** (Hạng Đồng/Bạc/Vàng/Kim Cương) dựa trên tổng chi tiêu.
- [ ] Gửi **thông báo nội bộ** (In-App Notification) khi đạt hạng mới.
- [ ] Đồng bộ toàn bộ mã nguồn lên GitHub.

## 🔲 Giai đoạn 13: Tối ưu hóa Hiệu suất & SEO
> **Mục tiêu:** Đảm bảo ứng dụng nhanh, nhẹ và thân thiện với công cụ tìm kiếm như Google.
- [ ] Tối ưu hóa ảnh sản phẩm: nén ảnh, hỗ trợ định dạng **WebP**, thêm thuộc tính `loading="lazy"`.
- [ ] Cấu hình **Response Caching** và **Output Caching** cho các trang tĩnh nhiều lượt xem.
- [ ] Thêm đầy đủ **Meta Tags SEO** (Title, Description, OG Image) cho từng trang sản phẩm.
- [ ] Tạo file **`sitemap.xml`** tự động liệt kê toàn bộ URL sản phẩm để Google lập chỉ mục.
- [ ] Thêm **Structured Data (Schema.org)** dạng JSON-LD cho sản phẩm (giá, đánh giá, tình trạng).
- [ ] Tối ưu hóa **tốc độ tải trang** (Bundle & Minify CSS/JS với `bundleconfig.json`).
- [ ] Kiểm tra và sửa **Mobile Responsiveness** trên các kích thước màn hình phổ biến.
- [ ] Đồng bộ toàn bộ mã nguồn lên GitHub.

## 🔲 Giai đoạn 14: Quản lý Nâng cao cho Admin & Vận hành
> **Mục tiêu:** Nâng cấp khu vực Admin lên ngang tầm các phần mềm quản lý bán hàng chuyên nghiệp.
- [ ] Thêm tính năng **Quản lý Kho hàng** (Nhập hàng, Xuất hàng, Cảnh báo sắp hết).
- [ ] Xây dựng **Bảng Dashboard thời gian thực** — tổng đơn hàng hôm nay, doanh thu hôm nay, đơn đang chờ.
- [ ] Thêm tính năng **Xuất báo cáo ra file Excel** (doanh thu, đơn hàng, sản phẩm bán chạy).
- [ ] Xây dựng **Quản lý Banner & Khuyến mãi** — Admin tự tạo/ẩn/hiện banner trang chủ.
- [ ] Thêm **Hệ thống Thông báo đẩy (Push Notification)** cho Admin khi có đơn hàng mới.
- [ ] Tạo **Nhật ký hoạt động Admin (Audit Log)** — ghi lại ai sửa gì, lúc mấy giờ.
- [ ] Đồng bộ toàn bộ mã nguồn lên GitHub.

## 🔲 Giai đoạn 15: Triển khai thực tế (Production Deployment)
> **Mục tiêu:** Đưa ứng dụng lên môi trường thật để người dùng bên ngoài có thể truy cập.
- [ ] Đăng ký dịch vụ lưu trữ (Azure App Service / VPS / Render.com).
- [ ] Cấu hình **SQL Server trên môi trường Production** (Azure SQL / SQL Server trên VPS).
- [ ] Cấu hình biến môi trường bảo mật (`ASPNETCORE_ENVIRONMENT=Production`, Connection String).
- [ ] Cấu hình **HTTPS (SSL Certificate)** với Let's Encrypt hoặc Azure Certificate.
- [ ] Thiết lập **CI/CD tự động** qua GitHub Actions — mỗi lần push code lên main sẽ tự deploy.
- [ ] Chạy kiểm thử cuối (Smoke Test) toàn bộ tính năng trên môi trường Production.
- [ ] Viết tài liệu hướng dẫn cài đặt & vận hành đầy đủ cho nhóm phát triển.
- [ ] Đồng bộ toàn bộ mã nguồn lên GitHub.
