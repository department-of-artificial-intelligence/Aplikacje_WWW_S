using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;
public class ArticleController : Controller
{
    public IActionResult Index()
    {
        
        var article = new ArticleController{
            Id = 1.
            Title = "Artykul 1",
            Content = "Tresc artykulu 1",
            CreationDate = DateTime.Now
        }
        return Vire(article);
    }
}