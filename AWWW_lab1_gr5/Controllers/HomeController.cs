public class HomeController
{
    public IActionResult Index()
    {
        ViewBag.Title = "Home";
        return View();
    }
}