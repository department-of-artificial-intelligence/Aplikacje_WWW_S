using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;
public class ArticleController : Controller
{
    public IActionResult Index()
    {
        var article = new Article
        {
            Id = 1,
            Title = "Artykuł 1",
            Content = "Lorem impsum...",
            CreationDate = DateTime.now
        };
        return View(article);
    }
}