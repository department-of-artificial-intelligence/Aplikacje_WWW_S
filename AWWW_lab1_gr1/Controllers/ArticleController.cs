using AWWW_lab1_gr1.Models;
using AWWW_lab1_gr1.Data;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr1.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index(int id = 1)
        {
            var articles = new List<Article>
            {
                new Article
                {
                    Id = 1,
                    Title = "Artyku³ 1",
                    Content = "Lorem ipsum...",
                    CreationDate = DateTime.Now
                },
                new Article
                {
                    Id = 2,
                    Title = "Artyku³ 2",
                    Content = "Dolor sit amet...",
                    CreationDate = DateTime.Now
                },
                new Article
                {
                    Id = 3,
                    Title = "Artyku³ 3",
                    Content = "Consectetur adipiscing elit...",
                    CreationDate = DateTime.Now
                }
            };

            return View(articles[id - 1]);
        }

        /*
        private readonly MyDBContext _dbContext;

        public ArticleController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int id)
        {
            Article? article = _dbContext.Articles!.FirstOrDefault(a => a.Id == id); 
            return View(article);
        }

        public IActionResult Add(Article article) 
        {
            article.CreationDate = DateTime.Now;
            _dbContext.Articles!.Add(article);
            _dbContext.SaveChanges();
            return View();
        }
        */
    }
}
