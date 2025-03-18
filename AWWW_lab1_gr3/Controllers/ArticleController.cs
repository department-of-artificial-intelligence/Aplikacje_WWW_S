using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;
using Microsoft.AspNetCore.Components.Web;

public class ArticleController : Controller
{
    
    public IActionResult Index(int id = 1)
    {
        
        var articles = new List<Article>
        {
        new Article{
            Id = 1,
            Title = "Made in Abyss",
            Content = "nothing",
            CreationDate = DateTime.Now
            
        },
         new Article{
            Id = 2,
            Title = "Solo leveling",
            Content = "Arise",
            CreationDate = DateTime.Now
        },
        new Article{
            Id = 3,
            Title = "Tokyo Ghoul",
            Content = "umarlo sie",
            CreationDate = DateTime.Now
        }
        };
        
        return View(articles[id - 1]);
    }
}