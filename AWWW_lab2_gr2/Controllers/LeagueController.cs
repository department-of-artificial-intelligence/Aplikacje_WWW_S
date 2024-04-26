using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr2.Models;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr2.Controllers
{
	public class LeagueController : Controller
	{
		private readonly ApplicationDbContext _context;
		public LeagueController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
            var leagues = _context.Leagues
				.Include(l => l.Teams)
				.ToList();
            return View(leagues);
        }

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(League league)
		{
			_context.Leagues.Add(league);
			_context.SaveChanges();
			return View("Added", league);
		}
	}
}
