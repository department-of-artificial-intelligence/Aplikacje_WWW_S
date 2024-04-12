

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
    public IActionResult Add(Player player, List<int> selectedPositionIds) {
        try {
            if(!ModelState.IsValid){
                return View(); 
            }
            player.Team = _context.Teams.FirstOrDefault(t => t.TeamId == player.TeamId);
            player.Positions = _context.Positions.Where(p => selectedPositionIds.Contains(p.PositionId)).ToList(); 
            _context.Players.Add(player); 
            _context.SaveChanges(); 
            return RedirectToAction("Index"); 
        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw;
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id) {
        try {
            var player = _context.Players.FirstOrDefault(p => p.PlayerId == id);
            if(player == null) return RedirectToAction("Index"); 
            _context.Players.Remove(player); 
            _context.SaveChanges(); 
            return RedirectToAction(nameof(Index)); 
        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw; 
        }
    }

    [HttpGet]
    public IActionResult Edit(int id) {
        ViewBag.Title = "Edycja zawodnika"; 

        try {
            ViewBag.Positions = _context.Positions.Select(p => new SelectListItem(p.Name, p.PositionId.ToString()));  
            ViewBag.Teams = _context.Teams; 
            var playerToEdit = _context.Players.Include(p => p.Team).Include(p => p.Positions).FirstOrDefault(p => p.PlayerId == id); 
            return View(playerToEdit);
        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw; 
        } 
    } 

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Player player, int selectedTeamId, List<int> selectedPositionsIds){ 

        try{
            if(!ModelState.IsValid){
                return NotFound(); 
            }
            var editedPlayer = _context.Players.Include(p => p.Team).Include(p => p.Positions).FirstOrDefault(p => p.PlayerId == player.PlayerId);  
            if(editedPlayer == null){
                return NotFound(); 
            }
            editedPlayer.FirstName = player.FirstName; 
            editedPlayer.LastName = player.LastName;
            editedPlayer.Country = player.Country;
            editedPlayer.BirthDate = player.BirthDate;
            editedPlayer.TeamId = player.TeamId; 
            
            // team 
            editedPlayer.Team = _context.Teams.FirstOrDefault(t => t.TeamId == editedPlayer.TeamId); 
            // positions
            editedPlayer.Positions = _context.Positions.Where(p => selectedPositionsIds.Contains(p.PositionId)).ToList();

            _context.SaveChanges(); 

            return RedirectToAction("Index");  

        } catch (Exception ex){
            _logger.LogError(ex, ex.Message); 
            throw; 
        }

    }

    

}