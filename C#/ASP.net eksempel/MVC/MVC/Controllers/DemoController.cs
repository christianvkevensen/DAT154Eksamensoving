using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome(string temp, int num)
        {
            ViewData["Message"] = temp;
            ViewData["NumTimes"] = num;

            return View();
        }
    }
}
