using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;
public class ArticleController : Controller
{
    public IActionResult Index(int id)
    {
        var articles = new List<Article>{
            
            new Article
            {
                Id = 1,
                Title = "Artykuł 1",
                Content = "Text artykułu pierwszego...",
                CreationDate = DateTime.Now
            },
            new Article
            {
                Id = 2,
                Title = "Artykuł 2",
                Content = "Text artykułu drugiego...",
                CreationDate = DateTime.Now
            },
            new Article
            {
                Id = 3,
                Title = "Artykuł 3",
                Content = "Text artykułu trzeciego...",
                CreationDate = DateTime.Now
            }
        };

        return View(articles[id-1]);
    }

}