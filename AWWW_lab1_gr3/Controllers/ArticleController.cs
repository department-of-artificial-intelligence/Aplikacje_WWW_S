using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;

namespace AWWW_lab1_gr3.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index(){
            var article = new Article
            {
                Id = 1,
                Title = "Artykul 1",
                Content = "Lorem ipsum...",
                CreationDate =  DateTime.Now 
            };
            return View(article);
        }
    }
}