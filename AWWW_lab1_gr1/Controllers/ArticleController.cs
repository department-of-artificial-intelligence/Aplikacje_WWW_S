using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

public class ArticleController:Controller
{
    public IActionResult Index(int id=1)
    {
       var articles = new List<Article> 
        { 
            new Article{ 
            ID = 1, 
            Title = "Artykul 1", 
            Content = "Lorem ipsum...", 
            CreationDate = DateTime.Now 
            
            }, 
            new Article{ 
            ID = 2, 
            Title = "Artykul 2", 
            Content = "Lorem ipsum...", 
            CreationDate = DateTime.Now 
            }, 
            new Article{ 
            ID = 3, 
            Title = "Artykul 3", 
            Content = "Lorem ipsum...", 
            CreationDate = DateTime.Now 
            } 
         
   
        };

        return View(articles[id-1]);
    }
}