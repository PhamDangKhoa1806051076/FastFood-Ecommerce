-- Script nạp dữ liệu cho SQL Server (FastFood Ecommerce)
-- Lưu ý: Chỉ chạy script này nếu bạn đã tạo cấu trúc bảng (chạy Migration) trước đó và các bảng đang trống.

-- Xóa dữ liệu cũ (Tùy chọn)
-- DELETE FROM [Products];
-- DELETE FROM [Categories];

-- Bật tính năng chèn ID tự động cho Categories
SET IDENTITY_INSERT [Categories] ON;
INSERT INTO [Categories] ([Id], [Name], [Description]) VALUES 
(1, N'Ưu đãi', N'Khuyến mãi hấp dẫn mỗi ngày.'),
(2, N'Combo 1 Người', N'Phần ăn tiết kiệm cho 1 người.'),
(3, N'Combo 2 Người', N'Bữa ăn lý tưởng cho 2 người.'),
(4, N'Combo 4 Người', N'Bữa ăn trọn vẹn cho gia đình.'),
(5, N'Combo Nhóm (5+)', N'Phù hợp cho tiệc tùng, liên hoan.'),
(6, N'Gà Rán - Gà Quay', N'Gà tươi tẩm ướp đậm đà, giòn rụm.'),
(7, N'Burger', N'Burger đa dạng nhân thịt, tôm, cá.'),
(8, N'Cơm & Mì Ý', N'Chắc bụng với cơm và mì Ý xốt đậm đà.'),
(9, N'Thức Ăn Nhẹ', N'Khoai tây chiên, phô mai viên, salad...'),
(10, N'Thức Uống', N'Nước ngọt có gas, trà, nước suối.'),
(11, N'Tráng Miệng', N'Bánh tart trứng, kem béo ngậy.');
SET IDENTITY_INSERT [Categories] OFF;

-- Bật tính năng chèn ID tự động cho Products
SET IDENTITY_INSERT [Products] ON;
INSERT INTO [Products] ([Id], [Name], [Price], [Description], [CategoryId], [ImageUrl], [Calories], [Protein], [Fat], [StockQuantity]) VALUES
(1, N'Siêu Ưu Đãi Gà Rán', 99000, N'Mua 3 Miếng Gà tặng 1 Khoai Vừa', 1, 'https://static.kfcvietnam.com.vn/images/items/lg/3-Fried-Chicken.jpg?v=L7pxv3', 900, 0, 0, 50),
(2, N'Khuyến Mãi Cuối Tuần', 199000, N'Giảm 20% cho combo 4 người', 1, 'https://static.kfcvietnam.com.vn/images/items/lg/CUNG-TIEC.jpg?v=L7pxv3', 1500, 0, 0, 50),

(3, N'Combo 1 Miếng Gà', 59000, N'1 Miếng gà + 1 Khoai Vừa + 1 Pepsi Vừa', 2, 'https://static.kfcvietnam.com.vn/images/items/lg/D-CBO-GA.jpg?v=L7pxv3', 650, 0, 0, 100),
(4, N'Combo Burger Gà Yo', 65000, N'1 Burger Gà + 1 Khoai Vừa + 1 Pepsi Vừa', 2, 'https://static.kfcvietnam.com.vn/images/items/lg/Burger-Ga-Yo.jpg?v=L7pxv3', 700, 0, 0, 100),
(5, N'Combo Mì Ý Cổ Điển', 69000, N'1 Mì Ý + 1 Gà Viên + 1 Pepsi Vừa', 2, 'https://popeyes.vn/media/catalog/product/m/i/mi_y_pho_mai_ga_vien.png', 680, 0, 0, 100),
(6, N'Combo Cơm Gà Giòn', 75000, N'1 Cơm Gà + 1 Súp + 1 Pepsi Vừa', 2, 'https://static.kfcvietnam.com.vn/images/items/lg/Com-Ga-Ran.jpg?v=L7pxv3', 720, 0, 0, 100),
(7, N'Combo Gà Không Xương', 79000, N'3 Miếng Gà Không Xương + 1 Khoai Vừa + 1 7Up Vừa', 2, 'https://popeyes.vn/media/catalog/product/c/b/cb_ga_khong_xuong_3p.png', 690, 0, 0, 100),
(8, N'Combo Gà Quay Giấy Bạc', 85000, N'1 Gà Quay + 1 Cơm Trắng + 1 Lipton Vừa', 2, 'https://static.kfcvietnam.com.vn/images/items/lg/BJ.jpg?v=L7pxv3', 650, 0, 0, 100),

