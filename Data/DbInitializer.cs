using FastFoodEcommerce.Models;

namespace FastFoodEcommerce.Data;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.Products.Any())
        {
            var categories = new Category[]
            {
                new Category { Name = "Ưu đãi", Description = "Khuyến mãi hấp dẫn mỗi ngày." }, // 0
                new Category { Name = "Combo 1 Người", Description = "Phần ăn tiết kiệm cho 1 người." }, // 1
                new Category { Name = "Combo 2 Người", Description = "Bữa ăn lý tưởng cho 2 người." }, // 2
                new Category { Name = "Combo 4 Người", Description = "Bữa ăn trọn vẹn cho gia đình." }, // 3
                new Category { Name = "Combo Nhóm (5+)", Description = "Phù hợp cho tiệc tùng, liên hoan." }, // 4
                new Category { Name = "Gà Rán - Gà Quay", Description = "Gà tươi tẩm ướp đậm đà, giòn rụm." }, // 5
                new Category { Name = "Burger", Description = "Burger đa dạng nhân thịt, tôm, cá." }, // 6
                new Category { Name = "Cơm & Mì Ý", Description = "Chắc bụng với cơm và mì Ý xốt đậm đà." }, // 7
                new Category { Name = "Thức Ăn Nhẹ", Description = "Khoai tây chiên, phô mai viên, salad..." }, // 8
                new Category { Name = "Thức Uống", Description = "Nước ngọt có gas, trà, nước suối." }, // 9
                new Category { Name = "Tráng Miệng", Description = "Bánh tart trứng, kem béo ngậy." } // 10
            };

            foreach (var c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var products = new List<Product>
            {
                // === 0. Ưu Đãi ===
                new Product { Name = "Siêu Ưu Đãi Gà Rán", Price = 99000, Description = "Mua 3 Miếng Gà tặng 1 Khoai Vừa", CategoryId = categories[0].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/3-Fried-Chicken.jpg?v=L7pxv3", Calories = 900, StockQuantity = 50 },
                new Product { Name = "Khuyến Mãi Cuối Tuần", Price = 199000, Description = "Giảm 20% cho combo 4 người", CategoryId = categories[0].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/CUNG-TIEC.jpg?v=L7pxv3", Calories = 1500, StockQuantity = 50 },

                // === 1. Combo 1 Người (>= 5 combo) ===
                new Product { Name = "Combo 1 Miếng Gà", Price = 59000, Description = "1 Miếng gà + 1 Khoai Vừa + 1 Pepsi Vừa", CategoryId = categories[1].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/D-CBO-GA.jpg?v=L7pxv3", Calories = 650, StockQuantity = 100 },
                new Product { Name = "Combo Burger Gà Yo", Price = 65000, Description = "1 Burger Gà + 1 Khoai Vừa + 1 Pepsi Vừa", CategoryId = categories[1].Id, ImageUrl = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?q=80&w=800", Calories = 700, StockQuantity = 100 },
                new Product { Name = "Combo Mì Ý Cổ Điển", Price = 69000, Description = "1 Mì Ý + 1 Gà Viên + 1 Pepsi Vừa", CategoryId = categories[1].Id, ImageUrl = "https://images.unsplash.com/photo-1621996346565-e3dbc646d9a9?q=80&w=800", Calories = 680, StockQuantity = 100 },
                new Product { Name = "Combo Cơm Gà Giòn", Price = 75000, Description = "1 Cơm Gà + 1 Súp + 1 Pepsi Vừa", CategoryId = categories[1].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Com-Ga-Ran.jpg?v=L7pxv3", Calories = 720, StockQuantity = 100 },
                new Product { Name = "Combo Gà Không Xương", Price = 79000, Description = "3 Miếng Gà Không Xương + 1 Khoai Vừa + 1 7Up Vừa", CategoryId = categories[1].Id, ImageUrl = "https://popeyes.vn/media/catalog/product/c/b/cb_ga_khong_xuong_3p.png", Calories = 690, StockQuantity = 100 },
                new Product { Name = "Combo Gà Quay Giấy Bạc", Price = 85000, Description = "1 Gà Quay + 1 Cơm Trắng + 1 Lipton Vừa", CategoryId = categories[1].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/BJ.jpg?v=L7pxv3", Calories = 650, StockQuantity = 100 },

                // === 2. Combo 2 Người (>= 6 combo) ===
                new Product { Name = "Combo 2 Người Tiêu Chuẩn", Price = 139000, Description = "3 Gà Rán + 2 Khoai Vừa + 2 Pepsi Vừa", CategoryId = categories[2].Id, ImageUrl = "https://images.unsplash.com/photo-1626645738196-c2a7c87a8f58?q=80&w=800", Calories = 1400, StockQuantity = 80 },
                new Product { Name = "Combo Burger Đôi", Price = 149000, Description = "2 Burger Tùy Chọn + 1 Khoai Lớn + 2 Pepsi Vừa", CategoryId = categories[2].Id, ImageUrl = "https://images.unsplash.com/photo-1550547660-d9450f859349?q=80&w=800", Calories = 1500, StockQuantity = 80 },
                new Product { Name = "Combo Gà & Mì Ý", Price = 159000, Description = "2 Gà Rán + 1 Mì Ý + 1 Khoai Vừa + 2 7Up Vừa", CategoryId = categories[2].Id, ImageUrl = "https://images.unsplash.com/photo-1626645738196-c2a7c87a8f58?q=80&w=800", Calories = 1600, StockQuantity = 80 },
                new Product { Name = "Combo Tình Yêu", Price = 169000, Description = "2 Gà + 1 Burger + 2 Bánh Trứng + 2 Lipton Vừa", CategoryId = categories[2].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/CUNG-VUI.jpg?v=L7pxv3", Calories = 1750, StockQuantity = 80 },
                new Product { Name = "Combo Gà Quay & Rán", Price = 175000, Description = "1 Gà Quay + 2 Gà Rán + 1 Salad + 2 Pepsi Vừa", CategoryId = categories[2].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/D-GA-CHILL.jpg?v=L7pxv3", Calories = 1550, StockQuantity = 80 },
                new Product { Name = "Combo Cơm Trưa Đôi", Price = 180000, Description = "2 Cơm Gà + 2 Súp + 2 Gà Viên + 2 Nước Vừa", CategoryId = categories[2].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Com-Ga-Ran.jpg?v=L7pxv3", Calories = 1650, StockQuantity = 80 },
                new Product { Name = "Combo 2 Ng Gà Không Xương", Price = 165000, Description = "6 Miếng Không Xương + 1 Khoai Lớn + 2 Pepsi Vừa", CategoryId = categories[2].Id, ImageUrl = "https://popeyes.vn/media/catalog/product/g/a/ga_khong_xuong_5p.png", Calories = 1450, StockQuantity = 80 },

                // === 3. Combo 4 Người (>= 10 combo) ===
                new Product { Name = "Combo Gia Đình 1", Price = 269000, Description = "6 Gà Rán + 1 Khoai Đại + 4 Pepsi Vừa", CategoryId = categories[3].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/CUNG-TIEC.jpg?v=L7pxv3", Calories = 2500, StockQuantity = 60 },
                new Product { Name = "Combo Gia Đình 2", Price = 289000, Description = "4 Gà Rán + 2 Burger + 1 Khoai Đại + 4 7Up Vừa", CategoryId = categories[3].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/CUNG-QUAY.jpg?v=L7pxv3", Calories = 2700, StockQuantity = 60 },
                new Product { Name = "Combo Tứ Quý", Price = 319000, Description = "8 Gà Rán + 2 Salad + 4 Pepsi Vừa", CategoryId = categories[3].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/CUNG-XOI.jpg?v=L7pxv3", Calories = 2800, StockQuantity = 60 },
                new Product { Name = "Combo 4 Người Đầy Đủ", Price = 339000, Description = "4 Gà Rán + 2 Mì Ý + 4 Bánh Trứng + 4 Lipton Vừa", CategoryId = categories[3].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/CUNG-VUI.jpg?v=L7pxv3", Calories = 3100, StockQuantity = 60 },
                new Product { Name = "Combo Cơm & Gà 4 Người", Price = 349000, Description = "4 Cơm Gà + 4 Gà Rán + 4 Súp + 4 Nước Vừa", CategoryId = categories[3].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Com-Ga-Ran.jpg?v=L7pxv3", Calories = 3300, StockQuantity = 60 },
                new Product { Name = "Combo Burger Nhóm 4", Price = 279000, Description = "4 Burger + 2 Khoai Lớn + 4 Nước Vừa", CategoryId = categories[3].Id, ImageUrl = "https://images.unsplash.com/photo-1550547660-d9450f859349?q=80&w=800", Calories = 2600, StockQuantity = 60 },
                new Product { Name = "Combo Gà Không Xương 4 Ng", Price = 299000, Description = "12 Miếng Không Xương + 2 Khoai Lớn + 4 Nước Vừa", CategoryId = categories[3].Id, ImageUrl = "https://popeyes.vn/media/catalog/product/g/a/ga_khong_xuong_5p.png", Calories = 2400, StockQuantity = 60 },
                new Product { Name = "Combo Gà Nướng & Rán", Price = 359000, Description = "4 Gà Nướng + 4 Gà Rán + 2 Salad + 4 Nước Vừa", CategoryId = categories[3].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/BJ.jpg?v=L7pxv3", Calories = 2900, StockQuantity = 60 },
                new Product { Name = "Combo Trẻ Em Yêu Thích", Price = 315000, Description = "4 Gà Rán + 2 Popcorn Lớn + 4 Khoai Vừa + 4 Nước", CategoryId = categories[3].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/POPCORN-LAC-PHO-MAI.jpg?v=L7pxv3", Calories = 2800, StockQuantity = 60 },
                new Product { Name = "Combo Tiệc Nhỏ", Price = 325000, Description = "6 Gà Rán + 4 Phô Mai Viên + 1 Khoai Đại + 4 Nước", CategoryId = categories[3].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/4-Cheese-Ball.jpg?v=L7pxv3", Calories = 2950, StockQuantity = 60 },

                // === 4. Combo Nhóm Lớn (5+ Người) (>= 10 combo) ===
                new Product { Name = "Combo Nhóm 5 Ng Căn Bản", Price = 429000, Description = "10 Gà Rán + 2 Khoai Đại + 5 Nước Vừa", CategoryId = categories[4].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/CUNG-TIEC.jpg?v=L7pxv3", Calories = 4500, StockQuantity = 40 },
                new Product { Name = "Combo Nhóm 6 Ng Gắn Kết", Price = 559000, Description = "12 Gà Rán + 3 Burger + 6 Nước Vừa", CategoryId = categories[4].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/CUNG-QUAY.jpg?v=L7pxv3", Calories = 5600, StockQuantity = 40 },
                new Product { Name = "Combo Tiệc 7 Người", Price = 649000, Description = "14 Gà Rán + 3 Mì Ý + 7 Nước Vừa", CategoryId = categories[4].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/CUNG-VUI.jpg?v=L7pxv3", Calories = 6500, StockQuantity = 40 },
                new Product { Name = "Combo 8 Ng Siêu Khổng Lồ", Price = 789000, Description = "16 Gà + 4 Khoai Đại + 4 Bắp Cải Trộn + 8 Nước Vừa", CategoryId = categories[4].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/CUNG-XOI.jpg?v=L7pxv3", Calories = 7800, StockQuantity = 40 },
                new Product { Name = "Combo Đại Tiệc 10 Người", Price = 999000, Description = "20 Gà + 5 Burger + 10 Bánh Trứng + 10 Nước Vừa", CategoryId = categories[4].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/CUNG-TIEC.jpg?v=L7pxv3", Calories = 9800, StockQuantity = 40 },
                new Product { Name = "Combo Ăn Uống Phủ Phê", Price = 699000, Description = "10 Gà + 10 Gà Không Xương + 5 Khoai Đại + 5 Nước", CategoryId = categories[4].Id, ImageUrl = "https://popeyes.vn/media/catalog/product/g/a/ga_khong_xuong_5p.png", Calories = 7200, StockQuantity = 40 },
                new Product { Name = "Combo Cơm Trưa 5 Người", Price = 450000, Description = "5 Cơm + 5 Gà + 5 Salad + 5 Nước Vừa", CategoryId = categories[4].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Com-Ga-Ran.jpg?v=L7pxv3", Calories = 4600, StockQuantity = 40 },
                new Product { Name = "Combo Gà Trộn Vị", Price = 680000, Description = "5 Gà Truyền Thống + 5 Gà Cay + 5 Gà Quay + 5 Nước", CategoryId = categories[4].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/1-Ga-Mam-Toi.jpg?v=L7pxv3", Calories = 6700, StockQuantity = 40 },
                new Product { Name = "Combo Burger Tụ Tập", Price = 650000, Description = "10 Burger Tùy Chọn + 5 Khoai Đại + 10 Nước Vừa", CategoryId = categories[4].Id, ImageUrl = "https://images.unsplash.com/photo-1550547660-d9450f859349?q=80&w=800", Calories = 6200, StockQuantity = 40 },
                new Product { Name = "Combo 5 Người Chill", Price = 520000, Description = "8 Gà + 2 Popcorn Đại + 5 Phô Mai Viên + 5 Nước", CategoryId = categories[4].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/4-Cheese-Ball.jpg?v=L7pxv3", Calories = 5100, StockQuantity = 40 },
                new Product { Name = "Combo Hoành Tráng", Price = 899000, Description = "15 Gà + 5 Mì Ý + 5 Salad + 10 Nước", CategoryId = categories[4].Id, ImageUrl = "https://images.unsplash.com/photo-1621996346565-e3dbc646d9a9?q=80&w=800", Calories = 8500, StockQuantity = 40 },

                // === 5. Gà Rán - Gà Quay (>= 8 items) ===
                new Product { Name = "1 Miếng Gà Rán Giòn Cay", Price = 38000, Description = "1 Miếng Gà Rán vị cay nồng.", CategoryId = categories[5].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/1-Fried-Chicken.jpg?v=L7pxv3", Calories = 320, StockQuantity = 200 },
                new Product { Name = "1 Miếng Gà Rán Truyền Thống", Price = 38000, Description = "1 Miếng Gà Rán công thức gốc.", CategoryId = categories[5].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/1-Fried-Chicken.jpg?v=L7pxv3", Calories = 310, StockQuantity = 200 },
                new Product { Name = "3 Miếng Gà Rán Tùy Chọn", Price = 108000, Description = "3 Miếng Gà Rán Tùy Chọn.", CategoryId = categories[5].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/3-Fried-Chicken.jpg?v=L7pxv3", Calories = 950, StockQuantity = 100 },
                new Product { Name = "6 Miếng Gà Rán Tùy Chọn", Price = 210000, Description = "6 Miếng Gà Rán Tùy Chọn.", CategoryId = categories[5].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/3-Fried-Chicken.jpg?v=L7pxv3", Calories = 1900, StockQuantity = 50 },
                new Product { Name = "1 Miếng Gà Xốt Mắm Tỏi", Price = 42000, Description = "Gà rán xốt mắm tỏi thơm lừng.", CategoryId = categories[5].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/1-Ga-Mam-Toi.jpg?v=L7pxv3", Calories = 350, StockQuantity = 80 },
                new Product { Name = "1 Miếng Gà Xốt Phô Mai Cay", Price = 45000, Description = "Gà rán xốt phô mai cay.", CategoryId = categories[5].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/1-Ga-Mam-Toi.jpg?v=L7pxv3", Calories = 360, StockQuantity = 80 },
                new Product { Name = "1 Miếng Gà Quay Tiêu", Price = 42000, Description = "Gà quay tiêu nguyên bản.", CategoryId = categories[5].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/BJ.jpg?v=L7pxv3", Calories = 280, StockQuantity = 80 },
                new Product { Name = "Gà Không Xương (3 Miếng)", Price = 55000, Description = "3 Miếng gà không xương Alacarte.", CategoryId = categories[5].Id, ImageUrl = "https://popeyes.vn/media/catalog/product/g/a/ga_khong_xuong_3p.png", Calories = 450, StockQuantity = 120 },
                new Product { Name = "Gà Không Xương (5 Miếng)", Price = 85000, Description = "5 Miếng gà không xương Alacarte.", CategoryId = categories[5].Id, ImageUrl = "https://popeyes.vn/media/catalog/product/g/a/ga_khong_xuong_5p.png", Calories = 750, StockQuantity = 100 },

                // === 6. Burger (>= 8 items) ===
                new Product { Name = "Burger Gà Trộn Xốt Mayonnaise", Price = 35000, Description = "Burger nhân thịt gà xé, xốt mayonnaise.", CategoryId = categories[6].Id, ImageUrl = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?q=80&w=800", Calories = 420, StockQuantity = 60 },
                new Product { Name = "Burger Gà Zinger (Cay)", Price = 55000, Description = "Burger thịt gà nguyên miếng cay nồng.", CategoryId = categories[6].Id, ImageUrl = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?q=80&w=800", Calories = 480, StockQuantity = 60 },
                new Product { Name = "Burger Tôm Cổ Điển", Price = 45000, Description = "Burger tôm giòn tan.", CategoryId = categories[6].Id, ImageUrl = "https://images.unsplash.com/photo-1586190848861-99aa4a171e90?q=80&w=800", Calories = 410, StockQuantity = 60 },
                new Product { Name = "Burger Cá Chiên Giòn", Price = 49000, Description = "Burger cá chiên xù xốt Tartar.", CategoryId = categories[6].Id, ImageUrl = "https://images.unsplash.com/photo-1550547660-d9450f859349?q=80&w=800", Calories = 390, StockQuantity = 60 },
                new Product { Name = "Burger Bò Phô Mai", Price = 60000, Description = "Burger thịt bò nướng phô mai.", CategoryId = categories[6].Id, ImageUrl = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?q=80&w=800", Calories = 520, StockQuantity = 40 },
                new Product { Name = "Burger Bò Phô Mai 2 Tầng", Price = 85000, Description = "Burger 2 lớp bò nướng và phô mai.", CategoryId = categories[6].Id, ImageUrl = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?q=80&w=800", Calories = 780, StockQuantity = 30 },
                new Product { Name = "Burger Gà Quay Flava", Price = 55000, Description = "Burger nhân thịt gà quay Flava.", CategoryId = categories[6].Id, ImageUrl = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?q=80&w=800", Calories = 460, StockQuantity = 50 },
                new Product { Name = "Burger Thực Vật (Veggie)", Price = 45000, Description = "Burger dành cho người ăn chay.", CategoryId = categories[6].Id, ImageUrl = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?q=80&w=800", Calories = 350, StockQuantity = 50 },

                // === 7. Cơm & Mì Ý ===
                new Product { Name = "Cơm Gà Rán", Price = 45000, Description = "1 Cơm trắng + 1 Gà Rán.", CategoryId = categories[7].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Com-Ga-Ran.jpg?v=L7pxv3", Calories = 550, StockQuantity = 80 },
                new Product { Name = "Cơm Gà Quay Tiêu", Price = 50000, Description = "1 Cơm trắng + 1 Gà Quay.", CategoryId = categories[7].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Com-Ga-Ran.jpg?v=L7pxv3", Calories = 520, StockQuantity = 80 },
                new Product { Name = "Mì Ý Xốt Cà Chua Xúc Xích", Price = 40000, Description = "Mì Ý xốt cà chua xúc xích cổ điển.", CategoryId = categories[7].Id, ImageUrl = "https://images.unsplash.com/photo-1621996346565-e3dbc646d9a9?q=80&w=800", Calories = 450, StockQuantity = 80 },
                new Product { Name = "Mì Ý Gà Viên Phô Mai", Price = 55000, Description = "Mì Ý cùng gà viên và phô mai.", CategoryId = categories[7].Id, ImageUrl = "https://images.unsplash.com/photo-1621996346565-e3dbc646d9a9?q=80&w=800", Calories = 580, StockQuantity = 80 },

                // === 8. Thức Ăn Nhẹ & Khoai Tây ===
                new Product { Name = "Khoai Tây Chiên (Vừa)", Price = 20000, Description = "Khoai tây chiên giòn (Cỡ vừa).", CategoryId = categories[8].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Fries-Large.jpg?v=L7pxv3", Calories = 250, StockQuantity = 200 },
                new Product { Name = "Khoai Tây Chiên (Lớn)", Price = 30000, Description = "Khoai tây chiên giòn (Cỡ lớn).", CategoryId = categories[8].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Fries-Large.jpg?v=L7pxv3", Calories = 350, StockQuantity = 200 },
                new Product { Name = "Khoai Tây Chiên (Đại)", Price = 40000, Description = "Khoai tây chiên giòn (Cỡ đại).", CategoryId = categories[8].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Fries-Large.jpg?v=L7pxv3", Calories = 450, StockQuantity = 200 },
                new Product { Name = "Khoai Lắc Phô Mai", Price = 35000, Description = "Khoai tây lắc phô mai đậm đà.", CategoryId = categories[8].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/KHOAI-LAC-PHO-MAI.jpg?v=L7pxv3", Calories = 380, StockQuantity = 100 },
                new Product { Name = "Gà Popcorn (Vừa)", Price = 45000, Description = "Gà viên Popcorn giòn rụm (Vừa).", CategoryId = categories[8].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/POPCORN-LAC-PHO-MAI.jpg?v=L7pxv3", Calories = 400, StockQuantity = 150 },
                new Product { Name = "Gà Popcorn (Lớn)", Price = 65000, Description = "Gà viên Popcorn giòn rụm (Lớn).", CategoryId = categories[8].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/POPCORN-LAC-PHO-MAI.jpg?v=L7pxv3", Calories = 600, StockQuantity = 100 },
                new Product { Name = "Phô Mai Viên (4 Viên)", Price = 40000, Description = "Phô mai viên chiên xù xốt chảy (4 viên).", CategoryId = categories[8].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/4-Cheese-Ball.jpg?v=L7pxv3", Calories = 420, StockQuantity = 100 },
                new Product { Name = "Phô Mai Viên (6 Viên)", Price = 55000, Description = "Phô mai viên chiên xù xốt chảy (6 viên).", CategoryId = categories[8].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/4-Cheese-Ball.jpg?v=L7pxv3", Calories = 630, StockQuantity = 80 },
                new Product { Name = "Salad Trộn Xốt Mè Rang", Price = 25000, Description = "Salad rau củ tươi xốt mè rang.", CategoryId = categories[8].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Salad-Pop.jpg?v=L7pxv3", Calories = 150, StockQuantity = 100 },
                new Product { Name = "Bắp Cải Trộn (Vừa)", Price = 15000, Description = "Salad bắp cải (Cỡ vừa).", CategoryId = categories[8].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Coleslaw-Large.jpg?v=L7pxv3", Calories = 120, StockQuantity = 150 },
                new Product { Name = "Bắp Cải Trộn (Lớn)", Price = 25000, Description = "Salad bắp cải (Cỡ lớn).", CategoryId = categories[8].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Coleslaw-Large.jpg?v=L7pxv3", Calories = 200, StockQuantity = 100 },
                new Product { Name = "Khoai Tây Nghiền (Vừa)", Price = 15000, Description = "Khoai tây nghiền siêu mịn (Cỡ vừa).", CategoryId = categories[8].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Mash-Potato-Large.jpg?v=L7pxv3", Calories = 150, StockQuantity = 150 },
                new Product { Name = "Khoai Tây Nghiền (Lớn)", Price = 25000, Description = "Khoai tây nghiền siêu mịn (Cỡ lớn).", CategoryId = categories[8].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Mash-Potato-Large.jpg?v=L7pxv3", Calories = 250, StockQuantity = 100 },

                // === 9. Thức Uống ===
                new Product { Name = "Pepsi (Vừa)", Price = 15000, Description = "Pepsi có gas (Vừa).", CategoryId = categories[9].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Pepsi-Large.jpg?v=L7pxv3", Calories = 110, StockQuantity = 500 },
                new Product { Name = "Pepsi (Lớn)", Price = 20000, Description = "Pepsi có gas (Lớn).", CategoryId = categories[9].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Pepsi-Large.jpg?v=L7pxv3", Calories = 150, StockQuantity = 400 },
                new Product { Name = "Pepsi Không Đường (Vừa)", Price = 15000, Description = "Pepsi Black (Vừa).", CategoryId = categories[9].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Pepsi-Black-Large.jpg?v=L7pxv3", Calories = 0, StockQuantity = 300 },
                new Product { Name = "Pepsi Không Đường (Lớn)", Price = 20000, Description = "Pepsi Black (Lớn).", CategoryId = categories[9].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Pepsi-Black-Large.jpg?v=L7pxv3", Calories = 0, StockQuantity = 300 },
                new Product { Name = "7Up (Vừa)", Price = 15000, Description = "7Up hương chanh (Vừa).", CategoryId = categories[9].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/7Up-Large.jpg?v=L7pxv3", Calories = 105, StockQuantity = 300 },
                new Product { Name = "7Up (Lớn)", Price = 20000, Description = "7Up hương chanh (Lớn).", CategoryId = categories[9].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/7Up-Large.jpg?v=L7pxv3", Calories = 140, StockQuantity = 300 },
                new Product { Name = "Trà Chanh Lipton (Vừa)", Price = 15000, Description = "Lipton chanh đá (Vừa).", CategoryId = categories[9].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Lipton-Tea-Large.jpg?v=L7pxv3", Calories = 80, StockQuantity = 300 },
                new Product { Name = "Trà Chanh Lipton (Lớn)", Price = 20000, Description = "Lipton chanh đá (Lớn).", CategoryId = categories[9].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Lipton-Tea-Large.jpg?v=L7pxv3", Calories = 110, StockQuantity = 300 },
                new Product { Name = "Nước Suối Aquafina", Price = 15000, Description = "Nước tinh khiết đóng chai.", CategoryId = categories[9].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/Pepsi-Black-Large.jpg?v=L7pxv3", Calories = 0, StockQuantity = 500 },

                // === 10. Tráng Miệng ===
                new Product { Name = "Bánh Trứng Nướng (1 Cái)", Price = 18000, Description = "Bánh tart trứng vàng ươm, vỏ giòn.", CategoryId = categories[10].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/1-Egg-Tart.jpg?v=L7pxv3", Calories = 220, StockQuantity = 150 },
                new Product { Name = "Bánh Trứng Nướng (4 Cái)", Price = 65000, Description = "Hộp 4 bánh tart trứng nướng.", CategoryId = categories[10].Id, ImageUrl = "https://static.kfcvietnam.com.vn/images/items/lg/1-Egg-Tart.jpg?v=L7pxv3", Calories = 880, StockQuantity = 50 },
                new Product { Name = "Kem Tươi Vani (Ốc Quế)", Price = 10000, Description = "Kem tươi vani ngọt ngào.", CategoryId = categories[10].Id, ImageUrl = "https://images.unsplash.com/photo-1563805042-7684c8a9e9cb?q=80&w=800", Calories = 150, StockQuantity = 300 },
                new Product { Name = "Kem Sundae Sô-cô-la", Price = 25000, Description = "Kem tươi rưới xốt sô-cô-la.", CategoryId = categories[10].Id, ImageUrl = "https://images.unsplash.com/photo-1570197781417-0a8237580b06?q=80&w=800", Calories = 250, StockQuantity = 200 },
                new Product { Name = "Kem Sundae Dâu", Price = 25000, Description = "Kem tươi rưới xốt dâu tây.", CategoryId = categories[10].Id, ImageUrl = "https://images.unsplash.com/photo-1558235222-19e34e5db8d0?q=80&w=800", Calories = 240, StockQuantity = 200 }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        // Seed Vouchers — Tự động nạp dữ liệu lần đầu và gia hạn mã hết hạn khi khởi động
        if (!context.Vouchers.Any())
        {
            // Lần đầu tiên: nạp toàn bộ bộ mã khuyến mãi mặc định
            var vouchers = new Voucher[]
            {
                new Voucher { Code = "HELLO5",  DiscountPercentage = 5,  Description = "Chào mừng bạn mới",  StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30) },
                new Voucher { Code = "LUCKY10", DiscountPercentage = 10, Description = "Ưu đãi may mắn",     StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30) },
                new Voucher { Code = "EVENT19", DiscountPercentage = 19, Description = "Sự kiện đặc biệt",   StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30) },
                new Voucher { Code = "SUPER23", DiscountPercentage = 23, Description = "Siêu khuyến mãi",    StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30) },
                new Voucher { Code = "SALE29",  DiscountPercentage = 29, Description = "Giảm giá sốc",       StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30) },
                new Voucher { Code = "GOLD32",  DiscountPercentage = 32, Description = "Ưu đãi hạng vàng",   StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30) },
                new Voucher { Code = "NEWUSER", DiscountPercentage = 15, Description = "Tân thủ may mắn",    StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30) },
                new Voucher { Code = "FLASH50", DiscountPercentage = 50, Description = "Flash Sale đặc biệt", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7)  }
            };
            context.Vouchers.AddRange(vouchers);
            context.SaveChanges();
        }
        else
        {
            // Những lần tiếp theo: kiểm tra và tự động gia hạn những mã đã hết hạn
            var expiredVouchers = context.Vouchers
                .Where(v => v.EndDate < DateTime.Now)
                .ToList();

            if (expiredVouchers.Any())
            {
                foreach (var v in expiredVouchers)
                {
                    // Gia hạn: bắt đầu từ hôm nay, thêm 30 ngày
                    v.StartDate = DateTime.Now;
                    v.EndDate   = DateTime.Now.AddDays(30);
                }
                context.SaveChanges();
            }
        }

        // Seed Stores
        if (context.Stores.Count() < 30)
        {
            var existingStores = context.Stores.ToList();
            context.Stores.RemoveRange(existingStores);
            context.SaveChanges();

            var stores = new Store[]
            {
                new Store { Name = "FastFood Nguyễn Huệ", Address = "42 Nguyễn Huệ, Bến Nghé, Quận 1, TP.HCM", Phone = "028.3821.1111", Latitude = 10.7721869, Longitude = 106.7017555, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.460232428514!2d106.7017555!3d10.7721869!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f40a1b17ad5%3A0x7d337d1e03a273!2zNDIgTmd1eeG7hW4gAHVlaCwgQsOhbiBOZ2jDqSwgUXVhbiAxLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714800000000" },
                new Store { Name = "FastFood Bùi Viện", Address = "200 Bùi Viện, Phạm Ngũ Lão, Quận 1, TP.HCM", Phone = "028.3821.2222", Latitude = 10.7674235, Longitude = 106.6903332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.4895642442406!2d106.6903332!3d10.7674235!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f16b677a299%3A0x6739947936a59600!2zMjAwIELDuWkgVmnhu4duLCBQaOG6oW0gTmd1IEzDo28sIFF14bqtbiAxLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714800100000" },
                new Store { Name = "FastFood Đakao", Address = "15 Phan Kế Bính, Đa Kao, Quận 1, TP.HCM", Phone = "028.3821.3333", Latitude = 10.7856667, Longitude = 106.6961445, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.382218693489!2d106.6961445!3d10.7856667!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f3592e34279%3A0xe5a363717208d9!2zMTUgUGhhbiBL4bq_IELDrW5oLCDEkGEgS2FvLCBRdeG6rW4gMSwgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5o!5e0!3m2!1svi!2s!4v1714800200000" },
                new Store { Name = "FastFood Võ Văn Tần", Address = "202 Võ Văn Tần, Quận 3, TP.HCM", Phone = "028.3833.1111", Latitude = 10.774431, Longitude = 106.6853332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.453396783935!2d106.6853332!3d10.774431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f2425672223%3A0x1d4d62b5084931a5!2zMjAyIFbDteBWxINuIFThuqduLCBRdeG6rW4gMywgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5o!5e0!3m2!1svi!2s!4v1714800300000" },
                new Store { Name = "FastFood Lê Quý Đôn", Address = "5 Lê Quý Đôn, Võ Thị Sáu, Quận 3, TP.HCM", Phone = "028.3833.2222", Latitude = 10.782000, Longitude = 106.692222, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.4079493921564!2d106.692222!3d10.782000!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f3605c56c2d%3A0x7d0a6a0e6981881a!2zNSBMw6ogUXXDvSDEkMO0biwgVsO1IFRo4buLIFPDoXUsIFF14bqtbiAzLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714800400000" },
                new Store { Name = "FastFood Trần Hưng Đạo", Address = "600 Trần Hưng Đạo, Quận 5, TP.HCM", Phone = "028.3855.1111", Latitude = 10.751222, Longitude = 106.6783332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.6385750244433!2d106.6783332!3d10.751222!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752ef0f968600d%3A0x6475850907a01c3!2zNjAwIFRy4bqnbiBIxrhu4tuZyDEkOG6oW8sIFF14bqtbiA1LCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714800500000" },
                new Store { Name = "FastFood An Dương Vương", Address = "273 An Dương Vương, Quận 5, TP.HCM", Phone = "028.3855.2222", Latitude = 10.755431, Longitude = 106.6743332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.6053351950493!2d106.6743332!3d10.755431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f1b77db9395%3A0xc33139366e63286f!2zMjczIEFuIETGsMahbmcgVsawxqFuZywgUXXhuqtbiA1LCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714800600000" },
                new Store { Name = "FastFood Phú Mỹ Hưng", Address = "Tôn Dật Tiên, Tân Phong, Quận 7, TP.HCM", Phone = "028.3771.1111", Latitude = 10.725431, Longitude = 106.7143332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3920.0163351950493!2d106.7143332!3d10.725431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zVMO0biBE4bqtdCBUacOqbiwgVMOibiBQaG9uZywgUXXhuqtbiA3LCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714800700000" },
                new Store { Name = "FastFood Huỳnh Tấn Phát", Address = "1500 Huỳnh Tấn Phát, Phú Mỹ, Quận 7, TP.HCM", Phone = "028.3771.2222", Latitude = 10.715431, Longitude = 106.7343332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3920.1053351950493!2d106.7343332!3d10.715431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTUwMCBIdXluaCBU4bqlbiBQaMOhdCwgUGjDuiBN4bu5LCBRdeG6rW4gNywgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5o!5e0!3m2!1svi!2s!4v1714800800000" },
                new Store { Name = "FastFood Lâm Văn Bền", Address = "80 Lâm Văn Bền, Tân Thuận Tây, Quận 7, TP.HCM", Phone = "028.3771.3333", Latitude = 10.735431, Longitude = 106.7143332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.9053351950493!2d106.7143332!3d10.735431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zODAgTMOibSBWxINuIELhu4FuLCBUw6JuIFRodeG6rW4gVMOieSwgUXXhuqtbiA3LCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714800900000" },
                new Store { Name = "FastFood Ba Tháng Hai", Address = "602 Ba Tháng Hai, Quận 10, TP.HCM", Phone = "028.3866.1111", Latitude = 10.765431, Longitude = 106.6643332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.5053351950493!2d106.6643332!3d10.765431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zNjAyIEJhIFRow6FuZyBIYWksIFF14bqtbiAxMCwgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5o!5e0!3m2!1svi!2s!4v1714801000000" },
                new Store { Name = "FastFood Tô Hiến Thành", Address = "163 Tô Hiến Thành, Quận 10, TP.HCM", Phone = "028.3866.2222", Latitude = 10.775431, Longitude = 106.6643332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.4053351950493!2d106.6643332!3d10.775431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTYzIFTDtCBIaeG6v24gVGjDoG5oLCBRdeG6rW4gMTAsIFRow6gbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714801100000" },
                new Store { Name = "FastFood Cộng Hòa", Address = "15 Cộng Hòa, Quận Tân Bình, TP.HCM", Phone = "028.3811.1111", Latitude = 10.805431, Longitude = 106.6543332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.2053351950493!2d106.6543332!3d10.805431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTUgQ-G7mW5nIEjDsmEsIFRhbiBCaW5oLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714801200000" },
                new Store { Name = "FastFood Trường Sơn", Address = "2 Trường Sơn, Quận Tân Bình, TP.HCM", Phone = "028.3811.2222", Latitude = 10.815431, Longitude = 106.6643332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.1053351950493!2d106.6643332!3d10.815431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMiBUcsaw4budbmcgU8ahbiwgVGFuIEJpbmgsIFRow6gbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714801300000" },
                new Store { Name = "FastFood Ung Văn Khiêm", Address = "25 Ung Văn Khiêm, Bình Thạnh, TP.HCM", Phone = "028.3511.1111", Latitude = 10.805431, Longitude = 106.7143332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.0053351950493!2d106.7143332!3d10.805431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMjUgVW5nIFbEg24gS2hpw6ptLCBCw6xuaCBUaOG6oW5oLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714801400000" },
                new Store { Name = "FastFood Phan Xích Long", Address = "150 Phan Xích Long, Phú Nhuận, TP.HCM", Phone = "028.3511.2222", Latitude = 10.795431, Longitude = 106.6843332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.2553351950493!2d106.6843332!3d10.795431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTUwIFBoYW4gWMOtY2ggTG9uZywgUGjDuiBOaHXhuq1uLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714801500000" },
                new Store { Name = "FastFood Quang Trung", Address = "500 Quang Trung, Gò Vấp, TP.HCM", Phone = "028.3988.1111", Latitude = 10.845431, Longitude = 106.6543332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.8053351950493!2d106.6543332!3d10.845431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zNTAwIFF1YW5nIFRydW5nLCBHw7IgVuG6pXAsIFRow6gbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714801600000" },
                new Store { Name = "FastFood Phan Văn Trị", Address = "1200 Phan Văn Trị, Gò Vấp, TP.HCM", Phone = "028.3988.2222", Latitude = 10.825431, Longitude = 106.6843332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.7053351950493!2d106.6843332!3d10.825431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTIwMCBQaGFuIFbEg24gVHLhu4ssIEfDsiBW4bqlcCwgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5oLCBWaeG7dCBOYW0!5e0!3m2!1svi!2s!4v1714801700000" },
                new Store { Name = "FastFood Thảo Điền", Address = "15 Xuân Thủy, Thảo Điền, Thủ Đức, TP.HCM", Phone = "028.3744.1111", Latitude = 10.805431, Longitude = 106.7343332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.1053351950493!2d106.7343332!3d10.805431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTUgWHXDom4gVGjhu6d5LCBUaOG6o28gxJBp4buTbiwgVGjhu6cgxJDhu6ljLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714801800000" },
                new Store { Name = "FastFood Làng Đại Học", Address = "Khu phố 6, Linh Trung, Thủ Đức, TP.HCM", Phone = "028.3744.2222", Latitude = 10.875431, Longitude = 106.7943332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.2053351950493!2d106.7943332!3d10.875431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zS2h1IHBo4buRIDYsIExpbmggVHJ1bmcsIFRo4bunIMSQ4bupYywgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5o!5e0!3m2!1svi!2s!4v1714801900000" },
                new Store { Name = "FastFood Gigamall", Address = "240 Phạm Văn Đồng, Hiệp Bình Chánh, Thủ Đức", Phone = "028.3744.3333", Latitude = 10.825431, Longitude = 106.7143332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.9053351950493!2d106.7143332!3d10.825431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMjQwIFBo4bqhbSBWxINuIMSQ4buTbmcsIEhp4bu9cCBCw6xuaCCBDaMOhbmgsIFRo4bunIMSQ4bupYw!5e0!3m2!1svi!2s!4v1714802000000" },
                new Store { Name = "FastFood Lê Văn Việt", Address = "50 Lê Văn Việt, Hiệp Phú, Thủ Đức", Phone = "028.3744.4444", Latitude = 10.845431, Longitude = 106.7743332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.5053351950493!2d106.7743332!3d10.845431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zNTAgTMOqIFbEg24gVmnhu4d0LCBIaeG7h3AgUGjDuiwgVGjhu6cgxJDhu6lj!5e0!3m2!1svi!2s!4v1714802100000" },
                new Store { Name = "FastFood Phan Văn Hớn", Address = "100 Phan Văn Hớn, Tân Thới Nhất, Quận 12", Phone = "028.3711.1111", Latitude = 10.825431, Longitude = 106.6143332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.9053351950493!2d106.6143332!3d10.825431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTAwIFBoYW4gVsSDbiBI4bubbiwgVMOibiBUaOG7m2kgTmjhuqV0LCBRdeG6rW4gMTI!5e0!3m2!1svi!2s!4v1714802200000" },
                new Store { Name = "FastFood Nguyễn Ảnh Thủ", Address = "50 Nguyễn Ảnh Thủ, Hiệp Thành, Quận 12", Phone = "028.3711.2222", Latitude = 10.875431, Longitude = 106.6343332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.4053351950493!2d106.6343332!3d10.875431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zNTAgTmd1eeG7hW4g4bqjbmggVGjhu6csIEhp4bu9cCBUaMOgbmgsIFF14bqtbiAxMg!5e0!3m2!1svi!2s!4v1714802300000" },
                new Store { Name = "FastFood Tên Lửa", Address = "15 Tên Lửa, An Lạc A, Quận Bình Tân", Phone = "028.3755.1111", Latitude = 10.745431, Longitude = 106.6143332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.7053351950493!2d106.6143332!3d10.745431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTUgVMOqbiBM4busYSwgQW4gTOG6oWMgQSwgUXXhuqtbiBCw6xuaCBUw6Ju!5e0!3m2!1svi!2s!4v1714802400000" },
                new Store { Name = "FastFood Aeon Mall Bình Tân", Address = "1 Đường số 17A, Bình Trị Đông B, Bình Tân", Phone = "028.3755.2222", Latitude = 10.735431, Longitude = 106.6043332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.8053351950493!2d106.6043332!3d10.735431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMSDEkMaw4budbmcgc-G7kSAxN0EsIELDrG5oIFRy4buLIMSQw7RuZyBCLCBCw6xuaCBUw6Ju!5e0!3m2!1svi!2s!4v1714802500000" },
                new Store { Name = "FastFood Trung Sơn", Address = "Đường số 9, Bình Hưng, Bình Chánh", Phone = "028.3755.3333", Latitude = 10.725431, Longitude = 106.6843332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.9553351950493!2d106.6843332!3d10.725431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zxMaw4budbmcgc-G7kSA5LCBCw6xuaCBIxrhu4tuZywgQsOsbmggQ2jDoW5o!5e0!3m2!1svi!2s!4v1714802600000" },
                new Store { Name = "FastFood Lê Văn Lương", Address = "1200 Lê Văn Lương, Phước Kiển, Nhà Bè", Phone = "028.3755.4444", Latitude = 10.695431, Longitude = 106.7043332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3920.3053351950493!2d106.7043332!3d10.695431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTIwMCBMw6ogVsSDbiBMxrDGoW5nLCBQaMaw4bubYyBLaeG7g24sIE5ow6AgQsO!5e0!3m2!1svi!2s!4v1714802700000" },
                new Store { Name = "FastFood Đặng Thúc Vịnh", Address = "50 Đặng Thúc Vịnh, Đông Thạnh, Hóc Môn", Phone = "028.3755.5555", Latitude = 10.905431, Longitude = 106.6543332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.1053351950493!2d106.6543332!3d10.905431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zNTAgxJDhurduZyBUaMO6YyBW4buLbmgsIMSQw7RuZyBUaOG6oW5oLCBIw7NjIE3DtG4!5e0!3m2!1svi!2s!4v1714802800000" },
                new Store { Name = "FastFood Củ Chi", Address = "789 Quốc Lộ 22, TT. Củ Chi, Củ Chi", Phone = "028.3755.6666", Latitude = 11.005431, Longitude = 106.5043332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3917.1053351950493!2d106.5043332!3d11.005431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3174d9b77db9395%3A0xc33139366e63286f!2zNzg5IFF14buRYyBM4buZIDIyLCBUVC4gQ-G7pyBDaGksIEPhu6cgQ2hp!5e0!3m2!1svi!2s!4v1714802900000" }
            };
            context.Stores.AddRange(stores);
            context.SaveChanges();
        }

        // Seed Banners
        if (!context.Banners.Any())
        {
            var banners = new Banner[]
            {
                new Banner { Title = "MIỄN PHÍ VẬN CHUYỂN", SubTitle = "Cho đơn hàng từ 200k toàn quốc", ImageUrl = "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=1200", IsActive = true, DisplayOrder = -1, LinkUrl = "/Promotion" },
                new Banner { Title = "THƯỞNG THỨC GÀ GIÒN", SubTitle = "Ưu đãi mua 1 tặng 1 thứ 3 hàng tuần", ImageUrl = "https://images.unsplash.com/photo-1594212699903-ec8a3eca50f5?q=80&w=1200", IsActive = true, DisplayOrder = 1, LinkUrl = "/Home/Index#menu-section" },
                new Banner { Title = "BURGER BÒ PHÔ MAI", SubTitle = "Vị ngon khó cưỡng, ưu đãi chỉ 49k", ImageUrl = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?q=80&w=1200", IsActive = true, DisplayOrder = 2, LinkUrl = "/Home/Index#menu-section" },
                new Banner { Title = "PIZZA HẢI SẢN MỚI", SubTitle = "Đế dày, ngập tràn hải sản tươi ngon", ImageUrl = "https://images.unsplash.com/photo-1565299624946-b28f40a0ae38?q=80&w=1200", IsActive = true, DisplayOrder = 3, LinkUrl = "/Home/Index#menu-section" },
                new Banner { Title = "SIÊU ƯU ĐÃI APP", SubTitle = "Giảm 50% cho đơn hàng đầu tiên trên App Mobile", ImageUrl = "https://images.unsplash.com/photo-1550547660-d9450f859349?q=80&w=1200", IsActive = true, DisplayOrder = 100, LinkUrl = "#" },
                new Banner { Title = "TÍCH ĐIỂM ĐỔI QUÀ", SubTitle = "Mỗi 10k tích 1 điểm, đổi ngay Voucher hấp dẫn", ImageUrl = "https://images.unsplash.com/photo-1573080496219-bb080dd4f877?q=80&w=1200", IsActive = true, DisplayOrder = 101, LinkUrl = "/Account/Loyalty" }
            };
            context.Banners.AddRange(banners);
            context.SaveChanges();
        }
    }
}
