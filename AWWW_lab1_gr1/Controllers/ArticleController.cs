using Microsoft.AspNetCore.Mvc;

using AWWW_lab1_gr1.Models;
namespace AWWW_lab1_gr1.Controllers

{
    public class ArticleController : Controller
    {
        public IActionResult Index(int id = 1)
        {
            ViewBag.Message = "Page with article.";
            var articles = new List<Article>
            {
                new Article
                {
                    Id = 1,
                    Title = "Artykul 1",
                    Content = "Lorem ipsum1...",
                    CreationDate = DateTime.Now,
                },

                new Article
                {
                    Id = 2,
                    Title = "Artykul 2",
                    Content = "Lorem ipsum2...",
                    CreationDate = DateTime.Now,
                },

                new Article
                {
                    Id = 3,
                    Title = "Artykul 3",
                    Content = "Lorem ipsum3...",
                    CreationDate = DateTime.Now,
                },

            };
            var currentArticle = articles[id - 1];
            ViewBag.Title = currentArticle.Title;
            return View(currentArticle);
        }
    }
}