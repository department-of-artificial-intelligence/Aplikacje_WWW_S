using AWWW_lab3_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab3_gr2.Controllers
{
    public class TeamController : Controller
    {
        private readonly MyDbContext _context;
        public TeamController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            var leagues = _context.Leagues.ToList();
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
            var league = _context.Leagues.FirstOrDefault(a => a.Id == team.LeagueId);
            if (league == null)
            {
                return View("error");
            }
            team.League = league;
            _context.Teams.Add(team);
            _context.SaveChanges();

            return View("Added", team);
        }
    }
}
