using FastFoodEcommerce.Data;
using FastFoodEcommerce.Models;
using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FastFoodDb;Trusted_Connection=True;MultipleActiveResultSets=true");

using var context = new ApplicationDbContext(optionsBuilder.Options);

if (!context.Banners.Any())
{
    context.Banners.AddRange(new List<Banner>
    {
        new Banner 
        { 
            Title = "MIỄN PHÍ VẬN CHUYỂN", 
            SubTitle = "Cho đơn hàng từ 200k trở lên! Đặt ngay hôm nay.", 
            ImageUrl = "https://images.unsplash.com/photo-1513104890138-7c749659a591?q=80&w=1200",
            IsActive = true,
            DisplayOrder = -1 // For Top Bar
        },
        new Banner 
        { 
            Title = "COMBO SIÊU TIẾT KIỆM", 
            SubTitle = "Giảm ngay 30% khi mua Combo Gà Rán + Burger.", 
            ImageUrl = "https://images.unsplash.com/photo-1594212699903-ec8a3eca50f5?q=80&w=1200",
            IsActive = true,
            DisplayOrder = 1 // For Main Carousel
        },
        new Banner 
        { 
            Title = "ƯU ĐÃI THÀNH VIÊN", 
            SubTitle = "Đăng ký thành viên ngay để nhận voucher 50k.", 
            ImageUrl = "https://images.unsplash.com/photo-1550547660-d9450f859349?q=80&w=1200",
            IsActive = true,
            DisplayOrder = 100 // For Bottom Banner
        }
    });
    context.SaveChanges();
    Console.WriteLine("Seed banners success!");
}
else
{
    Console.WriteLine("Banners already exist.");
}
