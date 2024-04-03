using AWWW_lab1_gr1.Data;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Controllers
{
    public class LeagueController : Controller
    {
        private readonly MyDBContext _dbContext;

        public LeagueController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<League> leagues = _dbContext.Leagues!.ToList();
            return View(leagues);
        }

        public IActionResult Details (int id)
        {
            League? league = _dbContext.Leagues
                .Include(a => a.Teams)
                .FirstOrDefault(a => a.Id == id);
            return View(league);
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
                _dbContext.Add(league);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
