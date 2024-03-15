using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

public class ArticleController : Controller
    {

public IActionResult Index(int id = 1)
{
    
    var articles = new List<Article>{
        new Article{
        Id = 1,
        Title = "Artykuł1",
        Content = "Yaddy yadda",
        CreationDate = DateTime.Now,
        Lead = "NA"
        },
        new Article{
        Id = 2,
        Title = "Artykuł2",
        Content = "Fafafafa fafafafafa faaaa",
        CreationDate = DateTime.Now,
        Lead = "NA"
        },
        new Article{
        Id = 3,
        Title = "Artykuł3",
        Content = "Diddly doo",
        CreationDate = DateTime.Now,
        Lead = "NA"
        },
    };

    return View(articles[id-1]);
}

    }