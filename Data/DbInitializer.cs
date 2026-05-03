using FastFoodEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodEcommerce.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Kiểm tra xem đã có dữ liệu chưa
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

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
            if (!context.Stores.Any())
            {
                var stores = new Store[]
                {
                    new Store { Name = "FastFood Hoàn Kiếm", Address = "12 Tràng Thi, Hoàn Kiếm, Hà Nội", Phone = "024.3824.1234", MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3724.0853549646633!2d105.84542287510528!3d21.02927238776269!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3135ab9598282363%3A0xc33139366e63286f!2zMTIgVHLDoG5nIFRoaSwgSMOgbmZyLCBIw6AgTuG7mWksIFZp4buHdCBOYW0!5e0!3m2!1svi!2s!4v1714750000000!5m2!1svi!2s" },
                    new Store { Name = "FastFood Quận 1", Address = "123 Lê Lợi, Bến Thành, Quận 1, TP.HCM", Phone = "028.3829.5678", MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.460232428514!2d106.69752637500445!3d10.772186959195932!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f3f8863f695%3A0x280e224e7512d7c5!2zMTIzIEzDqiBM4bujaSwgQuG6v24gVGjDoG5oLCBRdeG6rW4gMSwgVGjDoG5oIHBo4buRIEjhu5MgQ2jDrSBNaW5oLCBWaeG7dCBOYW0!5e0!3m2!1svi!2s!4v1714750100000!5m2!1svi!2s" }
                };
                context.Stores.AddRange(stores);
                context.SaveChanges();
            }
        }
    }
}
