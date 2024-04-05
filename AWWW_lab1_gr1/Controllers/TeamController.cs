using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab1_gr1.Controllers;
public class TeamController : Controller
{
    private readonly MyDbContext _context;

    public TeamController(MyDbContext context)
    {
        _context = context;
    }

    // GET: Teams/Create
    public IActionResult Create()
    {
        ViewData["LeagueId"] = new SelectList(_context.Leagues, "Id", "Name");
        return View();
    }

    // POST: Teams/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Country,City,FoundingDate,LeagueId")] Team team)
    {
        if (ModelState.IsValid)
        {
            _context.Add(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["LeagueId"] = new SelectList(_context.Leagues, "Id", "Name", team.LeagueId);
        return View(team);
    }
}