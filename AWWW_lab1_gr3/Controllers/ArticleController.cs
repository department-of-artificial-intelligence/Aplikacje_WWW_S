using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;
public class ArticleController : Controller
{
        public IActionResult Index(int id = 1)
        {

                var articles = new List<Articles>{

        new Articles{
            Id = 1,
            Title = "Artykul 1",
            Content = "Tresc artykulu 1",
            CreationDate = DateTime.Now
        },

        new Articles{
            Id = 2,
            Title = "Artykul 2",
            Content = "Tresc artykulu 2",
            CreationDate = DateTime.Now
        },

        new Articles{
            Id = 3,
            Title = "Artykul 3",
            Content = "Tresc artykulu 3",
            CreationDate = DateTime.Now
        }
        };
                return View(articles[id - 1]);
        }
}