using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kolokwium.Models;

namespace Kolokwium.Controllers;

public class TeamController : Controller
{
    private readonly MyDbContext _context;

    public TeamController(MyDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var teams = _context.Team.ToList();
        return View(teams);
    }
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(Team team)
    {
        _context.Team.Add(team);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
