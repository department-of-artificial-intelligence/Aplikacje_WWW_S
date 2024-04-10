using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.ViewModels; 
using SQLitePCL;

public class HomeController: Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DatabaseContext _context;
    public HomeController(DatabaseContext context, ILogger<HomeController> logger){
        _context = context; 
        _logger = logger; 
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier}); 
    }
}