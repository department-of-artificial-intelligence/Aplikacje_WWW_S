using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;


public class CategoryController:Controller{
    public IActionResult Index(){
        ViewBag.Title = "Kategorie";
        return View();
    }
}