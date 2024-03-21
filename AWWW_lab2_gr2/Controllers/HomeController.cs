using System.Diagnostics;
using AWWW_lab2_gr2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}

