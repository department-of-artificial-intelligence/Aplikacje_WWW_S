using AWWW_lab2_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab2_gr2.Controllers
{
    public class TeamController : Controller
    {
        private readonly MyDbContext _dbContext;

        public TeamController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var teams = _dbContext.Team.ToList();
            return View(teams);
        }

        public IActionResult Details(int id)
        {
            var team = _dbContext.Team.FirstOrDefault(a => a.Id == id);
            if (team != null)
                return View(team);
            return View("Error");
        }
        public IActionResult Add()
        {
            ViewBag.Leagues = new SelectList(_dbContext.League.OrderBy(l => l.Name), "Id", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult Add(Team team)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Team.Add(team);
                _dbContext.SaveChanges();
                return View("Added", team);
            }
            ViewBag.Leagues = new SelectList(_dbContext.League.OrderBy(l => l.Name), "Id", "Name", team.LeagueId);
            return View(team);
        }
    }
}