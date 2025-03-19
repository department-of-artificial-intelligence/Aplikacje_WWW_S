using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index(int id=1){
            var articles = new List<Articles>
            {
                new Articles{
                    Id = 1,
                    Title = "Artykul 1",
                    Content = "bfsablgvarh gfdhg...",
                    CreationDate = DateTime.Now
                },
                new Articles{
                    Id = 2,
                    Title = "Artykul 2",
                    Content = "bfsablgvarh gfdhg...",
                    CreationDate = DateTime.Now
                },
                new Articles{
                    Id = 3,
                    Title = "Artykul 3",
                    Content = "bfsablgvarh gfdhg...",
                    CreationDate = DateTime.Now
                }
            };
            return View(articles[id - 1]);
        }
    }
}