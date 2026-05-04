using FastFoodEcommerce.Data;
using FastFoodEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastFoodEcommerce.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Custom check for Admin Role in Session
        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("UserRole") == "Admin";
        }

        public async Task<IActionResult> Index()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            
            ViewBag.OrderCount = await _context.Orders.CountAsync();
            ViewBag.ProductCount = await _context.Products.CountAsync();
            ViewBag.VoucherCount = await _context.Vouchers.CountAsync();
            
            // Calculate real total revenue
            ViewBag.TotalRevenue = await _context.Orders
                .Where(o => o.Status == "Completed" || o.Status == "Pending") // Include pending for now to show something
                .SumAsync(o => o.TotalAmount);

            // Fetch best-selling products (top 5)
            var topProducts = await _context.OrderDetails
                .GroupBy(od => od.Product!.Name)
                .Select(g => new { Name = g.Key, Count = g.Sum(od => od.Quantity) })
                .OrderByDescending(x => x.Count)
                .Take(5)
                .ToListAsync();
            ViewBag.TopProducts = topProducts;
            
            var recentOrders = await _context.Orders.OrderByDescending(o => o.OrderDate).Take(5).ToListAsync();
            return View(recentOrders);
        }

        // Product Management
        public async Task<IActionResult> Products()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return View(products);
        }

        public IActionResult CreateProduct()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Products));
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(product);
        }

        // Order Management
        public async Task<IActionResult> Orders()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var orders = await _context.Orders.OrderByDescending(o => o.OrderDate).ToListAsync();
            return View(orders);
        }
    }
}
