using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;

public class ArticleController:Controller{
    public IActionResult Index(){
        ViewBag.Title="Strona";
        return View();
    }
}