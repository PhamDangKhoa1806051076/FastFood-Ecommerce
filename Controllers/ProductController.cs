using FastFoodEcommerce.Data;
using FastFoodEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastFoodEcommerce.Controllers;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Product/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Reviews)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null) return NotFound();

        var suggestedProducts = await _context.Products
            .Where(p => p.CategoryId == product.CategoryId && p.Id != id)
            .Take(4)
            .ToListAsync();
        
        ViewBag.SuggestedProducts = suggestedProducts;

        var userEmail = HttpContext.Session.GetString("UserEmail");
        ViewBag.IsInWishlist = false;
        if (!string.IsNullOrEmpty(userEmail))
        {
            ViewBag.IsInWishlist = await _context.WishlistItems.AnyAsync(w => w.ProductId == id && w.UserEmail == userEmail);
        }

        return View(product);
    }

    // POST: Product/SubmitReview
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SubmitReview(int productId, int rating, string? comment)
    {
        var userEmail = HttpContext.Session.GetString("UserEmail");
        if (string.IsNullOrEmpty(userEmail))
        {
            TempData["Error"] = "Bạn cần đăng nhập để gửi đánh giá.";
            return RedirectToAction("Details", new { id = productId });
        }

        // Prevent duplicate reviews
        var existing = await _context.Reviews
            .FirstOrDefaultAsync(r => r.ProductId == productId && r.UserEmail == userEmail);

        if (existing != null)
        {
            // Update existing review
            existing.Rating = rating;
            existing.Comment = comment;
            existing.CreatedAt = DateTime.Now;
            _context.Reviews.Update(existing);
        }
        else
        {
            var review = new Review
            {
                ProductId = productId,
                Rating = rating,
                Comment = comment,
                UserEmail = userEmail,
                UserName = userEmail.Split('@')[0],
                CreatedAt = DateTime.Now
            };
            _context.Reviews.Add(review);
        }

        await _context.SaveChangesAsync();
        TempData["Success"] = "Cảm ơn bạn đã đánh giá!";
        return RedirectToAction("Details", new { id = productId });
    }

    [HttpPost]
    public async Task<IActionResult> ToggleWishlist(int productId)
    {
        var userEmail = HttpContext.Session.GetString("UserEmail");
        if (string.IsNullOrEmpty(userEmail)) return Json(new { success = false, message = "Vui lòng đăng nhập!" });

        var existing = await _context.WishlistItems.FirstOrDefaultAsync(w => w.ProductId == productId && w.UserEmail == userEmail);
        bool isAdded = false;
        if (existing != null)
        {
            _context.WishlistItems.Remove(existing);
        }
        else
        {
            _context.WishlistItems.Add(new WishlistItem { ProductId = productId, UserEmail = userEmail });
            isAdded = true;
        }
        await _context.SaveChangesAsync();
        return Json(new { success = true, isAdded = isAdded });
    }
}
