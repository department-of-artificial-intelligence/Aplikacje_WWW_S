using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr1.Models;

public class LeagueController : Controller
{

    private readonly MyDbContext _dbContext;
    public LeagueController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var leagues = _dbContext.Leagues.ToList();
        return View(leagues);
    }

    public IActionResult Edit(int id)
    {
        var league = _dbContext.Leagues.Find(id);
        if (league == null)
        {
            return NotFound();
        }
        return View(league);
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var league = _dbContext.Leagues.Find(id);
        if (league == null)
        {
            return NotFound();
        }
        _dbContext.Leagues!.Remove(league);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var league = _dbContext.Leagues.Find(id);
        if (league == null)
        {
            return NotFound();
        }
        return View(league);
    }

    [HttpPost]
    public IActionResult AddOrUpdate(League league)
    {
        if (league.Id != 0)
        {
            var a = _dbContext.Leagues.Find(league.Id);
            if (a != null)
            {
                a.Name = league.Name;
                a.Country = league.Country;
                a.Level = league.Level;
            }
        }
        else
        {
            _dbContext.Leagues!.Add(league);
        }
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult AddOrUpdate(int id = -1)
    {

        if (id != -1)
        {
            var league = _dbContext.Leagues!
                .FirstOrDefault(a => a.Id == id);
            @ViewBag.Header = "Edytuj ligę";
            @ViewBag.ButtonText = "Edytuj";
            return View(league);
        }
        else
        {
            @ViewBag.Header = "Dodaj ligę";
            @ViewBag.ButtonText = "Dodaj";
            return View();
        }

    }

    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var league = _dbContext.Leagues.Find(id);
        if (league == null)
        {
            return NotFound();
        }
        return View(league);
    }


}
