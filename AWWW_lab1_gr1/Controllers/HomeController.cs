using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 public class HomeController:Controller{

    public IActionResult Index()
    {
        ViewBag.Title = "Home";
        return View();
    }
}