using FastFoodEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFoodEcommerce.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<LoyaltyPoint> LoyaltyPoints { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Banner> Banners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // You can add data seeding or fluent API configurations here if needed
        }
    }
}
