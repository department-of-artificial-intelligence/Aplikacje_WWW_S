using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;

public class ArticleController : Controller
{
    public IActionResult Index(int id = 1)
    {
        var articles = new List<Article>
        {
        new Article{
            Id = 1,
            Title = "Naruto",
            Content = "O przyszlym HOKAGE",
            CreationDate = DateTime.Now
        },
         new Article{
            Id = 1,
            Title = "No game No life",
            Content = "No coment",
            CreationDate = DateTime.Now
        },
        new Article{
            Id = 1,
            Title = "Zielarka",
            Content = "O przyszlej Empress",
            CreationDate = DateTime.Now
        }
        };

        return View(articles[id - 1]);
    }
}