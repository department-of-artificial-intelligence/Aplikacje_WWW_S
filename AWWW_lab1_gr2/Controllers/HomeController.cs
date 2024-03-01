

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller{

    public IActionResult Index(){
        ViewBag.Title = "Home";
        return View();

    }

    public IActionResult MyView(){
        throw new NotImplementedException();
    }

}
