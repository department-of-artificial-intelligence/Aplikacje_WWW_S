using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class PlayerController : Controller
{
    private readonly MyDbContext _dbContext;

    public PlayerController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var playeres = _dbContext.Playeres.Include(p => p.Team)      // Załadowanie drużyny
                                        .Include(p => p.Positions) // Załadowanie pozycji
                                        .ToList();
        return View(playeres);
    }

    // GET: Autor/Create
    public IActionResult Add()
    {
        //var team = _dbContext.Teams.ToList();
        //var teamList = new List<SelectListItem>();
        //foreach (var i in team)
        //{
        //    string id = i.Id.ToString();
        //    string info = i.Name;
        //    teamList.Add(new SelectListItem(info, id));
        //}
        //ViewBag.TeamList = teamList;

        //var position = _dbContext.Positions.ToList();
        //var positionList = new List<SelectListItem>();
        //foreach (var i in position)
        //{
        //    string id = i.Id.ToString();
        //    string info = i.Name;
        //    positionList.Add(new SelectListItem(info, id));
        //}
        //ViewBag.PositionList = positionList;
        ViewBag.TeamList = _dbContext.Teams.Select(t => new SelectListItem(t.Name, t.Id.ToString())).ToList();
        ViewBag.PositionList = _dbContext.Positions.Select(p => new SelectListItem(p.Name, p.Id.ToString())).ToList();
        return View();
    }

    // POST: Autor/Create
    [HttpPost]
    public IActionResult Add(Player player, List<int> positions)
    {

        var playerPositions = positions != null ? _dbContext.Positions.Where(t => positions.Contains(t.Id)).ToList() : new List<Position>();
        player.Positions = playerPositions;

        var team = _dbContext.Teams.FirstOrDefault(a => a.Id == player.TeamId);
        player.Team = team;


        _dbContext.Playeres.Add(player);
        _dbContext.SaveChanges();
        return View("Added", player);
    }


    public IActionResult Edit(int id)
    {
        // Załaduj gracza i przypisane do niego pozycje
        var player = _dbContext.Playeres
            .Include(p => p.Positions) // Załadowanie pozycji gracza
            .FirstOrDefault(p => p.Id == id);

        if (player == null)
        {
            return NotFound();
        }

        // Załaduj listę wszystkich dostępnych pozycji
        var positionList = _dbContext.Positions.ToList();

        // Stwórz ViewBag.PositionList z informacją, które pozycje są przypisane do gracza
        ViewBag.PositionList = positionList.Select(p => new SelectListItem
        {
            Value = p.Id.ToString(),
            Text = p.Name,
            Selected = player.Positions.Any(pos => pos.Id == p.Id) // Sprawdź, czy pozycja jest przypisana do gracza
        }).ToList();

        // Załaduj listę drużyn
        ViewBag.TeamList = _dbContext.Teams
            .Select(t => new SelectListItem(t.Name, t.Id.ToString()))
            .ToList();

        return View(player);
    }



    [HttpPost]
    public IActionResult Edit(Player player, List<int> positions)
    {
        var existingPlayer = _dbContext.Playeres.Include(p => p.Positions).FirstOrDefault(p => p.Id == player.Id);
        if (existingPlayer != null)
        {
            existingPlayer.FirstName = player.FirstName;
            existingPlayer.LastName = player.LastName;
            existingPlayer.Country = player.Country;
            existingPlayer.BirthDate = player.BirthDate;
            existingPlayer.TeamId = player.TeamId;
            existingPlayer.Positions = _dbContext.Positions.Where(p => positions.Contains(p.Id)).ToList();

            _dbContext.Update(existingPlayer);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        return NotFound();
    }

    public ActionResult Delete(int id)
    {
        var player = _dbContext.Playeres.FirstOrDefault(p => p.Id == id);
        if (player != null)
        {
            _dbContext.Playeres.Remove(player);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        return NotFound();
    }



}