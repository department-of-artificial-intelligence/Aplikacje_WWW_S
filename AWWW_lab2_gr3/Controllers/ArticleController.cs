using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;
public class ArticleController : Controller
{
    public IActionResult Index(int id)
    {
        var articles = new List<Article>{};

        return View(articles[id-1]);
    }

}