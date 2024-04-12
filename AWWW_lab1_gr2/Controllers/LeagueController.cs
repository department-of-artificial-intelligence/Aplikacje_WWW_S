using Microsoft.AspNetCore.Mvc;

using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

public class LeagueController: Controller {
    private readonly DatabaseContext _context; 
    private readonly ILogger _logger; 
    public LeagueController(DatabaseContext context, ILogger logger){
        _context = context; 
        _logger = logger; 
    }

    public IActionResult Index() {
        ViewBag.Title = "Ligi"; 
        var leagues = _context.Leagues.Include(l => l.Teams);
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

    [HttpPost]
    public IActionResult Delete(int id){
        try {
            var league = _context.Leagues.Find(id); 
            if(league == null) throw new Exception("Nie znaleziono ligi");
            _context.Leagues.Remove(league); 
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); 
        } catch (Exception ex) {
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

}