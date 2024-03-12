using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

public class StudentController : Controller{
public IActionResult Index(int id = 1)
{
    var student = new List<Students>
    {
        new Article{
            Id = 1,
            Title = "Artykul 1",
            Content = "Lorem ipsum...",
            CreationDate = DateTime.Now
        },
        new Article{
            Id = 2,
            Title = "Artykul 2",
            Content = "Lorem ipsum...",
            CreationDate = DateTime.Now
        },
        new Article{
            Id = 3,
            Title = "Artykul 3",
            Content = "Lorem ipsum...",
            CreationDate = DateTime.Now
        }
    };
    return View(articles[id-1]);
    
}
}