using AWWW_lab3_gr1;
using AWWW_lab3_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


public class LeagueController : Controller
{
  private readonly MyDbContext _dbContext;

  public LeagueController(MyDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public IActionResult Index()
  {
    List<League> leagues = _dbContext.Leagues.Include(league => league.Teams).ToList();
    ViewBag.Title = "Leagues";

    return View(leagues);
  }

  public IActionResult Details(int id)
  {
    League league = _dbContext.Leagues.FirstOrDefault(el => el.Id == id);

    if (league == null)
    {
      return View("Error");
    }

    return View(league);
  }

  public IActionResult Add()
  {
    return View("Edit", new League());
  }

  public IActionResult Edit(int id)
  {
    var league = _dbContext.Leagues.FirstOrDefault(a => a.Id == id);

    if (league == null)
    {
      return View("Error");
    }

    return View("Edit", league);
  }

  [HttpPost]
  public IActionResult Save(League league)
  {
    if (league.Id == 0)
    {
      _dbContext.Leagues.Add(league);
    }
    else
    {
      _dbContext.Leagues.Update(league);
    }

    try
    {
      _dbContext.SaveChanges();
    }
    catch (Exception ex)
    {
      return View("Error");
    }

    return RedirectToAction("Details", "League", new { id = league.Id });

    // return View("Details", author);
  }

  public ActionResult Delete(int id)
  {
    League league = _dbContext.Leagues.Find(id);

    if (league == null)
    {
      return RedirectToAction("Index");
    }

    _dbContext.Leagues.Remove(league);
    _dbContext.SaveChanges();

    return RedirectToAction("Index");
  }
}