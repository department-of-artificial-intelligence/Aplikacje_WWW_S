using Microsoft.AspNetCore.Mvc;
using AWWW_lab3_gr1.Models;

namespace AWWW_lab3_gr1.Controllers
{
    public class ArticleController : Controller
    {
        // GET: /Article
        public IActionResult Index(int id=1)
        {
            var articles = new List<Article>
            {
                new Article
                {
                    Id = 1,
                    Title = "Artykuł 1",
                    Content = "Rośliny",
                    CreationDate = DateTime.Now
                },
                new Article
                {
                    Id = 2,
                    Title = "Artykuł 2",
                    Content = " Zwierzęta",
                    CreationDate = DateTime.Now
                },
                new Article
                {
                    Id = 3,
                    Title = "Artykuł 3",
                    Content = "Ludzie",
                    CreationDate = DateTime.Now
                }
            };

            return View(articles[id-1]); // będzie szukać Views/Article/Index.cshtml
        }
    }
}