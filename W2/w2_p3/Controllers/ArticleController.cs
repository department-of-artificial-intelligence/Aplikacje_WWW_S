using Microsoft.AspNetCore.Mvc;
using w2_p3.Models;

namespace w2_p3.Controllers
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
            return NotFound();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Article article)
        {
            article.CreationDate = DateTime.Now;
            _dbContext.Articles.Add(article); 
            _dbContext.SaveChanges();
            return View("Added", article);
        }
    }
}
