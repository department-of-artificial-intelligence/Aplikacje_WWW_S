using Microsoft.AspNetCore.Mvc;
using AWWW_lab3_gr2.Models;


namespace AWWW_lab3_gr2.Controllers
{
    public class LeagueController : Controller
    {
        private readonly MyDbContext _context;
        public LeagueController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(League league)
        {
            _context.Leagues.Add(league);
            _context.SaveChanges();
            return View("Added", league);
        }
    }
}
