using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using w2_p3.Models;

namespace w2_p3.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _dbContext;

        public HomeController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Home";

            var articles = _dbContext.Articles.ToList(); 
            return View(articles);
        }
    }
}
