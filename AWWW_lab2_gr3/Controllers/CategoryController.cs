using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index(int id = 1)
        {
            var Categories = new List<Category>
            {
               new Category {Id = 1, Name = "Sport", Articles = new List<Article>() },
               new Category {Id = 2, Name = "Technologia", Articles = new List<Article>() },
               new Category {Id = 3, Name = "Nauka", Articles = new List<Article>() },
            };
            return View(Categories[id - 1]);
        }
    }
    
   
}
