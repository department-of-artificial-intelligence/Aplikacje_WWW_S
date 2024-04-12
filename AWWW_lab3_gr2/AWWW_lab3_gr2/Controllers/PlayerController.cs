using AWWW_lab3_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            var players = _context.Players.Include(a => a.Team).ToList();
            return View(players);
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

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.teamsList = new SelectList(_context.Teams, "Id", "Name");
            ViewBag.allPositions = _context.Positions.ToList();

            var player = _context.Players
                 .Include(p => p.Positions) // Załaduj pozycje za pomocą Eager Loading
                 .FirstOrDefault(p => p.Id == id);

            return View(player);
        }

        [HttpPost]
        public IActionResult Edit(Player player, List<int> selectedPositions)
        {
            var playerToUpdate = _context.Players
                .Include(p => p.Positions)
                .FirstOrDefault(p => p.Id == player.Id);

            if (playerToUpdate != null)
            {
                playerToUpdate.FirstName = player.FirstName;
                playerToUpdate.LastName = player.LastName;
                playerToUpdate.Country = player.Country;
                playerToUpdate.BirthDate = player.BirthDate;
                playerToUpdate.TeamId = player.TeamId;

                playerToUpdate.Positions.Clear();
                foreach (var positionId in selectedPositions)
                {
                    var positionToAdd = _context.Positions.Find(positionId);
                    if (positionToAdd != null)
                    {
                        playerToUpdate.Positions.Add(positionToAdd);
                    }
                }
            }
            _context.SaveChanges();

            var players = _context.Players
                   .Include(p => p.Team)
                   .Include(p => p.Positions);

            return View("Index", players);
        }       
    }
}
