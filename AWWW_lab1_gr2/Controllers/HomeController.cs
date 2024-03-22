using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

public class HomeController: Controller
{
    private readonly DatabaseContext _context;
    public HomeController(DatabaseContext context){
        _context = context; 
    }

    public IActionResult Index() {
        ViewBag.Title = "Home"; 
        var authors = _context.Authors; 
        return View(authors); 
    }

    public IActionResult Database() {
        ViewBag.Title = "Baza"; 
        return View(); 
    }
}