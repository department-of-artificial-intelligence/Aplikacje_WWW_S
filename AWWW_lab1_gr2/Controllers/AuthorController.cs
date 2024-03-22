using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;


public class AuthorController:Controller{
    public IActionResult Index()
    {
        ViewBag.Title = "Authors";
        return View();
    }
}