using Microsoft.AspNetCore.Mvc;

using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Components.Web;

public class LeagueController: Controller {
    private readonly DatabaseContext _context; 
    public LeagueController(DatabaseContext context){
        _context = context; 
    }

    public IActionResult Index() {
        ViewBag.Title = "Ligi"; 
        var leagues = _context.Leagues;
        return View(leagues); 
    }

    public IActionResult Form() {
        ViewBag.Title = "Dodawanie ligi"; 
        return View(); 
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Add(League league) {
        if(ModelState.IsValid){

            _context.Leagues.Add(league); 
            _context.SaveChanges(); 
            return RedirectToAction("Index"); 
        }
        return RedirectToAction("Index");    
    }

}