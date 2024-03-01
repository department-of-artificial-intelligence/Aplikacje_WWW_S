using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

public class ArticleController : Controller{
public IActionResult Index()
{
    var article = new Article
    {
        Id = 1,
        Title = "Article",
        Content = "Lorem ipsum...",
        CreationDate = DateTime.Now
    };
    return View(article);
}
}