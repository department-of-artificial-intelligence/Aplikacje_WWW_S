using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index(int id=1)
        {
            var article = new List<Article>
            {
            new Article{
                Id = 1,
                Title = "Artykuł 1",
                Content = "Przykładowy tekst",
                CreationDate = DateTime.Now
            }, 
            new Article{
                Id = 1,
                Title = "Artykuł 1",
                Content = "Przykładowy tekst",
                CreationDate = DateTime.Now
            }, 
            new Article{
                Id = 1,
                Title = "Artykuł 1",
                Content = "Przykładowy tekst",
                CreationDate = DateTime.Now
            }
        };
            return View(article);
    }
    }
}

