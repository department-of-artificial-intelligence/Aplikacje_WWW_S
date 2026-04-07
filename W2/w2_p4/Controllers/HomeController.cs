using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using w2_p4.Models;

namespace w2_p4.Controllers
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

            var query = _dbContext.Articles.
                OrderByDescending(a => a.Id);
                //Include(article => article.Tags).
                //Include(article => article.Author);
            var articles = query.ToList();
            return View(articles);
        }
    }
}
