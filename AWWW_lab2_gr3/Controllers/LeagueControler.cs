using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc;

public class LeagueController : Controller
{
    private readonly OskiDBContext _dbContext;

    public LeagueController(OskiDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var leagues = _dbContext.League.ToList();
        return View(leagues);
    }

}