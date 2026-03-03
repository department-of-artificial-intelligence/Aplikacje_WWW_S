using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers;

public class ArticleController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Title = "Article";
        return View();
    }
}