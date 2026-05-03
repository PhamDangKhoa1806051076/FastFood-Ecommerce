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

    public async Task<IActionResult> GetProductsByCategory(int? categoryId)
    {
        var products = categoryId == null || categoryId == 0
            ? await _context.Products.Include(p => p.Category).ToListAsync()
            : await _context.Products.Where(p => p.CategoryId == categoryId).Include(p => p.Category).ToListAsync();
        
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
