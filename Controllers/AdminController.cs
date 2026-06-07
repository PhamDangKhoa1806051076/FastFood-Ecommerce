using FastFoodEcommerce.Data;
using FastFoodEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClosedXML.Excel;

namespace FastFoodEcommerce.Controllers;

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

    private async Task LogAction(string action, string details = "")
    {
        var adminEmail = HttpContext.Session.GetString("UserEmail") ?? "Admin";
        var log = new AuditLog
        {
            AdminEmail = adminEmail,
            Action = action,
            Details = details,
            IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
            Timestamp = DateTime.Now
        };
        _context.AuditLogs.Add(log);
        await _context.SaveChangesAsync();
    }

    public async Task<IActionResult> Index()
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");
        
        ViewBag.OrderCount = await _context.Orders.AsNoTracking().CountAsync();
        ViewBag.ProductCount = await _context.Products.AsNoTracking().CountAsync();
        ViewBag.VoucherCount = await _context.Vouchers.AsNoTracking().CountAsync();
        
        // Today's Stats
        var today = DateTime.Today;
        ViewBag.TodayOrders = await _context.Orders.AsNoTracking().CountAsync(o => o.OrderDate >= today);
        ViewBag.TodayRevenue = await _context.Orders.AsNoTracking()
            .Where(o => o.OrderDate >= today && (o.Status == "Completed" || o.Status == "Pending"))
            .SumAsync(o => o.TotalAmount);
        ViewBag.PendingOrders = await _context.Orders.AsNoTracking().CountAsync(o => o.Status == "Pending");

        // Calculate real total revenue
        ViewBag.TotalRevenue = await _context.Orders.AsNoTracking()
            .Where(o => o.Status == "Completed" || o.Status == "Pending")
            .SumAsync(o => o.TotalAmount);

        // Fetch best-selling products (top 5)
        var topProducts = await _context.OrderDetails.AsNoTracking()
            .GroupBy(od => od.Product!.Name)
            .Select(g => new TopProductViewModel { Name = g.Key, Count = g.Sum(od => od.Quantity) })
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
            var dayRevenue = await _context.Orders.AsNoTracking()
                .Where(o => o.OrderDate.Date == date.Date && (o.Status == "Completed" || o.Status == "Pending"))
                .SumAsync(o => o.TotalAmount);
            chartData.Add(dayRevenue);
        }
        ViewBag.ChartLabels = chartLabels;
        ViewBag.ChartData = chartData;
        
        var recentOrders = await _context.Orders.AsNoTracking().OrderByDescending(o => o.OrderDate).Take(10).ToListAsync();
        return View(recentOrders);
    }

    // Product Management
    public async Task<IActionResult> Products()
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");
        var products = await _context.Products.AsNoTracking().Include(p => p.Category).ToListAsync();
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
            await LogAction("Thêm sản phẩm", $"Tên: {product.Name}, Giá: {product.Price}, Kho: {product.StockQuantity}");
            return RedirectToAction(nameof(Products));
        }
        ViewBag.Categories = _context.Categories.ToList();
        return View(product);
    }

    public async Task<IActionResult> EditProduct(int id)
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");
        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound();
        ViewBag.Categories = _context.Categories.ToList();
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> EditProduct(Product product)
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");
        if (ModelState.IsValid)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            await LogAction("Cập nhật sản phẩm", $"ID: {product.Id}, Tên: {product.Name}");
            return RedirectToAction(nameof(Products));
        }
        ViewBag.Categories = _context.Categories.ToList();
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        if (!IsAdmin()) return Json(new { success = false, message = "Unauthorized" });
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            await LogAction("Xóa sản phẩm", $"Tên: {product.Name}");
            return Json(new { success = true });
        }
        return Json(new { success = false, message = "Product not found" });
    }

    // Order Management
    public async Task<IActionResult> Orders()
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");
        var orders = await _context.Orders.AsNoTracking().OrderByDescending(o => o.OrderDate).ToListAsync();
        return View(orders);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateOrderStatus(int orderId, string status)
    {
        if (!IsAdmin()) return Json(new { success = false, message = "Unauthorized" });

        var order = await _context.Orders.FindAsync(orderId);
        if (order != null)
        {
            string oldStatus = order.Status;
            order.Status = status;
            await _context.SaveChangesAsync();
            await LogAction("Cập nhật trạng thái đơn hàng", $"Đơn hàng #{orderId}: {oldStatus} -> {status}");
            return Json(new { success = true });
        }
        return Json(new { success = false, message = "Order not found" });
    }

    [HttpPost]
    public async Task<IActionResult> DeleteOrder(int orderId)
    {
        if (!IsAdmin()) return Json(new { success = false, message = "Unauthorized" });

        var order = await _context.Orders.FindAsync(orderId);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            await LogAction("Xóa đơn hàng", $"Đơn hàng #{orderId} của {order.CustomerName}");
            return Json(new { success = true });
        }
        return Json(new { success = false, message = "Order not found" });
    }

    // Inventory Management
    public async Task<IActionResult> Inventory()
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");
        var products = await _context.Products.AsNoTracking().Include(p => p.Category).OrderBy(p => p.StockQuantity).ToListAsync();
        return View(products);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStock(int productId, int quantity)
    {
        if (!IsAdmin()) return Json(new { success = false, message = "Unauthorized" });
        
        var product = await _context.Products.FindAsync(productId);
        if (product != null)
        {
            int oldStock = product.StockQuantity;
            product.StockQuantity += quantity;
            await _context.SaveChangesAsync();
            await LogAction("Cập nhật kho", $"Sản phẩm: {product.Name}, Cũ: {oldStock}, Mới: {product.StockQuantity}");
            return Json(new { success = true, newStock = product.StockQuantity });
        }
        return Json(new { success = false, message = "Product not found" });
    }

    // Banner Management
    public async Task<IActionResult> Banners()
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");
        var banners = await _context.Banners.AsNoTracking().OrderBy(b => b.DisplayOrder).ToListAsync();
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
            await LogAction("Thêm Banner", $"Tiêu đề: {banner.Title}, Link: {banner.LinkUrl}");
            return RedirectToAction(nameof(Banners));
        }
        return View(banner);
    }

    public async Task<IActionResult> EditBanner(int id)
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");
        var banner = await _context.Banners.FindAsync(id);
        if (banner == null) return NotFound();
        return View(banner);
    }

    [HttpPost]
    public async Task<IActionResult> EditBanner(Banner banner)
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");
        if (ModelState.IsValid)
        {
            _context.Update(banner);
            await _context.SaveChangesAsync();
            await LogAction("Cập nhật Banner", $"ID: {banner.Id}, Tiêu đề: {banner.Title}");
            return RedirectToAction(nameof(Banners));
        }
        return View(banner);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteBanner(int id)
    {
        if (!IsAdmin()) return Json(new { success = false, message = "Unauthorized" });

        var banner = await _context.Banners.FindAsync(id);
        if (banner != null)
        {
            _context.Banners.Remove(banner);
            await _context.SaveChangesAsync();
            await LogAction("Xóa Banner", $"Tiêu đề: {banner.Title}");
            return Json(new { success = true });
        }
        return Json(new { success = false, message = "Banner not found" });
    }

    // Excel Export
    public async Task<IActionResult> ExportSalesToExcel()
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");

        var orders = await _context.Orders.AsNoTracking().OrderByDescending(o => o.OrderDate).ToListAsync();

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
                worksheet.Cell(currentRow, 6).Value = order.Address;
            }

            worksheet.Columns().AdjustToContents();

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                await LogAction("Xuất báo cáo Excel", $"Tài liệu: SalesReport_{DateTime.Now:yyyyMMddHHmm}.xlsx");
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"SalesReport_{DateTime.Now:yyyyMMddHHmm}.xlsx");
            }
        }
    }

    // Voucher Management
    public async Task<IActionResult> Vouchers()
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");
        var vouchers = await _context.Vouchers.AsNoTracking().OrderByDescending(v => v.EndDate).ToListAsync();
        return View(vouchers);
    }

    public IActionResult CreateVoucher()
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateVoucher(Voucher voucher)
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");
        if (ModelState.IsValid)
        {
            _context.Vouchers.Add(voucher);
            await _context.SaveChangesAsync();
            await LogAction("Thêm Voucher", $"Mã: {voucher.Code}, Giảm: {voucher.DiscountPercentage}%");
            return RedirectToAction(nameof(Vouchers));
        }
        return View(voucher);
    }

    public async Task<IActionResult> EditVoucher(int id)
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");
        var voucher = await _context.Vouchers.FindAsync(id);
        if (voucher == null) return NotFound();
        return View(voucher);
    }

    [HttpPost]
    public async Task<IActionResult> EditVoucher(Voucher voucher)
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");
        if (ModelState.IsValid)
        {
            _context.Update(voucher);
            await _context.SaveChangesAsync();
            await LogAction("Cập nhật Voucher", $"ID: {voucher.Id}, Mã: {voucher.Code}");
            return RedirectToAction(nameof(Vouchers));
        }
        return View(voucher);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteVoucher(int id)
    {
        if (!IsAdmin()) return Json(new { success = false, message = "Unauthorized" });
        var voucher = await _context.Vouchers.FindAsync(id);
        if (voucher != null)
        {
            _context.Vouchers.Remove(voucher);
            await _context.SaveChangesAsync();
            await LogAction("Xóa Voucher", $"Mã: {voucher.Code}");
            return Json(new { success = true });
        }
        return Json(new { success = false, message = "Voucher not found" });
    }

    public async Task<IActionResult> AuditLogs()
    {
        if (!IsAdmin()) return RedirectToAction("Login", "Account");
        var logs = await _context.AuditLogs.AsNoTracking().OrderByDescending(l => l.Timestamp).Take(100).ToListAsync();
        return View(logs);
    }
}
