using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;

public class HomeController:Controller{
    
    public IActionResult Index(){
        ViewBag.Title = "Home";

        var article = new Article{
            Id=1,
            Title = "Arykul 1",
            Content = "Lorem ipsum....",
            CreationDate = DateTime.Now
        };
        
        return View(article);
    }
}


