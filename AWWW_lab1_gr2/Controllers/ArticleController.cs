using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Components.Web;

public class ArticleController : Controller 
{
    public IActionResult Index() 
    {
        var article = new Article 
        {
            Id = 1,
            Title = "Artykul 1",
            Content = "Lorem ipsum...",
            CreationDate = DateTime.Now
        };

        return View(article);
    }

    public IActionResult MyView() {
        throw new NotImplementedException();
    }
}