using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers

{
     public class AuthorController : Controller
    {
        public IActionResult Index(int id = 1)
        {
            var Authors = new List<Author>
            {
                new Author { Id = 1, FirstName = "Jan", LastName = "Kowalski", Articles = new List<Article>() },
                new Author { Id = 2, FirstName = "Anna", LastName = "Nowak", Articles = new List<Article>() },
                new Author { Id = 3, FirstName = "Piotr", LastName = "Wiśniewski", Articles = new List<Article>() }
            };
            return View(Authors[id - 1]);
        }
    }
}