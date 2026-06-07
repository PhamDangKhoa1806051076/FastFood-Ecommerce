using FastFoodEcommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastFoodEcommerce.Controllers;

public class PromotionController : Controller
{
    private readonly ApplicationDbContext _context;

    public PromotionController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var vouchers = await _context.Vouchers.OrderByDescending(v => v.EndDate).ToListAsync();
        return View(vouchers);
    }
}

public class StoreController : Controller
{
    private readonly ApplicationDbContext _context;

    public StoreController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var stores = await _context.Stores.ToListAsync();
        return View(stores);
    }
}
