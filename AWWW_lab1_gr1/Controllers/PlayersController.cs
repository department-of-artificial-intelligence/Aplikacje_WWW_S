using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PlayersController : Controller
{
    LabOneContext dbContext;

    public PlayersController(LabOneContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<IActionResult> Index()
    {
        var players = await dbContext.Players
          .Include(p => p.Team)
          .Include(p => p.Positions)
          .ToListAsync();



        return View(players);
    }


    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Teams = await dbContext.Teams.ToListAsync();
        ViewBag.Positions = await dbContext.Positions.ToListAsync();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Player player, int Team, List<int> Positions)
    {
        var teams = await dbContext.Teams.ToListAsync();
        player.Team = await dbContext.Teams.FirstOrDefaultAsync(t => t.Id == Team);

        ModelState.SetModelValue("Team", player.Team, player.Team.ToString());

        player.Positions = await dbContext.Positions.Where(p => Positions.Contains(p.Id)).ToListAsync();



        Console.WriteLine(ModelState.IsValid);
        if (ModelState.IsValid)
        {
            dbContext.Add(player);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        ViewBag.Positions = await dbContext.Positions.ToListAsync();
        ViewBag.Teams = teams;

        return View(player);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Player player, int Team, List<int> Positions)
    {
        if (id != player.Id)
        {
            return NotFound();
        }

        var positions = await dbContext.Positions.ToListAsync();
        ViewBag.Positions = positions;
        ViewBag.Teams = await dbContext.Teams.ToListAsync();

        player.Team = await dbContext.Teams.FirstOrDefaultAsync(t => t.Id == Team);

        ModelState.SetModelValue("Team", player.Team, player.Team.ToString());

        var playerPositions = await dbContext.PlayerPositions.Where(pp => pp.PlayerId == player.Id).ToListAsync();

        dbContext.PlayerPositions.RemoveRange(playerPositions);


        player.Positions = await dbContext.Positions.Where(p => Positions.Contains(p.Id)).ToListAsync();

        var playerPositionsToAdd = player.Positions.Select(p => new PlayerPosition { Player = player, Position = p }).ToList();

        if (ModelState.IsValid)
        {
            try
            {

                player.Positions = [];

                dbContext.Update(player);

                dbContext.PlayerPositions.AddRange(playerPositionsToAdd);

                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(player.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }

        return View(player);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var player = await dbContext.Players
            .Include(p => p.Positions)
            .Include(p => p.Team)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (player == null)
        {
            return NotFound();
        }

        var positions = await dbContext.Positions.ToListAsync();
        ViewBag.Positions = positions;
        ViewBag.Teams = await dbContext.Teams.ToListAsync();

        return View(player);
    }

    private bool PlayerExists(int id)
    {
        return dbContext.Players.Any(e => e.Id == id);
    }
}
