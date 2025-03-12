using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AWWW_lab1_gr3.Models;

namespace AWWW_lab1_gr3.Controllers
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
                Content = "Lorem ipsum...",
                CreationDate=DateTime.Now
                },
                new Article{
                Id = 2,
                Title = "Artykuł 2",
                Content = "Lorem ipsum...",
                CreationDate=DateTime.Now
                },
                new Article{
                Id = 3,
                Title = "Artykuł 3",
                Content = "Lorem ipsum...",
                CreationDate=DateTime.Now
                }
            };

        return View(article[id-1]);
    }
    }
}
