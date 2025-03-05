using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using AWWW_lab1_gr2.Models;
using System;
using System.Globalization;

public class ArticleController : Controller
    {


        public IActionResult Index(int id=1)
        {
            var articles = new List<Articles>{
            
            new Articles
            {
                Id = 1,
                Title = "Artykuł 1",
                Content = "lorem ipsum...",
                CreationDate = DateTime.Now
            };
            new Articles
            {
                Id = 2,
                Title = "Artykuł 2",
                Content = "lorem ipsum...",
                CreationDate = DateTime.Now
            };
            new Articles
            {
                Id = 3,
                Title = "Artykuł 3",
                Content = "lorem ipsum...",
                CreationDate = DateTime.Now
            };
            }
            return View(articles[id-1]);
        }
    }
