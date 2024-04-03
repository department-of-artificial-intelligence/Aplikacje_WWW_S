using AS_l2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AS_l2.Controllers
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
            var article = _dbContext.Articles.FirstOrDefault(a => a.Id == id); //Repository.Articles.ToList()[id];
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
            article.CreationDate = DateTime.Now;
            _dbContext.Articles.Add(article); //Repository.AddArticle(article);
            _dbContext.SaveChanges();
            return View("Added",article); 
        }
    }
}
