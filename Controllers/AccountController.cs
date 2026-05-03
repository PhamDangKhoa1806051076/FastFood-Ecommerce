using Microsoft.AspNetCore.Mvc;

namespace FastFoodEcommerce.Controllers
{
    public class AccountController : Controller
    {
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
            // Dummy authentication logic
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin.");
                return View();
            }

            // Store email in session to pass to next step
            HttpContext.Session.SetString("PendingEmail", email);
            HttpContext.Session.SetString("PendingPassword", password);

            return RedirectToAction("VerifyPhone");
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
            // Simulate OTP success
            var email = HttpContext.Session.GetString("PendingEmail") ?? "";
            
            // Set User Session
            HttpContext.Session.SetString("UserEmail", email);
            
            // Basic Role assignment
            if (email.ToLower() == "admin@fastfood.com")
            {
                HttpContext.Session.SetString("UserRole", "Admin");
            }
            else
            {
                HttpContext.Session.SetString("UserRole", "Customer");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
