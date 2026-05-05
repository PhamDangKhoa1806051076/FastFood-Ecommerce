using FastFoodEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodEcommerce.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Products.Any())
            {
                var categories = new Category[]
                {
                    new Category { Name = "Burgers", Description = "Bánh kẹp thơm ngon với thịt bò, gà và rau tươi." },
                    new Category { Name = "Pizzas", Description = "Bánh Pizza đế mỏng, giòn với nhiều loại topping." },
                    new Category { Name = "Drinks", Description = "Nước giải khát và sinh tố tươi mát." },
                    new Category { Name = "Sides", Description = "Các món ăn kèm như khoai tây chiên, gà viên." }
                };

                foreach (var c in categories)
                {
                    context.Categories.Add(c);
                }
                context.SaveChanges();

                var products = new Product[]
                {
                    new Product { Name = "Beef Burger Premium", Price = 75000, Description = "Thịt bò nướng nhập khẩu, phô mai Cheddar, xà lách và sốt đặc biệt.", CategoryId = categories[0].Id, ImageUrl = "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?q=80&w=800" },
                    new Product { Name = "Chicken Crispy Burger", Price = 55000, Description = "Ức gà chiên xù giòn rụm, sốt Mayonnaise và dưa leo muối.", CategoryId = categories[0].Id, ImageUrl = "https://images.unsplash.com/photo-1550547660-d9450f859349?q=80&w=800" },
                    new Product { Name = "Pizza Seafood Deluxe", Price = 189000, Description = "Tôm, mực, thanh cua kết hợp với sốt Pesto và phô mai Mozzarella.", CategoryId = categories[1].Id, ImageUrl = "https://images.unsplash.com/photo-1565299624946-b28f40a0ae38?q=80&w=800" },
                    new Product { Name = "Pizza Margherita", Price = 129000, Description = "Phong cách Ý cổ điển với sốt cà chua, húng tây và phô mai.", CategoryId = categories[1].Id, ImageUrl = "https://images.unsplash.com/photo-1604068549290-dea0e4a305ca?q=80&w=800" },
                    new Product { Name = "Coca Cola", Price = 20000, Description = "Nước ngọt có ga 330ml.", CategoryId = categories[2].Id, ImageUrl = "https://images.unsplash.com/photo-1622483767028-3f66f32aef97?q=80&w=800" },
                    new Product { Name = "French Fries", Price = 35000, Description = "Khoai tây chiên vàng giòn, ăn kèm muối và tương cà.", CategoryId = categories[3].Id, ImageUrl = "https://images.unsplash.com/photo-1573080496219-bb080dd4f877?q=80&w=800" }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }

            // Seed Vouchers
            if (!context.Vouchers.Any())
            {
                var vouchers = new Voucher[]
                {
                    new Voucher { Code = "HELLO5", DiscountPercentage = 5, Description = "Chào mừng bạn mới", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(7) },
                    new Voucher { Code = "LUCKY10", DiscountPercentage = 10, Description = "Ưu đãi may mắn", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(3) },
                    new Voucher { Code = "EVENT19", DiscountPercentage = 19, Description = "Sự kiện đặc biệt", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(14) },
                    new Voucher { Code = "SUPER23", DiscountPercentage = 23, Description = "Siêu khuyến mãi", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(14) },
                    new Voucher { Code = "SALE29", DiscountPercentage = 29, Description = "Giảm giá sốc", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5) },
                    new Voucher { Code = "GOLD32", DiscountPercentage = 32, Description = "Ưu đãi hạng vàng", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(14) }
                };
                context.Vouchers.AddRange(vouchers);
                context.SaveChanges();
            }

            // Seed Stores
            if (context.Stores.Count() < 30)
            {
                // Clear existing if any to avoid duplicates or incomplete list
                var existingStores = context.Stores.ToList();
                context.Stores.RemoveRange(existingStores);
                context.SaveChanges();

                var stores = new Store[]
                {
                    // District 1
                    new Store { Name = "FastFood Nguyễn Huệ", Address = "42 Nguyễn Huệ, Bến Nghé, Quận 1, TP.HCM", Phone = "028.3821.1111", Latitude = 10.7721869, Longitude = 106.7017555, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.460232428514!2d106.7017555!3d10.7721869!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f40a1b17ad5%3A0x7d337d1e03a273!2zNDIgTmd1eeG7hW4gSHXhu4csIELhurNuIE5naMOpLCBRdeG6rW4gMSwgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5o!5e0!3m2!1svi!2s!4v1714800000000" },
                    new Store { Name = "FastFood Bùi Viện", Address = "200 Bùi Viện, Phạm Ngũ Lão, Quận 1, TP.HCM", Phone = "028.3821.2222", Latitude = 10.7674235, Longitude = 106.6903332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.4895642442406!2d106.6903332!3d10.7674235!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f16b677a299%3A0x6739947936a59600!2zMjAwIELDuWkgVmnhu4duLCBQaOG6oW0gTmd1IEzDo28sIFF14bqtbiAxLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714800100000" },
                    new Store { Name = "FastFood Đakao", Address = "15 Phan Kế Bính, Đa Kao, Quận 1, TP.HCM", Phone = "028.3821.3333", Latitude = 10.7856667, Longitude = 106.6961445, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.382218693489!2d106.6961445!3d10.7856667!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f3592e34279%3A0xe5a363717208d9!2zMTUgUGhhbiBL4bq_IELDrW5oLCDEkGEgS2FvLCBRdeG6rW4gMSwgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5o!5e0!3m2!1svi!2s!4v1714800200000" },

                    // District 3
                    new Store { Name = "FastFood Võ Văn Tần", Address = "202 Võ Văn Tần, Quận 3, TP.HCM", Phone = "028.3833.1111", Latitude = 10.774431, Longitude = 106.6853332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.453396783935!2d106.6853332!3d10.774431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f2425672223%3A0x1d4d62b5084931a5!2zMjAyIFbDteBWxINuIFThuqduLCBRdeG6rW4gMywgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5o!5e0!3m2!1svi!2s!4v1714800300000" },
                    new Store { Name = "FastFood Lê Quý Đôn", Address = "5 Lê Quý Đôn, Võ Thị Sáu, Quận 3, TP.HCM", Phone = "028.3833.2222", Latitude = 10.782000, Longitude = 106.692222, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.4079493921564!2d106.692222!3d10.782000!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f3605c56c2d%3A0x7d0a6a0e6981881a!2zNSBMw6ogUXXDvSDEkMO0biwgVsO1IFRo4buLIFPDoXUsIFF14bqtbiAzLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714800400000" },

                    // District 5
                    new Store { Name = "FastFood Trần Hưng Đạo", Address = "600 Trần Hưng Đạo, Quận 5, TP.HCM", Phone = "028.3855.1111", Latitude = 10.751222, Longitude = 106.6783332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.6385750244433!2d106.6783332!3d10.751222!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752ef0f968600d%3A0x6475850907a01c3!2zNjAwIFRy4bqnbiBIxrhu4tuZyDEkOG6oW8sIFF14bqtbiA1LCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714800500000" },
                    new Store { Name = "FastFood An Dương Vương", Address = "273 An Dương Vương, Quận 5, TP.HCM", Phone = "028.3855.2222", Latitude = 10.755431, Longitude = 106.6743332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.6053351950493!2d106.6743332!3d10.755431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f1b77db9395%3A0xc33139366e63286f!2zMjczIEFuIETGsMahbmcgVsawxqFuZywgUXXhuqtbiA1LCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714800600000" },

                    // District 7
                    new Store { Name = "FastFood Phú Mỹ Hưng", Address = "Tôn Dật Tiên, Tân Phong, Quận 7, TP.HCM", Phone = "028.3771.1111", Latitude = 10.725431, Longitude = 106.7143332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3920.0163351950493!2d106.7143332!3d10.725431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zVMO0biBE4bqtdCBUacOqbiwgVMOibiBQaG9uZywgUXXhuqtbiA3LCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714800700000" },
                    new Store { Name = "FastFood Huỳnh Tấn Phát", Address = "1500 Huỳnh Tấn Phát, Phú Mỹ, Quận 7, TP.HCM", Phone = "028.3771.2222", Latitude = 10.715431, Longitude = 106.7343332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3920.1053351950493!2d106.7343332!3d10.715431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTUwMCBIdXluaCBU4bqlbiBQaMOhdCwgUGjDuiBN4bu5LCBRdeG6rW4gNywgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5o!5e0!3m2!1svi!2s!4v1714800800000" },
                    new Store { Name = "FastFood Lâm Văn Bền", Address = "80 Lâm Văn Bền, Tân Thuận Tây, Quận 7, TP.HCM", Phone = "028.3771.3333", Latitude = 10.735431, Longitude = 106.7143332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.9053351950493!2d106.7143332!3d10.735431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zODAgTMOibSBWxINuIELhu4FuLCBUw6JuIFRodeG6rW4gVMOieSwgUXXhuqtbiA3LCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714800900000" },

                    // District 10
                    new Store { Name = "FastFood Ba Tháng Hai", Address = "602 Ba Tháng Hai, Quận 10, TP.HCM", Phone = "028.3866.1111", Latitude = 10.765431, Longitude = 106.6643332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.5053351950493!2d106.6643332!3d10.765431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zNjAyIEJhIFRow6FuZyBIYWksIFF14bqtbiAxMCwgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5o!5e0!3m2!1svi!2s!4v1714801000000" },
                    new Store { Name = "FastFood Tô Hiến Thành", Address = "163 Tô Hiến Thành, Quận 10, TP.HCM", Phone = "028.3866.2222", Latitude = 10.775431, Longitude = 106.6643332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.4053351950493!2d106.6643332!3d10.775431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTYzIFTDtCBIaeG6v24gVGjDoG5oLCBRdeG6rW4gMTAsIFRow6gbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714801100000" },

                    // Tan Binh
                    new Store { Name = "FastFood Cộng Hòa", Address = "15 Cộng Hòa, Quận Tân Bình, TP.HCM", Phone = "028.3811.1111", Latitude = 10.805431, Longitude = 106.6543332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.2053351950493!2d106.6543332!3d10.805431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTUgQ-G7mW5nIEjDsmEsIFRhbiBCaW5oLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714801200000" },
                    new Store { Name = "FastFood Trường Sơn", Address = "2 Trường Sơn, Quận Tân Bình, TP.HCM", Phone = "028.3811.2222", Latitude = 10.815431, Longitude = 106.6643332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.1053351950493!2d106.6643332!3d10.815431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMiBUcsaw4budbmcgU8ahbiwgVGFuIEJpbmgsIFRow6gbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714801300000" },

                    // Binh Thanh
                    new Store { Name = "FastFood Ung Văn Khiêm", Address = "25 Ung Văn Khiêm, Bình Thạnh, TP.HCM", Phone = "028.3511.1111", Latitude = 10.805431, Longitude = 106.7143332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.0053351950493!2d106.7143332!3d10.805431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMjUgVW5nIFbEg24gS2hpw6ptLCBCw6xuaCBUaOG6oW5oLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714801400000" },
                    new Store { Name = "FastFood Phan Xích Long", Address = "150 Phan Xích Long, Phú Nhuận, TP.HCM", Phone = "028.3511.2222", Latitude = 10.795431, Longitude = 106.6843332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.2553351950493!2d106.6843332!3d10.795431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTUwIFBoYW4gWMOtY2ggTG9uZywgUGjDuiBOaHXhuq1uLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714801500000" },

                    // Go Vap
                    new Store { Name = "FastFood Quang Trung", Address = "500 Quang Trung, Gò Vấp, TP.HCM", Phone = "028.3988.1111", Latitude = 10.845431, Longitude = 106.6543332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.8053351950493!2d106.6543332!3d10.845431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zNTAwIFF1YW5nIFRydW5nLCBHw7IgVuG6pXAsIFRow6gbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714801600000" },
                    new Store { Name = "FastFood Phan Văn Trị", Address = "1200 Phan Văn Trị, Gò Vấp, TP.HCM", Phone = "028.3988.2222", Latitude = 10.825431, Longitude = 106.6843332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.7053351950493!2d106.6843332!3d10.825431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTIwMCBQaGFuIFbEg24gVHLhu4ssIEfDsiBW4bqlcCwgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5oLCBWaeG7dCBOYW0!5e0!3m2!1svi!2s!4v1714801700000" },

                    // Thu Duc
                    new Store { Name = "FastFood Thảo Điền", Address = "15 Xuân Thủy, Thảo Điền, Thủ Đức, TP.HCM", Phone = "028.3744.1111", Latitude = 10.805431, Longitude = 106.7343332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.1053351950493!2d106.7343332!3d10.805431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTUgWHXDom4gVGjhu6d5LCBUaOG6o28gxJBp4buTbiwgVGjhu6cgxJDhu6ljLCBUaMOgbmggcGjhu5EgSOG7kyBDaMOtIE1pbmg!5e0!3m2!1svi!2s!4v1714801800000" },
                    new Store { Name = "FastFood Làng Đại Học", Address = "Khu phố 6, Linh Trung, Thủ Đức, TP.HCM", Phone = "028.3744.2222", Latitude = 10.875431, Longitude = 106.7943332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.2053351950493!2d106.7943332!3d10.875431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zS2h1IHBo4buRIDYsIExpbmggVHJ1bmcsIFRo4bunIMSQ4bupYywgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5o!5e0!3m2!1svi!2s!4v1714801900000" },
                    new Store { Name = "FastFood Gigamall", Address = "240 Phạm Văn Đồng, Hiệp Bình Chánh, Thủ Đức", Phone = "028.3744.3333", Latitude = 10.825431, Longitude = 106.7143332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.9053351950493!2d106.7143332!3d10.825431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMjQwIFBo4bqhbSBWxINuIMSQ4buTbmcsIEhp4bu9cCBCw6xuaCBDaMOhbmgsIFRo4bunIMSQ4bupYw!5e0!3m2!1svi!2s!4v1714802000000" },
                    new Store { Name = "FastFood Lê Văn Việt", Address = "50 Lê Văn Việt, Hiệp Phú, Thủ Đức", Phone = "028.3744.4444", Latitude = 10.845431, Longitude = 106.7743332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.5053351950493!2d106.7743332!3d10.845431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zNTAgTMOqIFbEg24gVmnhu4d0LCBIaeG7h3AgUGjDuiwgVGjhu6cgxJDhu6lj!5e0!3m2!1svi!2s!4v1714802100000" },

                    // District 12
                    new Store { Name = "FastFood Phan Văn Hớn", Address = "100 Phan Văn Hớn, Tân Thới Nhất, Quận 12", Phone = "028.3711.1111", Latitude = 10.825431, Longitude = 106.6143332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.9053351950493!2d106.6143332!3d10.825431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTAwIFBoYW4gVsSDbiBI4bubbiwgVMOibiBUaOG7m2kgTmjhuqV0LCBRdeG6rW4gMTI!5e0!3m2!1svi!2s!4v1714802200000" },
                    new Store { Name = "FastFood Nguyễn Ảnh Thủ", Address = "50 Nguyễn Ảnh Thủ, Hiệp Thành, Quận 12", Phone = "028.3711.2222", Latitude = 10.875431, Longitude = 106.6343332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.4053351950493!2d106.6343332!3d10.875431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zNTAgTmd1eeG7hW4g4bqjbmggVGjhu6csIEhp4bu9cCBUaMOgbmgsIFF14bqtbiAxMg!5e0!3m2!1svi!2s!4v1714802300000" },

                    // Binh Tan
                    new Store { Name = "FastFood Tên Lửa", Address = "15 Tên Lửa, An Lạc A, Quận Bình Tân", Phone = "028.3755.1111", Latitude = 10.745431, Longitude = 106.6143332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.7053351950493!2d106.6143332!3d10.745431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTUgVMOqbiBM4busYSwgQW4gTOG6oWMgQSwgUXXhuqtbiBCw6xuaCBUw6Ju!5e0!3m2!1svi!2s!4v1714802400000" },
                    new Store { Name = "FastFood Aeon Mall Bình Tân", Address = "1 Đường số 17A, Bình Trị Đông B, Bình Tân", Phone = "028.3755.2222", Latitude = 10.735431, Longitude = 106.6043332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.8053351950493!2d106.6043332!3d10.735431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMSDEkMaw4budbmcgc-G7kSAxN0EsIELDrG5oIFRy4buLIMSQw7RuZyBCLCBCw6xuaCBUw6Ju!5e0!3m2!1svi!2s!4v1714802500000" },

                    // Suburban
                    new Store { Name = "FastFood Trung Sơn", Address = "Đường số 9, Bình Hưng, Bình Chánh", Phone = "028.3755.3333", Latitude = 10.725431, Longitude = 106.6843332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.9553351950493!2d106.6843332!3d10.725431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zxMaw4budbmcgc-G7kSA5LCBCw6xuaCBIxrhu4tuZywgQsOsbmggQ2jDoW5o!5e0!3m2!1svi!2s!4v1714802600000" },
                    new Store { Name = "FastFood Lê Văn Lương", Address = "1200 Lê Văn Lương, Phước Kiển, Nhà Bè", Phone = "028.3755.4444", Latitude = 10.695431, Longitude = 106.7043332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3920.3053351950493!2d106.7043332!3d10.695431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zMTIwMCBMw6ogVsSDbiBMxrDGoW5nLCBQaMaw4bubYyBLaeG7g24sIE5ow6AgQsO!5e0!3m2!1svi!2s!4v1714802700000" },
                    new Store { Name = "FastFood Đặng Thúc Vịnh", Address = "50 Đặng Thúc Vịnh, Đông Thạnh, Hóc Môn", Phone = "028.3755.5555", Latitude = 10.905431, Longitude = 106.6543332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3918.1053351950493!2d106.6543332!3d10.905431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f9b77db9395%3A0xc33139366e63286f!2zNTAgxJDhurduZyBUaMO6YyBW4buLbmgsIMSQw7RuZyBUaOG6oW5oLCBIw7NjIE3DtG4!5e0!3m2!1svi!2s!4v1714802800000" },
                    new Store { Name = "FastFood Củ Chi", Address = "789 Quốc Lộ 22, TT. Củ Chi, Củ Chi", Phone = "028.3755.6666", Latitude = 11.005431, Longitude = 106.5043332, MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3917.1053351950493!2d106.5043332!3d11.005431!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3174d9b77db9395%3A0xc33139366e63286f!2zNzg5IFF14buRYyBM4buZIDIyLCBUVC4gQ-G7pyBDaGksIEPhu6cgQ2hp!5e0!3m2!1svi!2s!4v1714802900000" }
                };
                context.Stores.AddRange(stores);
                context.SaveChanges();
            }
        }
    }
}
