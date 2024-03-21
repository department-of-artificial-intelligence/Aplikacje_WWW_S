using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            var articles = _dbContext.Articles.
                OrderByDescending(a => a.Id).
                Include(article => article.Tags).
                Include(article => article.Author).
                Include(article => article.Category).
                Include(article => article.Match).
                Include(article => article.Comments).
                Include(article => article.Content).
                ToList();
            return View(articles);


        }
    }