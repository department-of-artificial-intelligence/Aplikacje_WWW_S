using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AWWW_lab1_gr1.Models;

namespace MultiSelectListExample.Controllers
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
            try
            {
                var players = _dbContext.Players.Include(p => p.Positions).Include(p => p.Team);
                return View(players);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public IActionResult Add()
        {
            try
            {
                ViewBag.PositionsList = _dbContext.Positions.Select(p => new SelectListItem(p.Name, p.Id.ToString()));
                ViewBag.TeamsList = _dbContext.Teams.Select(t => new SelectListItem(t.Name, t.Id.ToString()));
                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Player player, List<int> selectedPositionsIds, int selectedTeamId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                player.Positions = _dbContext.Positions.Where(p => selectedPositionsIds.Contains(p.Id)).ToList();
                player.Team = _dbContext.Teams.Find(selectedTeamId);
                _dbContext.Players.Add(player);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
