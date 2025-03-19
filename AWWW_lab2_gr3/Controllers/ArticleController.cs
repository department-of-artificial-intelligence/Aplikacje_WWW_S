using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers;
public class ArticleController : Controller{
        public IActionResult Index(int id=1){
        var articles = new List <Article>{
                new Article{
                Id = 1,
                Title = "Artykuł 1",
                Lead = "lead1";
                Content = "Artykuł 1",
                CreationDate = DateTime.Now
                },
                new Article{
                Id = 2,
                Title = "Artykuł 2",
                Lead = "lead1";
                Content = "Artykuł 2",
                CreationDate = DateTime.Now
                },
                new Article{
                Id = 3,
                Title = "Artykuł 3",
                Lead = "lead1";
                Content = "Artykuł 3",
                CreationDate = DateTime.Now
                },
        };
        return View(articles[id-1]);
        }
}