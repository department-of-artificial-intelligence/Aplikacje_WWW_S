using AWWW_lab2_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            foreach (var a in teams)
            {
                string name = a.Name;
                string id = a.Id.ToString();
                teamsList.Add(new SelectListItem(name, id));
            }
            ViewBag.teamsList = teamsList;

            var positions = _context.Positions.ToList();
            var positionsList = new List<SelectListItem>();
            foreach (var a in positions)
            {
                string name = a.Name;
                string id = a.Id.ToString();
                positionsList.Add(new SelectListItem(name, id));
            }
            ViewBag.positionsList = positionsList;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Player player, List<int> positions)
        {
            var team = _context.Teams.FirstOrDefault(a => a.Id == player.TeamId);
            if (team == null)
            {
                return View("Error");
            }
            player.Team = team;

            var playerPositions = _context.Positions.Where(p => positions.Contains(p.Id)).ToList();
            player.Positions = playerPositions;

            _context.Players.Add(player);
            _context.SaveChanges();
            return View("Added", player);
        }
    }
}