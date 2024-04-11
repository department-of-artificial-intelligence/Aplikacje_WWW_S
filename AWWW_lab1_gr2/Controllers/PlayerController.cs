

using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class PlayerController: Controller {
    private readonly DatabaseContext _context; 
    private readonly ILogger _logger; 

    public PlayerController(DatabaseContext context, ILogger logger) {
        _context = context; 
        _logger = logger; 
    }

    public IActionResult Index() {
        ViewBag.Title = "Zawodnicy"; 
        try {
            var players = _context.Players.Include( p => p.Team ).Include(p => p.Positions); 
            return View(players); 
        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    [HttpGet]
    public IActionResult Add() {
        ViewBag.Title = "Dodawanie zawodnika"; 

        try {
            ViewBag.Positions = _context.Positions.Select( x => new SelectListItem(x.Name, x.PositionId.ToString())); 
            ViewBag.Teams = _context.Teams.Select(t => new SelectListItem(t.Name, t.TeamId.ToString())); 
            return View(); 
        } catch (Exception ex) {
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(Player player, int selectedTeamId, List<int> selectedPositionIds) {
        try {
            if(!ModelState.IsValid){
                return View(); 
            }
            player.Team = _context.Teams.FirstOrDefault(t => t.TeamId == selectedTeamId);
            player.Positions = _context.Positions.Where(p => selectedPositionIds.Contains(p.PositionId)).ToList(); 
            _context.Players.Add(player); 
            _context.SaveChanges(); 
            return RedirectToAction("Index"); 
        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw;
        }
    }

}