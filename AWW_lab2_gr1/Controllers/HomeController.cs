using Microsoft.AspNetCore.Mvc;

namespace AWW_lab2_gr1.Controllers;

public class HomeController : Controller
{
  public IActionResult Index()
  {
    ViewBag.Title = "Home";
    return View();
  }
}