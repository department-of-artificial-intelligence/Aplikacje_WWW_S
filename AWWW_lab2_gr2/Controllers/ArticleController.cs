using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr2.Models;

public class ArticleController : Controller{
    public IActionResult Index(){
        

        return View();
    }
}