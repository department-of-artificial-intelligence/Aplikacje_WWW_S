using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class LeaguesController : Controller
{
    LabOneContext dbContext;

    public LeaguesController(LabOneContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<IActionResult> Index()
    {


        return View(await dbContext.Leagues.Include(e => e.Teams).ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(League league)
    {
        if (ModelState.IsValid)
        {
            dbContext.Add(league);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        return View(league);
    }
}
