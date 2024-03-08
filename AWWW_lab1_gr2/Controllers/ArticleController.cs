using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

public class ArticleController:Controller{
    public IActionResult Index(int itemid){

        var articles = new List<Article>{
            new Article{
                Id = 1,
                Title = "Artykuł 1",
                Content = "Lorem ispdum...",
                CreationDate = DateTime.Now
            },

            new Article{
                Id = 2,
                Title = "Artykuł 2",
                Content = "Lorem ispum...",
                CreationDate = DateTime.Now
            },

            new Article{
                Id = 3,
                Title = "Artykuł 3",
                Content = "Lorem ispum...",
                CreationDate = DateTime.Now
            }
        };
        return View(articles[itemid-1]);
    }
}