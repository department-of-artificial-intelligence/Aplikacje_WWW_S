using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab3_gr1.Controllers;

public class HomeController : Controller
{
  public IActionResult Index()
  {
    ViewBag.Title = "Home";
    return View();
  }
}