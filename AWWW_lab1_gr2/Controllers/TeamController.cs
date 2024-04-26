
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace AWWW_lab1_gr2.Models;

public class TeamController : Controller
	{
		private readonly MyDbContext _dbContext;
		public TeamController(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IActionResult Index()
		{
            var teams = _dbContext.Team
				.Include(a => a.League).ToList();
            return View(teams);
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

		