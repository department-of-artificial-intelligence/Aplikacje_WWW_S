using Microsoft.AspNetCore.Mvc;

public class ArticleController : Controller{
    public IActionResult Article()
    {
        return View();
    }
}