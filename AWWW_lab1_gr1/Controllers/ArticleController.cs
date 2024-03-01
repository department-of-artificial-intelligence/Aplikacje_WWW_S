using Microsoft.AspNetCore.Mvc;

public class ArticleController:Controller
{
    public IActionResult Article()
    {
        ViewBag.Title = "Article";
        return View();
    }
}