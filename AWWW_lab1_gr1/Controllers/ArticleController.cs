using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            var article=new Article
            {
                Id=1,
                Title="Artykuł 1",
                Content="Lorem ipsum...",
                CreationDate=DateTime.Now
            };
            return View(article);
        }
    }
}