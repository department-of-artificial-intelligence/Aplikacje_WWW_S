using Microsoft.AspNetCore.Mvc;

public class LigaController : Controller{
    public IActionResult Index()
    {
        return View();
    }
}