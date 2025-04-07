using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers {
    public class ArticleController : Controller {

        private readonly MyDbContext _dbContext;

        public ArticleController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(int id=1) {
            var articles = new List<Article>
            {
                new Article {
                    Id = 1,
                    Title = "Artykuł 1",
                    Content = "Lorem ipsum...",
                    CreationDate = DateTime.Now
                },
                new Article {
                    Id = 2,
                    Title = "Artykuł 2",
                    Content = "Lorem ipsum...",
                    CreationDate = DateTime.Now
                },
                new Article {
                    Id = 3,
                    Title = "Artykuł 3",
                    Content = "Lorem ipsum...",
                    CreationDate = DateTime.Now
                }
            };
            //ViewBag.Title = "Article";
            return View(articles[id-1]);
        }
    }
}
