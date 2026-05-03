using Microsoft.AspNetCore.Mvc;

namespace FastFoodEcommerce.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Placeholder for login logic
            return RedirectToAction("VerifyPhone");
        }

        [HttpGet]
        public IActionResult Register()
        {
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
            // Placeholder for OTP logic
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
            // Redirect to home after success
            return RedirectToAction("Index", "Home");
        }
    }
}
