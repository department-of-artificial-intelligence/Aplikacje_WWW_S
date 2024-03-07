using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers
{
    public class HomeController : Controller{
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }
    }
}
