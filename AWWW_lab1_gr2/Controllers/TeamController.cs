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

        return View(); 
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Add(Team team) {


        if (team.LeagueId <= 0){
                // ViewBag.Success = false;
                return View("Form", team);
        }

        if(_context.Leagues != null){
            var league = _context.Leagues.FirstOrDefault(l => l.LeagueId == team.LeagueId);

            if (league is null)
            {
                ViewBag.Success = false;
                ViewBag.Title = "nie ma ligi o takim id"; 
                return View("Form", team); 
            }

            team.League = league; 
            ViewBag.Title = team.League.Name; 
            return View("Form", team); 
        }

        ModelState.ClearValidationState(nameof(team)); 
        if(TryValidateModel(team, nameof(team))){

            _context.Teams.Add(team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        ViewBag.Success = false; 
        ViewBag.Leagues = new SelectList(_context.Leagues.ToList(), "LeagueId", "Name", team.LeagueId);

        return View("Form", team);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Delete(Team team) {



        _context.Teams.Remove(team); 
        _context.SaveChanges(); 
        // return RedirectToAction("Index"); 
        return View("Index"); 
    }

}