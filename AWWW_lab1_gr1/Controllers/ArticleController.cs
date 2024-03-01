using Microsoft.AspNetCore.Mvc;

public class ArticleController : Controller
{

    public IActionResult Index()
    {
        var article = new Article
        {
            Id = 1,
            Title = "artykuł 1",
            Content = "lorem impsu",
            CreationDate = DateTime.Now
        };
        return View(article);
    }
}