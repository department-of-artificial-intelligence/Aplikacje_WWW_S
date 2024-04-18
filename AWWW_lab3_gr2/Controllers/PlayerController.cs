using AWWW_lab3_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var players = _dbContext.Player.Include(a => a.Team).Include(a => a.Position).ToList();
            return View(players);
        }
        public IActionResult Add()
        {
            ViewBag.teamsList = new SelectList(_dbContext.Team, "Id", "Name");
            ViewBag.positionsList = new SelectList(_dbContext.Position, "Id", "Name");
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

        public IActionResult Update(int? id)
        {
            var player = _dbContext.Player.Include(a => a.Position).FirstOrDefault(a => a.Id == id);
            ViewBag.teamsList = new SelectList(_dbContext.Team, "Id", "Name");
            ViewBag.positionsList = _dbContext.Position.ToList();
            return View(player);
        }

        [HttpPost]
        public IActionResult Update(Player player, List<int> positions)
        {
            var playerDB = _dbContext.Player.Include(a => a.Position).FirstOrDefault(a => a.Id == player.Id);
            if (playerDB != null)
            {
                playerDB.FirstName = player.FirstName;
                playerDB.LastName = player.LastName;
                playerDB.Country = player.Country;
                playerDB.BirthDate = player.BirthDate;
                playerDB.TeamId = player.TeamId;
                playerDB.Position.Clear();

                var playerPosition = _dbContext.Position.Where(a => positions.Contains(a.Id)).ToList();
                playerDB.Position = playerPosition;

                _dbContext.SaveChanges();
            }
            var players = _dbContext.Player.Include(a => a.Team).Include(a => a.Position);
            return View("Index", players);
        }
    }
}