using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace AWWW_lab02_gr3.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
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