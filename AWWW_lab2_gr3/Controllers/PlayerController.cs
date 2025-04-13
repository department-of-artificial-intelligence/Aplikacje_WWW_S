using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers{

    public class PlayerController : Controller{

        private readonly AppDbContext _dbContext;

        public PlayerController(AppDbContext db)
        {
            _dbContext = db;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Gracze";
            var players = _dbContext.Players.ToList();
            return View("Index",players);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var positions = _dbContext.Positions.Select(p => new SelectListItem {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();
            var team = _dbContext.Teams.Select(t => new SelectListItem {
                Value = t.Id.ToString(),
                Text = t.Name
            }).ToList();
            ViewBag.Teams = team;
            ViewBag.Positions = positions;
            return View(new Player());
        }

        [HttpPost]
        public IActionResult Add(Player p, List<int> PositionIds)
        {
                var selectedPositions = _dbContext.Positions
                    .Where(a => PositionIds.Contains(a.Id))
                    .ToList();
                p.Positions = selectedPositions;
                try
                {
                    _dbContext.Players.Add(p);
                }
                catch (Exception e)
                {
                    throw new Exception("Nie udało się dodać gracza: " + e.Message);
                }
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
        }
    }
}


/*

 if (ModelState.IsValid)
            {
                var selectedPositions = _dbContext.Positions
                    .Where(a => PositionIds.Contains(a.Id))
                    .ToList();
                p.Positions = selectedPositions;
                try
                {
                    _dbContext.Players.Add(p);
                }
                catch (Exception e)
                {
                    throw new Exception("Nie udało się dodać gracza: " + e.Message);
                }
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                var selectedPositions = p.Positions.Select(a => a.Id).ToList();

                var positions = _dbContext.Positions.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name,
                    Selected = selectedPositions.Contains(a.Id)
                });

                ViewBag.Positions = positions;
                return View(p);
            }

*/