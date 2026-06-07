using Microsoft.AspNetCore.Mvc;

namespace FastFoodEcommerce.Controllers;

public class InfoController : Controller
{
    public IActionResult OurStory()
    {
        return View();
    }

    public IActionResult News()
    {
        return View();
    }

    public IActionResult Recruitment()
    {
        return View();
    }
}
