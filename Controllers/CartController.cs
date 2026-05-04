using FastFoodEcommerce.Data;
using FastFoodEcommerce.Helpers;
using FastFoodEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastFoodEcommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string CART_KEY = "FastFoodCart";

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CART_KEY) ?? new List<CartItem>();
            return View(cart);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CART_KEY) ?? new List<CartItem>();

            var cartItem = cart.FirstOrDefault(c => c.ProductId == id);
            if (cartItem == null)
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1,
                    ImageUrl = product.ImageUrl
                });
            }
            else
            {
                cartItem.Quantity++;
            }

            HttpContext.Session.SetObjectAsJson(CART_KEY, cart);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CART_KEY) ?? new List<CartItem>();
            var itemToRemove = cart.FirstOrDefault(c => c.ProductId == id);
            
            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
            }

            HttpContext.Session.SetObjectAsJson(CART_KEY, cart);
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CART_KEY) ?? new List<CartItem>();
            if (cart.Count == 0) return RedirectToAction("Index");

            var total = cart.Sum(c => c.Total);
            var discount = HttpContext.Session.GetDecimal("CartDiscount") ?? 0;
            var voucherCode = HttpContext.Session.GetString("AppliedVoucher");

            return View(new Order 
            { 
                TotalAmount = total - discount,
                DiscountAmount = discount,
                VoucherCode = voucherCode
            });
        }

        [HttpPost]
        public async Task<IActionResult> ApplyVoucher(string code)
        {
            if (string.IsNullOrEmpty(code)) return Json(new { success = false, message = "Vui lòng nhập mã" });

            var voucher = await _context.Vouchers.FirstOrDefaultAsync(v => v.Code == code);
            if (voucher == null || !voucher.IsActive)
            {
                return Json(new { success = false, message = "Mã không hợp lệ hoặc đã hết hạn" });
            }

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CART_KEY) ?? new List<CartItem>();
            var total = cart.Sum(c => c.Total);
            var discount = (total * voucher.DiscountPercentage) / 100;

            HttpContext.Session.SetDecimal("CartDiscount", discount);
            HttpContext.Session.SetString("AppliedVoucher", code);

            return Json(new { success = true, discount = discount, total = total - discount });
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CART_KEY) ?? new List<CartItem>();
            if (cart.Count == 0) return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                var total = cart.Sum(c => c.Total);
                var discount = HttpContext.Session.GetDecimal("CartDiscount") ?? 0;
                var voucherCode = HttpContext.Session.GetString("AppliedVoucher");

                order.OrderDate = DateTime.Now;
                order.Status = "Pending";
                order.TotalAmount = total - discount;
                order.DiscountAmount = discount;
                order.VoucherCode = voucherCode;

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                foreach (var item in cart)
                {
                    var detail = new OrderDetail
                    {
                        OrderId = order.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.Price
                    };
                    _context.OrderDetails.Add(detail);
                }
                await _context.SaveChangesAsync();

                // Clear cart and voucher
                HttpContext.Session.Remove(CART_KEY);
                HttpContext.Session.Remove("CartDiscount");
                HttpContext.Session.Remove("AppliedVoucher");

                return View("OrderSuccess", order.Id);
            }

            return View(order);
        }
    }
}
