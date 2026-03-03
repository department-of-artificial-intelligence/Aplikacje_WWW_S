using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

namespace AWWW_lab1_gr1.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            var article = new Article
            {
                Id = 1;
                Title = "Artykuł 1";
                Content = "Przykładowy tekst";
                CreationDate = DateTime.Now
            };
        }
    }
}

