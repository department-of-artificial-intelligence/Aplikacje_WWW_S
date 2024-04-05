
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            var leagues = _dbContext.Leagues!.ToList(); 
            return View(leagues);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(League league)
        {
            _dbContext.Leagues!.Add(league); 
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        


    }
}