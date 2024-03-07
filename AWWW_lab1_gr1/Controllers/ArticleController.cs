using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
namespace MvcApp.Controllers
{
    public class ArticleController : Controller{
        public IActionResult Index(int id)
        {
            var articles = new List<Article>
            {
                new Article{
                Id = 1,
                Title = "Artykuł 1",
                Content = "Lorem ipsum...",
                CreationDate = DateTime.Now
                },
                new Article{
                Id = 2,
                Title = "Artykuł 2",
                Content = "Lorem ipsum2...",
                CreationDate = DateTime.Now
                },
                new Article{
                Id = 3,
                Title = "Artykuł 3",
                Content = "Lorem ipsum3...",
                CreationDate = DateTime.Now
                }
            };

            return View(articles[id-1]);
        }
    }

}