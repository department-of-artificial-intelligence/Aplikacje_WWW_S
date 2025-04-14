using Microsoft.AspNetCore.Mvc;
using AWWW_lab02_gr3.Models;

namespace AWWW_lab02_gr3.Controllers
{
    public class LeagueController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger _logger;

        public LeagueController(AppDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var leagues = _dbContext.Leagues.ToList();
                return View(leagues);
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Błąd w LeagueController.Index(): {Message}", ex.Message);
                return View("Error");
            }
        }


        public IActionResult Add()
        {
            try
            {
                return View();
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Błąd w LeagueController.Add(): {Message}", ex.Message);
                return View("Error");
            }
        }


        [HttpPost]
        public IActionResult Add(League league)
        {
            try
            {
                if(!ModelState.IsValid)
                    return View("Error");

                _dbContext.Add(league);
                _dbContext.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Błąd w LeagueController.Add(League league): {Message}", ex.Message);
                return View("Error");
            }
        }
    }
}