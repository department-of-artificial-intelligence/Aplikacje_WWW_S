using Microsoft.AspNetCore.Mvc;

using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        ViewBag.Leagues = _context.Leagues
                            .Select(l => new SelectListItem() {
                                Value = l.LeagueId.ToString(), 
                                Text = l.Name
                            })
                            .ToList(); 

        ViewBag.League1 = _context.Leagues.FirstOrDefault(); 
        return View(); 
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Add(Team team) {
        if(ModelState.IsValid){

            // if (team.League?.LeagueId == null)
            // {
            //     ViewBag.Success = false;
            //     return View(team);
            // }

            // if(_context.Leagues != null){
            //     var league = _context.Leagues.FirstOrDefault();

            //     // if (league is null)
            //     // {
            //     //     ViewBag.Success = false;
            //     //     return View(team); 
            //     // }

            //     team.League = league; 
            // }

            _context.Teams.Add(team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.Leagues = new SelectList(_context.Leagues.ToList(), "LeagueId", "Name", team.LeagueId);
        return View("Form", team);
    }

}