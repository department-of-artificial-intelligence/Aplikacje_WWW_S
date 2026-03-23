using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}