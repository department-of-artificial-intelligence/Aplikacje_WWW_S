using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr5.Models;

namespace AWWW_lab1_gr5.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index(int id=1)
        {
            var articles = new List<Article>{
                new Article{
                    Id = 1,
                    Title = "Artykuł 1",
                    Content = "Lorem Ipsum...",
                    CreationDate = DateTime.Now
                },
                new Article{
                    Id = 2,
                    Title = "Artykuł 2",
                    Content = "Lorem Ipsum...",
                    CreationDate = DateTime.Now
                },
                new Article{
                    Id = 3,
                    Title = "Artykuł 3",
                    Content = "Lorem Ipsum...",
                    CreationDate = DateTime.Now
                }
            };
            
            return View(articles[id-1]);
        }
    }
}
