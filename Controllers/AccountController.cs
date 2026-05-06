using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FastFoodEcommerce.Data;
using FastFoodEcommerce.Models;

namespace FastFoodEcommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string email, string password, string name)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return View();
            }

            // Store registration info in session
            HttpContext.Session.SetString("PendingEmail", email);
            HttpContext.Session.SetString("PendingPassword", password);
            HttpContext.Session.SetString("PendingName", name);

            return RedirectToAction("VerifyPhone");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin.");
                return View();
            }

            // ── Tài khoản Admin cố định ──
            if (email.ToLower() == "admin@fastfood.com" && password == "123")
            {
                HttpContext.Session.SetString("UserEmail", email);
                HttpContext.Session.SetString("UserRole", "Admin");
                HttpContext.Session.SetString("UserName", "Administrator");
                return RedirectToAction("Index", "Admin");
            }

            // ── Tài khoản User thường cố định ──
            if (email.ToLower() == "user@fastfood.com" && password == "123")
            {
                HttpContext.Session.SetString("UserEmail", email);
                HttpContext.Session.SetString("UserRole", "Customer");
                HttpContext.Session.SetString("UserName", "Nguyễn Văn A");
                return RedirectToAction("Index", "Home");
            }

            // Sai thông tin
            ModelState.AddModelError("", "Email hoặc mật khẩu không đúng.");
            return View();
        }

        [HttpGet]
        public IActionResult VerifyPhone()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VerifyPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return View();
            HttpContext.Session.SetString("PendingPhone", phone);
            
            // Tạo mã OTP giả lập để người dùng thấy
            TempData["MockOTP"] = "123456";
            
            return RedirectToAction("VerifyOtp");
        }

        [HttpGet]
        public IActionResult VerifyOtp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VerifyOtp(string otp)
        {
            // Simulate OTP success (dùng cho luồng đăng ký)
            var email = HttpContext.Session.GetString("PendingEmail") ?? "";
            var name  = HttpContext.Session.GetString("PendingName") ?? "Khách hàng";

            HttpContext.Session.SetString("UserEmail", email);
            HttpContext.Session.SetString("UserName", name);

            if (email.ToLower() == "admin@fastfood.com")
                HttpContext.Session.SetString("UserRole", "Admin");
            else
                HttpContext.Session.SetString("UserRole", "Customer");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Orders()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email)) return RedirectToAction("Login");

            var orders = await _context.Orders
                .Where(o => o.CustomerEmail == email)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> Loyalty()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email)) return RedirectToAction("Login");

            var pointsHistory = await _context.LoyaltyPoints
                .Where(l => l.UserId == email)
                .OrderByDescending(l => l.CreatedAt)
                .ToListAsync();

            var totalPoints = pointsHistory.Sum(l => l.Points);

            var notifications = await _context.Notifications
                .Where(n => n.UserId == email)
                .OrderByDescending(n => n.CreatedAt)
                .Take(5)
                .ToListAsync();

            ViewBag.TotalPoints = totalPoints;
            ViewBag.CurrentRank = totalPoints < 500 ? "Thành viên" :
                                 totalPoints < 2000 ? "Đồng" :
                                 totalPoints < 5000 ? "Bạc" :
                                 totalPoints < 10000 ? "Vàng" : "Kim Cương";
            
            ViewBag.Notifications = notifications;

            return View(pointsHistory);
        }

        [HttpPost]
        public async Task<IActionResult> RedeemPoints(int pointsToRedeem)
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email)) return Json(new { success = false, message = "Vui lòng đăng nhập" });

            if (pointsToRedeem < 100) return Json(new { success = false, message = "Cần tối thiểu 100 điểm để đổi" });

            var totalPoints = await _context.LoyaltyPoints.Where(l => l.UserId == email).SumAsync(l => l.Points);
            if (totalPoints < pointsToRedeem)
            {
                return Json(new { success = false, message = "Không đủ điểm" });
            }

            // Create a unique voucher code
            var code = $"REDEEM-{DateTime.Now.Ticks.ToString().Substring(10)}";
            // 100 điểm = giảm 20.000đ => ratio: 1 point = 200đ
            decimal discountAmount = pointsToRedeem * 200;

            _context.Vouchers.Add(new Voucher
            {
                Code = code,
                DiscountPercentage = 0,
                DiscountAmount = discountAmount,
                Description = $"Đổi {pointsToRedeem} điểm thưởng",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(30)
            });

            _context.LoyaltyPoints.Add(new LoyaltyPoint
            {
                UserId = email,
                Points = -pointsToRedeem,
                Source = $"Đổi {pointsToRedeem} điểm lấy mã {code}"
            });

            _context.Notifications.Add(new Notification
            {
                UserId = email,
                Title = "Đổi mã thành công",
                Message = $"Bạn đã đổi {pointsToRedeem} điểm lấy voucher {code} trị giá {discountAmount.ToString("N0")}đ."
            });

            await _context.SaveChangesAsync();

            return Json(new { success = true, message = $"Đổi điểm thành công! Mã Voucher của bạn là: {code}" });
        }
    }
}
