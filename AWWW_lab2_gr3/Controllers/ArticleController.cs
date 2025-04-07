using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index(int id = 1)
        {
            var articles = new List<Article>
            {
                new Article
                {
                    Id = 1,
                    Title = "Pierwszy artykuł",
                    Lead = "To jest lead pierwszego artykułu",
                    Content = "Zawartość pierwszego artykułu...",
                    CreationDate = DateTime.Now,
                    AuthorId = 1,
                    category = new Category { Id = 1, Name = "Sport" },
                    CategoryId = 1
                },
                new Article
                {
                    Id = 2,
                    Title = "Drugi artykuł",
                    Lead = "To jest lead drugiego artykułu",
                    Content = "Zawartość drugiego artykułu...",
                    CreationDate = DateTime.Now,
                    AuthorId = 2,
                    category = new Category { Id = 2, Name = "Technologia" },
                    CategoryId = 2
                },
                new Article
                {
                    Id = 3,
                    Title = "Trzeci artykuł",
                    Lead = "To jest lead trzeciego artykułu",
                    Content = "Zawartość trzeciego artykułu...",
                    CreationDate = DateTime.Now,
                    AuthorId = 3,
                    category = new Category { Id = 3, Name = "Nauka" },
                    CategoryId = 3
                }
            };
            return View(articles[id - 1]);
        }
    }
    
   
}
