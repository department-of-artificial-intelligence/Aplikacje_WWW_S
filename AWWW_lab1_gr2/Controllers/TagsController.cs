using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

public class TagsController:Controller{
    public IActionResult Index(){
        ViewBag.Title = "Tagi";
        return View();
    }
}