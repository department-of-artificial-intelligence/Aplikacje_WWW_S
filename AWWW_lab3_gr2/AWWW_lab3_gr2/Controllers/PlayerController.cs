using AWWW_lab3_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab3_gr2.Controllers
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
            foreach( var team in teams)
            {
                string text = team.Name;
                string id = team.Id.ToString();
                teamsList.Add(new SelectListItem(text, id));
            }
            ViewBag.teamsList = teamsList;

            var positions = _context.Positions.ToList();
            var positionsList = new List<SelectListItem>();
            foreach (var position in positions)
            {
                string text = position.Name;
                string id = position.Id.ToString();
                positionsList.Add(new SelectListItem(text, id));
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
                return View("error");
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
