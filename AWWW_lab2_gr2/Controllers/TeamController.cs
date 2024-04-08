using AWWW_lab2_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr2.Controllers
{
	public class TeamController : Controller
	{
		private readonly ApplicationDbContext _context;
		public TeamController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
            var teams = _context.Teams
				.Include(a => a.League)
				.Include(a => a.Players)
                    .ThenInclude(b => b.Positions)
                .ToList();
            return View(teams);
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

		public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.leaguesList = new SelectList(_context.Leagues, "Id", "Name");

            var team = _context.Teams
				.FirstOrDefault(t => t.Id == id);

            return View(team);
        }

        [HttpPost]
        public IActionResult Edit(Team team)
        {
            var teamToUpdate = _context.Teams
                .FirstOrDefault(t => t.Id == team.Id);

            if (teamToUpdate != null)
            {
                teamToUpdate.Name = team.Name;
                teamToUpdate.Country = team.Country;
                teamToUpdate.City = team.City;
                teamToUpdate.FoundingDate = team.FoundingDate;
                teamToUpdate.LeagueId = team.LeagueId;

                _context.SaveChanges();
            }

			var teams = _context.Teams
				.Include(p => p.League);

            return View("Index", teams);
        }
    }
}
