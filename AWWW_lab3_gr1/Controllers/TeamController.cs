using AWWW_lab3_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab3_gr1.Controllers;

public class TeamController : Controller
{
  private readonly MyDbContext _dbContext;

  public TeamController(MyDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public IActionResult Index()
  {
    List<Team> teams = _dbContext.Teams
      .Include(team => team.League)
      .Include(team => team.Players)
        .ThenInclude(player => player.Positions)
      .ToList();

    ViewBag.Title = "Teams";

    return View(teams);
  }

  public IActionResult Details(int id)
  {
    Team team = _dbContext.Teams.FirstOrDefault(el => el.Id == id);

    if (team == null)
    {
      return View("Error");
    }

    return View(team);
  }

  private List<League> GetLeagues()
  {
    List<League> leagues = _dbContext.Leagues.ToList();
    return leagues;
  }

  public IActionResult Add()
  {
    ViewBag.Leagues = GetLeagues();
    return View("Edit", new Team { FoundingDate = DateTime.Now });
  }

  public IActionResult Edit(int id)
  {
    Team team = _dbContext.Teams.FirstOrDefault(el => el.Id == id);

    if (team == null)
    {
      return View("Error");
    }

    ViewBag.Leagues = GetLeagues();

    return View("Edit", team);
  }

  [HttpPost]
  public IActionResult Save(Team team)
  {
    Console.WriteLine("Team League:", team.League);

    if (team.Id == 0)
    {
      _dbContext.Teams.Add(team);
    }
    else
    {
      _dbContext.Teams.Update(team);
    }

    try
    {
      _dbContext.SaveChanges();
    }
    catch (Exception error)
    {
      View("Error");
    }

    return RedirectToAction("Details", "Article", new { id = team.Id });
  }

  public IActionResult Delete(int id)
  {
    Article article = _dbContext.Articles.FirstOrDefault(el => el.Id == id);

    if (article == null)
    {
      return RedirectToAction("Index");
    }

    _dbContext.Articles.Remove(article);
    _dbContext.SaveChanges();

    return RedirectToAction("Index");
  }
}