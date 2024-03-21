using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr2.Controllers
{
    public class LeagueController : Controller
    {
        private readonly MyDbContext _dbContext;

        public LeagueController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int id)
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
            _dbContext.League.Add(league); 
            _dbContext.SaveChanges();
            return View("Added",league); 
        }
    }
}
