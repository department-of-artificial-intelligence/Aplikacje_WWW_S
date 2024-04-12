using AWWW_lab1_gr1.Data;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Controllers
{
    public class TeamController : Controller
    {
        private readonly MyDBContext _dbContext;

        public TeamController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Team> teams = _dbContext.Teams.ToList();
            return View(teams);
        }

        public IActionResult Details(int id)
        {
            Team? team = _dbContext.Teams
                .Include(h => h.HomeMatches)
                .Include(a => a.AwayMatches)
                .Include(p => p.Players)
                .Include(l => l.League)
                .FirstOrDefault(t => t.Id == id);
            return View(team);
        }

        public IActionResult Add()
        {
            //ViewBag.HomeMatches = _dbContext.Matches.Select(a => new SelectListItem() { Text = $"{a.Id} {a.Date.ToShortDateString()}", Value = a.Id.ToString() });
            //ViewBag.AwayMatches = _dbContext.Matches.Select(a => new SelectListItem() { Text = $"{a.Id} {a.Date.ToShortDateString()}", Value = a.Id.ToString() });
            //ViewBag.League = _dbContext.Leagues.Select(a => new SelectListItem() { Text = $"{a.Name}", Value= a.Id.ToString() });
            //ViewBag.Players = _dbContext.Players.Select(a => new SelectListItem() { Text = $"{a.FirstName} {a.LastName}", Value = a.Id.ToString() });

            ViewBag.HomeMatches = _dbContext.Matches.Select(m => new SelectListItem($"{m.Id} {m.Date.ToShortDateString()}", m.Id.ToString()));
            ViewBag.AwayMatches = _dbContext.Matches.Select(m => new SelectListItem($"{m.Id} {m.Date.ToShortDateString()}", m.Id.ToString()));
            ViewBag.League = _dbContext.Leagues.Select(l => new SelectListItem(l.Name, l.Id.ToString()));
            ViewBag.Players = _dbContext.Players.Select(p => new SelectListItem($"{p.FirstName} {p.LastName}", p.Id.ToString()));

            return View();
        }

        [HttpPost]
        public IActionResult Add(Team team, List<int> HomeMatchesId, List<int> AwayMatchesId, List<int> PlayersId)
        {
            ModelState.Remove("League");

            if (ModelState.IsValid)
            {
                team.HomeMatches = _dbContext.Matches.Where(m => HomeMatchesId.Contains(m.Id)).ToList();
                team.AwayMatches = _dbContext.Matches.Where(m => AwayMatchesId.Contains(m.Id)).ToList();
                team.Players = _dbContext.Players.Where(m => PlayersId.Contains(m.Id)).ToList();


                var League = _dbContext.Leagues.Find(team.LeagueId);
                if (League == null)
                {
                    return View();
                }

                team.League = League;

                _dbContext.Teams.Add(team);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Team? team = _dbContext.Teams
                .Include(l => l.League)
                .FirstOrDefault(t => t.Id == id);

            ViewBag.League = _dbContext.Leagues.Select(l => new SelectListItem(l.Name, l.Id.ToString()));

            return View(team);
        }

        [HttpPost]

        public IActionResult Edit(Team team)
        {
            ModelState.Remove("League");

            if (ModelState.IsValid)
            {
                var League = _dbContext.Leagues.Find(team.LeagueId);
                if (League == null)
                {
                    return View();
                }

                team.League = League;

                _dbContext.Teams.Update(team);
                _dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
