# 🚀 Hướng dẫn Triển khai Hệ thống (Deployment Guide)

Tài liệu này hướng dẫn cách đưa ứng dụng **FastFood Ecommerce** từ môi trường phát triển lên môi trường Production.

## 1. Yêu cầu chuẩn bị
* Tài khoản **GitHub** để chứa mã nguồn.
* Tài khoản **Azure** (hoặc VPS tương đương) để hosting.
* Một database **SQL Server Production** (khuyên dùng Azure SQL Database).

## 2. Cấu hình Database
1. Tạo một Database mới trên Azure SQL.
2. Lấy **Connection String** và cập nhật vào `appsettings.Production.json` hoặc cấu hình trong **Environment Variables** của Hosting.
3. Chạy lệnh migration để tạo bảng trên Production:
   ```bash
   dotnet ef database update --environment Production
   ```

## 3. Thiết lập CI/CD (GitHub Actions)
Ứng dụng đã được tích hợp sẵn file cấu hình tại `.github/workflows/main.yml`.
1. Truy cập vào Repository trên GitHub.
2. Vào mục **Settings > Secrets and variables > Actions**.
3. Thêm một Secret mới tên là `AZUREAPPSERVICE_PUBLISHPROFILE`.
4. Dán nội dung **Publish Profile** (tải về từ Azure App Service) vào đây.
5. Mỗi khi bạn `push` code lên nhánh `main`, hệ thống sẽ tự động Build, Test và Deploy lên Azure.

## 4. Cấu hình Bảo mật & HTTPS
* **SSL/TLS:** Azure App Service tự động cung cấp HTTPS cho domain `*.azurewebsites.net`.
* **HSTS:** Đã được bật trong `Program.cs` để ép buộc trình duyệt luôn sử dụng HTTPS.
* **Environment Variables:** Luôn đặt `ASPNETCORE_ENVIRONMENT` thành `Production` trên server để tối ưu hiệu năng và bảo mật.

## 5. Kiểm tra sau khi triển khai (Smoke Test)
Sau khi deploy thành công, hãy kiểm tra các bước sau:
1. Truy cập URL trang web.
2. Đăng ký/Đăng nhập tài khoản.
3. Thử đặt một đơn hàng mới.
4. Vào trang Admin kiểm tra biểu đồ và xuất báo cáo Excel.
5. Kiểm tra tính năng Bản đồ (Store Locator) xem Leaflet có hiển thị đúng không.

## 6. Bảo trì và Vận hành
* **Logs:** Xem logs trực tiếp trên Azure Log Stream hoặc Application Insights.
* **Backup:** Cấu hình tự động backup Database hàng ngày trên Azure.

---
*Chúc mừng bạn đã đưa ứng dụng lên môi trường Production thành công!* 🎊
