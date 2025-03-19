using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc;

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

    // GET: Autor/Create
    public IActionResult Add()
    {
        return View();
    }

    // POST: Autor/Create
    [HttpPost]
    public IActionResult Add(League league)
    {
        _dbContext.Leagues.Add(league);
        _dbContext.SaveChanges();
        return View("Added", league);
    }

}