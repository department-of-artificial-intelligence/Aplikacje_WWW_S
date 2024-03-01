using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;

public class HomeController:Controller{
    public IActionResult Index(){
        ViewBag.Title="Home";
        return View();
    }
}