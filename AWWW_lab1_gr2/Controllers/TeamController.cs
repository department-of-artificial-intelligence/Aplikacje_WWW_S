using Microsoft.AspNetCore.Mvc;

using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

public class TeamController: Controller {
    private readonly DatabaseContext _context; 
    private readonly ILogger _logger; 
    public TeamController(DatabaseContext context, ILogger logger){
        _context = context; 
        _logger = logger; 
    }

    public IActionResult Index() {
        ViewBag.Title = "Druzyny"; 
        var teams = _context.Teams;
        return View(teams); 
    }

    public IActionResult Form() {
        ViewBag.Title = "Dodawanie druzyny"; 

        try {
            ViewBag.Leagues = _context.Leagues
                                .Select(l => new SelectListItem() {
                                    Value = l.LeagueId.ToString(),
                                    Text = l.Name
                                })
                                .ToList(); 
            return View(); 
        } catch (Exception e) {
            _logger.LogError(e, e.Message); 
            throw; 
        }


    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Add(Team team) {


        try {
            ModelState.ClearValidationState(nameof(team)); 
            if(!TryValidateModel(team, nameof(team))){
                return View("Form", team); 
            }
            team.League  = _context.Leagues.FirstOrDefault(l => l.LeagueId == team.LeagueId);
            _context.Teams.Add(team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } catch (Exception e){
            _logger.LogError(e, e.Message); 
            throw; 
        }

    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Delete(int id) {

        try {
            var t = _context.Teams.FirstOrDefault(team => team.TeamId == id); 
            if(t != null){
                _context.Teams.Remove(t); 
                _context.SaveChanges(); 
            }
            return RedirectToAction("Index"); 
        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    [HttpGet]
    public IActionResult Edit(int id){

        try{
            var teamToEdit = _context.Teams.FirstOrDefault(t => t.TeamId == id); 
            if(teamToEdit == null){
                return NotFound(); 
            }

            ViewBag.Title = "Edycja druzyny"; 
            ViewBag.Leagues = _context.Leagues.Select(l => new SelectListItem(l.Name, l.LeagueId.ToString()));

            return View(teamToEdit); 
        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Edit(Team team){
        try {
            if(!ModelState.IsValid){
                ViewBag.Leagues = _context.Leagues.Select(l => new SelectListItem(l.Name, l.LeagueId.ToString())); 
                return View(team); 
            }

            var existingTeam = _context.Teams.FirstOrDefault(t => t.TeamId == team.TeamId); 
            if(existingTeam == null){
                return NotFound(); 
            }

            existingTeam.Name = team.Name; 
            existingTeam.Country = team.Country; 
            existingTeam.LeagueId = team.LeagueId; 

            _context.SaveChanges(); 

            return RedirectToAction("Index"); 

        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

}