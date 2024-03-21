using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

public class AuthorsController:Controller{
    public IActionResult Index(){
        ViewBag.Title = "Autorzy";
        return View();
    }
}