using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

public class TeamController : Controller
{
    private readonly MyDbContext _dbContext;
    public TeamController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IActionResult Index()
    {
        var teams = _dbContext.Teams.Include(t => t.League).ToList();
        return View(teams);
    }

    // GET: Team/Create
    public IActionResult Add()
    {
        var league = _dbContext.Leagues.ToList();
        var leagueList = new List<SelectListItem>();
        foreach (var i in league)
        {
            string id = i.Id.ToString();
            string info = i.Name;
            leagueList.Add(new SelectListItem(info, id));
        }
        ViewBag.LeagueList = leagueList;
        return View();
    }

    [HttpPost]
    public IActionResult Add(Team team)
    {
        var league = _dbContext.Leagues.FirstOrDefault(a => a.Id == team.LeagueId);
        team.League = league; //jeśli nie przypiszemy, dane zostaną poprawnie zapisianie w bazie, ale nie będzie pobrany Autor do tej encji


        _dbContext.Teams.Add(team);
        _dbContext.SaveChanges();
        return View("Added", team);
    }

    public IActionResult Edit(int id)
    {
        var team = _dbContext.Teams.FirstOrDefault(p => p.Id == id);
        if (team == null)
        {
            return NotFound();
        }

        ViewBag.LeagueList = _dbContext.Leagues
            .Select(t => new SelectListItem(t.Name, t.Id.ToString()))
            .ToList();

        return View(team);
    }

    [HttpPost]
    public IActionResult Edit(Team team)
    {
        var existingteam = _dbContext.Teams.FirstOrDefault(p => p.Id == team.Id);

        if(existingteam != null)
        {
            existingteam.Name = team.Name;
            existingteam.Country = team.Country;
            existingteam.City = team.City;
            existingteam.FoundingDate = team.FoundingDate;
            existingteam.LeagueId = team.LeagueId;

            _dbContext.Update(existingteam);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        return NotFound();
    }

    public IActionResult Delete(int Id)
    {
        var Team = _dbContext.Teams.FirstOrDefault(t => t.Id == Id);
        if(Team != null)
        {
            _dbContext.Teams.Remove(Team);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        return NotFound();
    }
}


