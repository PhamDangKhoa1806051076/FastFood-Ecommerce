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
        var categories = await _context.Categories.ToListAsync();
        var products = await _context.Products.Include(p => p.Category).ToListAsync();
        ViewBag.Categories = categories;
        return View(products);
    }

    public async Task<IActionResult> GetProductsByCategory(int? categoryId, decimal? minPrice, decimal? maxPrice, int? minRating)
    {
        var query = _context.Products
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

        var products = await query.ToListAsync();

        if (minRating != null && minRating > 0)
        {
            products = products.Where(p => (p.Reviews != null && p.Reviews.Any() ? p.Reviews.Average(r => r.Rating) : 0) >= minRating.Value).ToList();
        }
        
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
