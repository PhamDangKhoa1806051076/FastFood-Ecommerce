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

            foreach (var p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }
    }
}
