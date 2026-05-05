using FastFoodEcommerce.Data;
using FastFoodEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClosedXML.Excel;
using System.IO;

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
            
            // Today's Stats
            var today = DateTime.Today;
            ViewBag.TodayOrders = await _context.Orders.CountAsync(o => o.OrderDate >= today);
            ViewBag.TodayRevenue = await _context.Orders
                .Where(o => o.OrderDate >= today && (o.Status == "Completed" || o.Status == "Pending"))
                .SumAsync(o => o.TotalAmount);
            ViewBag.PendingOrders = await _context.Orders.CountAsync(o => o.Status == "Pending");

            // Calculate real total revenue
            ViewBag.TotalRevenue = await _context.Orders
                .Where(o => o.Status == "Completed" || o.Status == "Pending")
                .SumAsync(o => o.TotalAmount);

            // Fetch best-selling products (top 5)
            var topProducts = await _context.OrderDetails
                .GroupBy(od => od.Product!.Name)
                .Select(g => new { Name = g.Key, Count = g.Sum(od => od.Quantity) })
                .OrderByDescending(x => x.Count)
                .Take(5)
                .ToListAsync();
            ViewBag.TopProducts = topProducts;

            // Chart data: Last 7 days revenue
            var last7Days = Enumerable.Range(0, 7).Select(i => DateTime.Today.AddDays(-i)).Reverse().ToList();
            var chartLabels = last7Days.Select(d => d.ToString("dd/MM")).ToList();
            var chartData = new List<decimal>();
            foreach (var date in last7Days)
            {
                var dayRevenue = await _context.Orders
                    .Where(o => o.OrderDate.Date == date.Date && (o.Status == "Completed" || o.Status == "Pending"))
                    .SumAsync(o => o.TotalAmount);
                chartData.Add(dayRevenue);
            }
            ViewBag.ChartLabels = chartLabels;
            ViewBag.ChartData = chartData;
            
            var recentOrders = await _context.Orders.OrderByDescending(o => o.OrderDate).Take(10).ToListAsync();
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

        // Inventory Management
        public async Task<IActionResult> Inventory()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var products = await _context.Products.Include(p => p.Category).OrderBy(p => p.StockQuantity).ToListAsync();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStock(int productId, int quantity)
        {
            if (!IsAdmin()) return Json(new { success = false, message = "Unauthorized" });
            
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                product.StockQuantity += quantity;
                await _context.SaveChangesAsync();
                return Json(new { success = true, newStock = product.StockQuantity });
            }
            return Json(new { success = false, message = "Product not found" });
        }

        // Banner Management
        public async Task<IActionResult> Banners()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            var banners = await _context.Banners.OrderBy(b => b.DisplayOrder).ToListAsync();
            return View(banners);
        }

        public IActionResult CreateBanner()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(Banner banner)
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");
            if (ModelState.IsValid)
            {
                _context.Banners.Add(banner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Banners));
            }
            return View(banner);
        }

        // Excel Export
        public async Task<IActionResult> ExportSalesToExcel()
        {
            if (!IsAdmin()) return RedirectToAction("Login", "Account");

            var orders = await _context.Orders.OrderByDescending(o => o.OrderDate).ToListAsync();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sales Report");
                var currentRow = 1;

                // Header
                worksheet.Cell(currentRow, 1).Value = "Mã Đơn";
                worksheet.Cell(currentRow, 2).Value = "Khách Hàng";
                worksheet.Cell(currentRow, 3).Value = "Ngày Đặt";
                worksheet.Cell(currentRow, 4).Value = "Tổng Tiền";
                worksheet.Cell(currentRow, 5).Value = "Trạng Thái";
                worksheet.Cell(currentRow, 6).Value = "Địa Chỉ";

                worksheet.Row(currentRow).Style.Font.Bold = true;
                worksheet.Row(currentRow).Style.Fill.BackgroundColor = XLColor.LightGray;

                // Data
                foreach (var order in orders)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = order.Id;
                    worksheet.Cell(currentRow, 2).Value = order.CustomerName;
                    worksheet.Cell(currentRow, 3).Value = order.OrderDate.ToString("dd/MM/yyyy HH:mm");
                    worksheet.Cell(currentRow, 4).Value = order.TotalAmount;
                    worksheet.Cell(currentRow, 5).Value = order.Status;
                    worksheet.Cell(currentRow, 6).Value = order.ShippingAddress;
                }

                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"SalesReport_{DateTime.Now:yyyyMMddHHmm}.xlsx");
                }
            }
        }
    }
}
