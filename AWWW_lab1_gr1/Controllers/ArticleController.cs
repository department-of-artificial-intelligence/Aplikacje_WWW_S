using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
namespace AWWW_lab1_gr1.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Article";
            return View();
        }
    }
}
