
using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

public class ArticleController : Controller{

    public IActionResult Index(){
        ViewBag.Title = "Article";
        return View();

    }

    public IActionResult MyView(){
        throw new NotImplementedException();
    }

}