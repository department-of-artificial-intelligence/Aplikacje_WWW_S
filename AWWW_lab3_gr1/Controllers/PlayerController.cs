using AWWW_lab3_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab3_gr1.Controllers;

public class PlayerController : Controller
{
  private readonly MyDbContext _dbContext;

  public PlayerController(MyDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public IActionResult Index()
  {
    List<Player> players = _dbContext.Players
      .Include(player => player.Team)
      .Include(player => player.Positions)
      .ToList();

    ViewBag.Title = "Players";

    return View(players);
  }

  public IActionResult Details(int id)
  {
    Player player = _dbContext.Players.FirstOrDefault(el => el.Id == id);

    if (player == null)
    {
      return View("Error");
    }

    return View(player);
  }

  private List<Team> GetTeams()
  {
    List<Team> teams = _dbContext.Teams.ToList();
    return teams;
  }

  private List<Position> GetPositions()
  {
    List<Position> positions = _dbContext.Positions.ToList();
    return positions;
  }

  public IActionResult Add()
  {
    ViewBag.Teams = GetTeams();
    ViewBag.Positions = GetPositions();

    return View("Edit", new Player { BirthDate = DateTime.Now });
  }

  public IActionResult Edit(int id)
  {
    Player player = _dbContext.Players
      .Include(p => p.Positions)
      .FirstOrDefault(el => el.Id == id);

    if (player == null)
    {
      return View("Error");
    }

    ViewBag.Teams = GetTeams();
    ViewBag.Positions = GetPositions();

    return View("Edit", player);
  }

  [HttpPost]
  public IActionResult Save(Player player, int[] playerPositions)
  {
    var positions = _dbContext.Positions.Where(el => playerPositions.Contains(el.Id)).ToList();

    if (player.Id == 0)
    {
      player.Positions = positions;
      _dbContext.Players.Add(player);
    }
    else
    {
      _dbContext.Players.Update(player);
      _dbContext.SaveChanges();

      _dbContext.Players
          .Include(player => player.Positions)
          .FirstOrDefault(el => el.Id == player.Id)
          .Positions.Clear();

      Player playerDB = _dbContext.Players.FirstOrDefault(p => p.Id == player.Id);
      playerDB.Positions = positions;
    }

    try
    {
      _dbContext.SaveChanges();
    }
    catch (Exception error)
    {
      View("Error");
    }

    return RedirectToAction("Details", "Player", new { id = player.Id });
  }

  public IActionResult Delete(int id)
  {
    Player player = _dbContext.Players.FirstOrDefault(el => el.Id == id);

    if (player == null)
    {
      return RedirectToAction("Index");
    }

    _dbContext.Players.Remove(player);
    _dbContext.SaveChanges();

    return RedirectToAction("Index");
  }
}