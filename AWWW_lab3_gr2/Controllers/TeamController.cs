using AWWW_lab3_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab3_gr2.Controllers
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
            var leagues = _dbContext.League.ToList();
            var leaguesList = new List<SelectListItem>();
            foreach (var a in leagues)
            {
                string text = a.Name;
                string id = a.Id.ToString();
                leaguesList.Add(new SelectListItem(text, id));
            }
            ViewBag.leaguesList = leaguesList;

            return View();
        }


        [HttpPost]
        public IActionResult Add(Team team)
        {
            var league = _dbContext.League.FirstOrDefault(a => a.Id == team.LeagueId);
            if (league == null)
            {
                return View("error");
            }
            team.League = league;
            _dbContext.Team.Add(team);
            _dbContext.SaveChanges();

            return View("Added", team);
        }
    }
}