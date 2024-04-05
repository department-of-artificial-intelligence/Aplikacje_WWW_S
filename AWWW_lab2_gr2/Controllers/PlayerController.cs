using AWWW_lab2_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr2.Controllers
{
    public class PlayerController : Controller
    {
        private readonly MyDbContext _context;
        public PlayerController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add() 
        {
            var teams = _context.Teams.ToList();
            var teamsList = new List<SelectListItem>();
            foreach (var team in teams) 
            {
                string name = team.Name;
                string id = team.Id.ToString();
                teamsList.Add(new SelectListItem(name, id));
            }

            ViewBag.teamsList = teamsList;

            var positions = _context.Positions.ToList();
            var positionsList = new List<SelectListItem>();
            foreach (var position in teams)
            {
                string name = position.Name;
                string id = position.Id.ToString();
                positionsList.Add(new SelectListItem(name, id));
            }
            ViewBag.positionsList = positionsList;

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