(9, N'Combo 2 Người Tiêu Chuẩn', 139000, N'3 Gà Rán + 2 Khoai Vừa + 2 Pepsi Vừa', 3, 'https://static.kfcvietnam.com.vn/images/items/lg/D-GROUP-1.jpg?v=L7pxv3', 1400, 0, 0, 80),
(10, N'Combo Burger Đôi', 149000, N'2 Burger Tùy Chọn + 1 Khoai Lớn + 2 Pepsi Vừa', 3, 'https://popeyes.vn/media/catalog/product/b/u/burger_ca.png', 1500, 0, 0, 80),
(11, N'Combo Gà & Mì Ý', 159000, N'2 Gà Rán + 1 Mì Ý + 1 Khoai Vừa + 2 7Up Vừa', 3, 'https://static.kfcvietnam.com.vn/images/items/lg/D-GROUP-2.jpg?v=L7pxv3', 1600, 0, 0, 80),
(12, N'Combo Tình Yêu', 169000, N'2 Gà + 1 Burger + 2 Bánh Trứng + 2 Lipton Vừa', 3, 'https://static.kfcvietnam.com.vn/images/items/lg/CUNG-VUI.jpg?v=L7pxv3', 1750, 0, 0, 80),
(13, N'Combo Gà Quay & Rán', 175000, N'1 Gà Quay + 2 Gà Rán + 1 Salad + 2 Pepsi Vừa', 3, 'https://static.kfcvietnam.com.vn/images/items/lg/D-GA-CHILL.jpg?v=L7pxv3', 1550, 0, 0, 80),
(14, N'Combo Cơm Trưa Đôi', 180000, N'2 Cơm Gà + 2 Súp + 2 Gà Viên + 2 Nước Vừa', 3, 'https://static.kfcvietnam.com.vn/images/items/lg/Com-Ga-Ran.jpg?v=L7pxv3', 1650, 0, 0, 80),
(15, N'Combo 2 Ng Gà Không Xương', 165000, N'6 Miếng Không Xương + 1 Khoai Lớn + 2 Pepsi Vừa', 3, 'https://popeyes.vn/media/catalog/product/g/a/ga_khong_xuong_5p.png', 1450, 0, 0, 80),

(16, N'Combo Gia Đình 1', 269000, N'6 Gà Rán + 1 Khoai Đại + 4 Pepsi Vừa', 4, 'https://static.kfcvietnam.com.vn/images/items/lg/CUNG-TIEC.jpg?v=L7pxv3', 2500, 0, 0, 60),
(17, N'Combo Gia Đình 2', 289000, N'4 Gà Rán + 2 Burger + 1 Khoai Đại + 4 7Up Vừa', 4, 'https://static.kfcvietnam.com.vn/images/items/lg/CUNG-QUAY.jpg?v=L7pxv3', 2700, 0, 0, 60),
(18, N'Combo Tứ Quý', 319000, N'8 Gà Rán + 2 Salad + 4 Pepsi Vừa', 4, 'https://static.kfcvietnam.com.vn/images/items/lg/CUNG-XOI.jpg?v=L7pxv3', 2800, 0, 0, 60),
(19, N'Combo 4 Người Đầy Đủ', 339000, N'4 Gà Rán + 2 Mì Ý + 4 Bánh Trứng + 4 Lipton Vừa', 4, 'https://static.kfcvietnam.com.vn/images/items/lg/CUNG-VUI.jpg?v=L7pxv3', 3100, 0, 0, 60),
(20, N'Combo Cơm & Gà 4 Người', 349000, N'4 Cơm Gà + 4 Gà Rán + 4 Súp + 4 Nước Vừa', 4, 'https://static.kfcvietnam.com.vn/images/items/lg/Com-Ga-Ran.jpg?v=L7pxv3', 3300, 0, 0, 60),

(21, N'Combo Nhóm 5 Ng Căn Bản', 429000, N'10 Gà Rán + 2 Khoai Đại + 5 Nước Vừa', 5, 'https://static.kfcvietnam.com.vn/images/items/lg/CUNG-TIEC.jpg?v=L7pxv3', 4500, 0, 0, 40),
(22, N'Combo Đại Tiệc 10 Người', 999000, N'20 Gà + 5 Burger + 10 Bánh Trứng + 10 Nước Vừa', 5, 'https://static.kfcvietnam.com.vn/images/items/lg/CUNG-TIEC.jpg?v=L7pxv3', 9800, 0, 0, 40),

(23, N'1 Miếng Gà Rán Giòn Cay', 38000, N'1 Miếng Gà Rán vị cay nồng.', 6, 'https://static.kfcvietnam.com.vn/images/items/lg/1-Fried-Chicken.jpg?v=L7pxv3', 320, 0, 0, 200),
(24, N'1 Miếng Gà Quay Tiêu', 42000, N'Gà quay tiêu nguyên bản.', 6, 'https://static.kfcvietnam.com.vn/images/items/lg/BJ.jpg?v=L7pxv3', 280, 0, 0, 80),

(25, N'Burger Gà Trộn Xốt', 35000, N'Burger nhân thịt gà xé, xốt mayonnaise.', 7, 'https://static.kfcvietnam.com.vn/images/items/lg/Burger-Ga-Yo.jpg?v=L7pxv3', 420, 0, 0, 60),
(26, N'Burger Bò Phô Mai 2 Tầng', 85000, N'Burger 2 lớp bò nướng và phô mai.', 7, 'https://static.kfcvietnam.com.vn/images/items/lg/Burger-Ga-Yo.jpg?v=L7pxv3', 780, 0, 0, 30),

(27, N'Khoai Tây Chiên (Vừa)', 20000, N'Khoai tây chiên giòn (Cỡ vừa).', 9, 'https://static.kfcvietnam.com.vn/images/items/lg/Fries-Large.jpg?v=L7pxv3', 250, 0, 0, 200),
(28, N'Pepsi (Vừa)', 15000, N'Pepsi có gas (Vừa).', 10, 'https://static.kfcvietnam.com.vn/images/items/lg/Pepsi-Large.jpg?v=L7pxv3', 110, 0, 0, 500),
(29, N'Bánh Trứng Nướng (1 Cái)', 18000, N'Bánh tart trứng vàng ươm, vỏ giòn.', 11, 'https://static.kfcvietnam.com.vn/images/items/lg/1-Egg-Tart.jpg?v=L7pxv3', 220, 0, 0, 150);
SET IDENTITY_INSERT [Products] OFF;
-- Lưu ý: Đây là file SQL minh họa một phần nhỏ dữ liệu.

