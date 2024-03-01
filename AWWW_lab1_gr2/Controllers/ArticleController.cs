using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

public class ArticleController:Controller{
    public IActionResult Index(int id = 1){

        var articles = new List<Article>{
                new Article{
                Id = 1,
                Title = "Artykuł 1",
                Content = "Lorem ispum...",
                CreationDate = DateTime.Now
            },
            new Article{
            
            Id = 1,
            Title = "Artykuł 1",
            Content = "Lorem ispum...",
                CreationDate = DateTime.Now
            },
            new Article{
            
                Id = 1,
                Title = "Artykuł 1",
                Content = "Lorem ispum...",
                CreationDate = DateTime.Now
            }
        };
        return View(articles[id-1]);
    }
}