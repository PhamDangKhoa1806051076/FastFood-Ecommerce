using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FastFoodEcommerce.Models;
using FastFoodEcommerce.Data;

namespace FastFoodEcommerce.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _context.Categories.AsNoTracking().ToListAsync();
        var products = await _context.Products.AsNoTracking().Include(p => p.Category).ToListAsync();
        var banners = await _context.Banners.AsNoTracking().Where(b => b.IsActive).OrderBy(b => b.DisplayOrder).ToListAsync();
        ViewBag.Categories = categories;
        ViewBag.Banners = banners;
        return View(products);
    }

    [ResponseCache(Duration = 60, VaryByQueryKeys = new[] { "*" })]
    public async Task<IActionResult> GetProductsByCategory(int? categoryId, decimal? minPrice, decimal? maxPrice, int? minRating, string sort = "newest")
    {
        var query = _context.Products.AsNoTracking()
            .Include(p => p.Category)
            .Include(p => p.Reviews)
            .AsQueryable();

        if (categoryId != null && categoryId > 0)
        {
            query = query.Where(p => p.CategoryId == categoryId);
        }

        if (minPrice != null)
        {
            query = query.Where(p => p.Price >= minPrice.Value);
        }

        if (maxPrice != null)
        {
            query = query.Where(p => p.Price <= maxPrice.Value);
        }

        if (minRating != null && minRating > 0)
        {
            query = query.Where(p => p.Reviews != null && p.Reviews.Any() && p.Reviews.Average(r => r.Rating) >= minRating.Value);
        }

        // Sorting
        query = sort switch
        {
            "price_asc" => query.OrderBy(p => p.Price),
            "price_desc" => query.OrderByDescending(p => p.Price),
            _ => query.OrderByDescending(p => p.Id) // newest
        };

        var products = await query.ToListAsync();
        
        return PartialView("_ProductList", products);
    }

    public IActionResult ChangeLanguage(string culture)
    {
        Response.Cookies.Append(
            "FastFoodLanguage",
            culture,
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        );
        return Redirect(Request.Headers["Referer"].ToString());
    }

    [Route("sitemap.xml")]
    [ResponseCache(Duration = 86400, Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> Sitemap()
    {
        var products = await _context.Products.ToListAsync();
        var domain = $"{Request.Scheme}://{Request.Host}";

        var xml = new System.Text.StringBuilder();
        xml.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        xml.AppendLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");

        // Home Page
        xml.AppendLine("  <url>");
        xml.AppendLine($"    <loc>{domain}/</loc>");
        xml.AppendLine($"    <lastmod>{DateTime.UtcNow.ToString("yyyy-MM-dd")}</lastmod>");
        xml.AppendLine("    <changefreq>daily</changefreq>");
        xml.AppendLine("    <priority>1.0</priority>");
        xml.AppendLine("  </url>");

        // Products
        foreach (var product in products)
        {
            xml.AppendLine("  <url>");
            xml.AppendLine($"    <loc>{domain}/Product/Details/{product.Id}</loc>");
            xml.AppendLine($"    <lastmod>{DateTime.UtcNow.ToString("yyyy-MM-dd")}</lastmod>");
            xml.AppendLine("    <changefreq>weekly</changefreq>");
            xml.AppendLine("    <priority>0.8</priority>");
            xml.AppendLine("  </url>");
        }

        xml.AppendLine("</urlset>");

        return Content(xml.ToString(), "application/xml", System.Text.Encoding.UTF8);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
