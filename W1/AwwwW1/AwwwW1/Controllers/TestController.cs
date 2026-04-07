using AwwwW1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AwwwW1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            ViewData["MojeDane"] = "Moje dane tekstowe";
            return View();
        }


    }
}
