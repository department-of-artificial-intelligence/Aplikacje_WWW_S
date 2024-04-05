using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace AWWW_lab1_gr2.Controllers
{
    public class TeamController : Controller
    {
        private readonly MyDbContext _dbContext;

        public TeamController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Add()
        {
            ViewBag.Leagues = new SelectList(_dbContext.League, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Team team)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Team.Add(team);
                _dbContext.SaveChanges();
            return View("Added");
            }
           
            ViewBag.Leagues = new SelectList(_dbContext.League, "Id", "Name", team.LeagueId);
            return View(team);
        }

        public IActionResult Added()
        {
            return View();
        }
    }
}
