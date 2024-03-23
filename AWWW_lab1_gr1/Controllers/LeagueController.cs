using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
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
            var league = _dbContext.Leagues!.ToList(); 
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
                _dbContext.Leagues.Add(league);
                _dbContext.SaveChanges();
                return View("Added", league);
            }
            return View("Error");
        }
    }
}