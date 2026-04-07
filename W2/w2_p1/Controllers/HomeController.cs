using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using w2_p1.Models;

namespace w2_p1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            var articles = Repository.Articles;
            return View(articles);
        }
    }
}
