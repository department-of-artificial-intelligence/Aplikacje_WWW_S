using AWWW_lab3_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab3_gr2.Controllers
{
    public class PlayerController : Controller
    {
        private readonly MyDbContext _dbContext;

        public PlayerController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var players = _dbContext.Player.ToList();
            return View(players);
        }

        public IActionResult Details(int id)
        {
            var player = _dbContext.Player.FirstOrDefault(a => a.Id == id);
            if (player != null)
                return View(player);
            return View("Error");
        }
        public IActionResult Add()
        {
            var teams = _dbContext.Team.ToList();
            var teamsList = new List<SelectListItem>();
            foreach (var a in teams)
            {
                string text = a.Name;
                string id = a.Id.ToString();
                teamsList.Add(new SelectListItem(text, id));
            }
            ViewBag.teamsList = teamsList;

            var positions = _dbContext.Position.ToList();
            var positionsList = new List<SelectListItem>();
            foreach (var a in positions)
            {
                string text = a.Name;
                string id = a.Id.ToString();
                positionsList.Add(new SelectListItem(text, id));
            }
            ViewBag.positionsList = positionsList;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Player player, List<int> positions)
        {
            var team = _dbContext.Team.FirstOrDefault(a => a.Id == player.TeamId);
            if (team == null)
            {
                return View("error");
            }
            player.Team = team;

            var playerPosition = _dbContext.Position.Where(a => positions.Contains(a.Id)).ToList();
            player.Position = playerPosition;

            _dbContext.Player.Add(player);
            _dbContext.SaveChanges();

            return View("Added", player);
        }
    }
}