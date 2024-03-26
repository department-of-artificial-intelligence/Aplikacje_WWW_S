using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AWWW_lab1_gr5.Models;

namespace AWWW_lab1_gr5.Controllers
{
    [Route("[controller]")]
    public class ArticleController : Controller
    {
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(ILogger<ArticleController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id=1)
        {
            var articles = new List<Article>
            {
            new Article 
            {
                Id = 1,
                Title = "Artykuł 1",
                Content = "LOrem ipsum ",
                CreationDate = DateTime.Now
            },
             new Article 
            {
                Id = 2,
                Title = "Artykuł 2",
                Content = "LOrem ipsum ",
                CreationDate = DateTime.Now
            },
             new Article 
            {
                Id = 3,
                Title = "Artykuł 3",
                Content = "LOrem ipsum ",
                CreationDate = DateTime.Now
            },
            };
            return View(articles[id-1]);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
        
    