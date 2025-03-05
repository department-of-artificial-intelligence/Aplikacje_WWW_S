using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;

public class ArticleController: Controller
{
    public IActionResult Index(){
        ViewBag.Title = "Article";
        return View();
    }
}
