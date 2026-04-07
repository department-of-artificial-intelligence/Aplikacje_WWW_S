using Microsoft.AspNetCore.Mvc;
using w2_p1.Models;

namespace w2_p1.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index(int id)
        {
            var article = Repository.Articles.ToList()[id];
            return View(article);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Article article)
        {
            Repository.AddArticle(article);
            return View("Added", article);
        }
    }
}
