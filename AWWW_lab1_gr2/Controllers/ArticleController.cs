using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

public class ArticleController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Title = "Article";
        return View();
    }

    public IActionResult MyView()
    {
        throw new NotImplementedException();
    }

    public IActionResult Article(int id = 1)
    {
        var articles = new List<Article>
        {
            new Article
            {
                Id=1,
                Title="Artykul 1",
                Content="lorem Ipsum..",
                CreationDate=DateTime.Now
            },
            new Article
            {
                Id=2,
                Title="Artykul 2",
                Content="lorem Ipsum..",
                CreationDate=DateTime.Now
            },
            new Article
            {
                Id=3,
                Title="Artykul 3",
                Content="lorem Ipsum..",
                CreationDate=DateTime.Now
            }
        };

        if (id >= 1 && id <= articles.Count)
        {
            return View(articles[id - 1]);
        }
        else
        {
            return NotFound(); // Видаємо 404 помилку, якщо стаття не знайдена
        }
    }
}
