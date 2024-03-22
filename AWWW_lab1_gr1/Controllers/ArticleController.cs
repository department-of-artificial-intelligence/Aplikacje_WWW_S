
using Microsoft.AspNetCore.Mvc;
namespace MvcApp.Controllers
{
    public class ArticleController : Controller{
        public IActionResult Index()
        {    
            return View();
        }
    }
}