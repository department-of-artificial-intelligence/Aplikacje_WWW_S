using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;
using System.Collections.Generic;


public class ArticleController : Controller
{
    
    public IActionResult Index(int id=1)
    {
        var articles = new List<Article>
        {
            new Article
            {
                Id = 1,
                Title = "Article title",
                Content = "Article content",
                CreationDate = DateTime.Now
            },
            new Article
            {
                Id = 2,
                Title = "Article title 2",
                Content = "Article content 2",
                CreationDate = DateTime.Now
            },
            new Article
            {
                Id = 3,
                Title = "Article title 3",
                Content = "Article content 3",
                CreationDate = DateTime.Now
            }
        };
        return View(articles[id-1]);
       
    }
}