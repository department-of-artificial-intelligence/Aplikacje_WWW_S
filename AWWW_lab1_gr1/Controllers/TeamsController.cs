using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class TeamsController : Controller
{
    LabOneContext dbContext;

    public TeamsController(LabOneContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<IActionResult> Index()
    {
        var teams = await dbContext.Teams.Include(e => e.League).Include(e => e.Players).ThenInclude(e => e.Positions).ToListAsync();


        return View(teams);
    }


    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var leagues = await dbContext.Leagues.ToListAsync();

        var createTeam = new CreateTeam
        {
            Leagues = leagues,
            NewTeam = new Team()
        };

        return View(createTeam);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTeam createTeam)
    {
        Console.WriteLine(createTeam.NewTeam.ToString());

        dbContext.Teams.Add(createTeam.NewTeam);
        await dbContext.SaveChangesAsync();
        return RedirectToAction("Index");

    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var leagues = await dbContext.Leagues.ToListAsync();
        var team = await dbContext.Teams.FindAsync(id);


        ViewBag.Leagues = leagues;


        return View(team);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Team team)
    {
        dbContext.Teams.Update(team);
        await dbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
