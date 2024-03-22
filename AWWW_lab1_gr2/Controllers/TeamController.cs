using Microsoft.AspNetCore.Mvc;

using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Components.Web;

public class TeamController: Controller {
    private readonly DatabaseContext _context; 
    public TeamController(DatabaseContext context){
        _context = context; 
    }

    public IActionResult Index() {
        ViewBag.Title = "Druzyny"; 
        var teams = _context.Teams;
        return View(teams); 
    }

    public IActionResult Form() {
        ViewBag.Title = "Dodawanie druzyny"; 
        var leagueList = _context.Leagues; 
        return View(); 
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Add(Team team) {
        if(ModelState.IsValid){

            _context.Teams.Add(team); 
            _context.SaveChanges(); 
            return RedirectToAction("Index"); 
        }
        return RedirectToAction("Index");  
    }

}