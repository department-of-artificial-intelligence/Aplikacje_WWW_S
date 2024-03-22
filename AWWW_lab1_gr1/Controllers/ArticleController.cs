using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr1.Controllers
{
    public class ArticleController : Controller
    {
        private readonly MyDbContext _dbContext;

        public ArticleController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int id)
        {
            var article = _dbContext.Articles.FirstOrDefault(a => a.Id == id); 
            if (article != null)
                return View(article);
            return View("Error");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Article article)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Articles.Add(article);
                _dbContext.SaveChanges();
                return View("Added", article);
            }
            return View("Error");
        }
    }
}
