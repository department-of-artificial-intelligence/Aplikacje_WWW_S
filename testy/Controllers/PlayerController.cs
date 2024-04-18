using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kolokwium.Models;

public class PlayerController : Controller
{
    private readonly MyDbContext _context;
    public PlayerController(MyDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var players = _context.Player.Include(a => a.Team).Include(a => a.Positions).ToList();
        return View(players);
    }
    public IActionResult Add()
    {
        ViewBag.teamsList = new SelectList(_context.Team, "Id", "Name");
        ViewBag.positionsList = new SelectList(_context.Position, "Id", "Name");
        return View();
    }
    [HttpPost]
    public IActionResult Add(Player player, List<int> positions)
    {
        var teamList = _context.Team.FirstOrDefault(a => a.Id == player.TeamId);
        player.Team = teamList;

        var playerPosition = _context.Position.Where(a => positions.Contains(a.Id)).ToList();
        player.Positions = playerPosition;

        _context.Player.Add(player);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult Edit(int? playerId)
    {
        var player = _context.Player.Include(a => a.Team).Include(a => a.Positions).FirstOrDefault(a => a.Id == playerId);
        ViewBag.teamsList = new SelectList(_context.Team, "Id", "Name");
        ViewBag.positionsList = new SelectList(_context.Position, "Id", "Name");
        return View(player);
    }
    [HttpPost]
    public IActionResult Edit(Player player, List<int> positions)
    {
        var newPlayer = _context.Player.Include(a => a.Team).Include(a => a.Positions).FirstOrDefault(a => a.Id == player.Id);
        if (newPlayer != null)
        {
            newPlayer.FirstName = player.FirstName;
            newPlayer.LastName = player.LastName;
            newPlayer.Country = player.Country;
            newPlayer.BirthDate = player.BirthDate;
            newPlayer.TeamId = player.TeamId;
            newPlayer.Positions.Clear();
            var teamList = _context.Team.FirstOrDefault(a => a.Id == player.TeamId);
            newPlayer.Team = teamList;

            var playerPosition = _context.Position.Where(a => positions.Contains(a.Id)).ToList();
            newPlayer.Positions = playerPosition;


            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
    public IActionResult Delete(int? playerId)
    {
        var player = _context.Player.Include(a => a.Team).Include(a => a.Positions).FirstOrDefault(a => a.Id == playerId);
        _context.Player.Remove(player);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}