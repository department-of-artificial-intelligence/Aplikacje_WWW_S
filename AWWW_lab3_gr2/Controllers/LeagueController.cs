using AWWW_lab3_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab3_gr2.Controllers
{
    public class LeagueController : Controller
    {
        private readonly MyDbContext _dbContext;

        public LeagueController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var leagues = _dbContext.League.Include(a => a.Teams).ToList();
            return View(leagues);
        }

        public IActionResult Details(int id)
        {
            var league = _dbContext.League.FirstOrDefault(a => a.Id == id);
            if (league != null)
                return View(league);
            return View("Error");
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(League league)
        {
            if (ModelState.IsValid)
            {
                _dbContext.League.Add(league);
                _dbContext.SaveChanges();
                return View("Added", league);
            }
            return View();
        }
    }
}