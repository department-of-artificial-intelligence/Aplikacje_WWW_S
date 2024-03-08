using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components.Web;
using AWWW_lab1_gr2.Models;

public class ArticleController : Controller 
{
    public IActionResult Index(int id=1) 
    {
        var articles = new List<Article>
        {
            new Article {
                Id = 1,
                Title = "Artykul 1",
                Content = "Lorem ipsumm...",
                CreationDate = DateTime.Now
            },
            new Article {
                Id = 2,
                Title = "Artykul 2",
                Content = "Lorem ipsummm",
                CreationDate = DateTime.Now
            },
            new Article {
                Id = 3,
                Title = "Artykul 3",
                Content = "Lorem ipsummmm",
                CreationDate = DateTime.Now
            }
        };

        return View(articles[id-1]);
    }

    public IActionResult MyView() {
        throw new NotImplementedException();
    }
}