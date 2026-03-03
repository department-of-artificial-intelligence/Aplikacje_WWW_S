using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;
namespace AWWW_lab1_gr1.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var article = new Article
        {
            Id = 1,
            Title = "Artykuł 1",
            Content = "Lorem ipsum...",
            CreationDate = DateTime.Now
        };
        ViewBag.Title = "Home";
        return View(article);
    }
}