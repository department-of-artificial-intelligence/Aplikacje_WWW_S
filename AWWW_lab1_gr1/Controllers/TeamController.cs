using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab1_gr1.Controllers;
public class TeamController : Controller
{
    private readonly MyDbContext _context;

    public TeamController(MyDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var teams = _context.Teams.
    Include(team => team.League).
    ToList();
        return View(teams);


    }

    public IActionResult Add()
    {
        ViewBag.LeaguesList = _context.Leagues.Select(t => new SelectListItem($"{t.Name}", t.Id.ToString()));
        /*  var teams = _context.Teams.ToList();
         var teamsList = new List<SelectListItem>();
         foreach (var t in teams)
         {
             string text = t.Name + "," + t.Country + "," + t.City + "," + t.FoundingDate + "," + t.League;
             string id = t.Id.ToString();
             teamsList.Add(new SelectListItem(id,text));
         }
         ViewBag.teamsList = teamsList;
          */
        return View();
    }

    [HttpPost]
    public IActionResult Add(Team team)
    {
        try
            {
        if (ModelState.IsValid)
        {
            _context.Teams.Add(team);

            
                _context.SaveChanges();
        
            


            return RedirectToAction("Index");
        } }catch (Exception ex)
            {

                return View("Error");
            }

        return View(team);
    }

    public IActionResult Edit(int id)
        {
            Team? team = _context.Teams
                .Include(l => l.League)
                .FirstOrDefault(t => t.Id == id);

            ViewBag.League = _context.Leagues.Select(l => new SelectListItem(l.Name, l.Id.ToString()));

            return View(team);
        }

        [HttpPost]

        public IActionResult Edit(Team team)
        {
            ModelState.Remove("League");

            if (ModelState.IsValid)
            {
                var League = _context.Leagues.Find(team.LeagueId);
                if (League == null)
                {
                    return View();
                }

                team.League = League;

                _context.Teams.Update(team);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

}