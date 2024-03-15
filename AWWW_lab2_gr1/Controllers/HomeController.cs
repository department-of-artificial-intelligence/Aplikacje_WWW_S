using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

public class HomeController : Controller{
    public IActionResult Index()
    {
        ViewBag.Title = "Home";
        return View();
    }
}

