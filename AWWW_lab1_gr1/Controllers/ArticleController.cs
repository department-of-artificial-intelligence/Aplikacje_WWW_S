using AWWW_lab1_gr1.Models;
using AWWW_lab1_gr1.Data;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr1.Controllers
{
    public class ArticleController : Controller
    {
        private readonly MyDBContext _dbContext;

        public ArticleController(MyDBContext dbContext) { _dbContext = dbContext; }

        public IActionResult Index()
        {
            List<Article> articles = _dbContext.Articles!.ToList();
            return View(articles);
        }

    }
}
