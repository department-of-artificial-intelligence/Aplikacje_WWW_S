using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr2.Controllers
{
    public class HomeController : Controller {
        public IActionResult Index() {
            ViewBag.Title = "Home";
            return View();
        }
    }
    }