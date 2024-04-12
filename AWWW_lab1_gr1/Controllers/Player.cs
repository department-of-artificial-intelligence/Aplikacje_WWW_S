using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr1.Controllers
{
    public class Player : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
