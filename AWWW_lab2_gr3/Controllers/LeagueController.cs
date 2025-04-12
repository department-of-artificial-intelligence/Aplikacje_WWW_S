using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab2_gr3.Controllers{

    public class LeagueController : Controller
    {

        private readonly AppDbContext _dbContext;

        public LeagueController(AppDbContext db)
        {
            _dbContext = db;
        }

        
        public IActionResult Index()
        {
            ViewBag.Title = "Ligi";
            var ligi = _dbContext.Leagues.ToList();
            return View("Index",ligi);
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View(new League());
        }

        [HttpPost]

        public IActionResult Add(League li)
        {
            try{
                _dbContext.Leagues.Add(li);
                _dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception("Nie udało się dodać Ligi : " + e.Message);
            }
            return RedirectToAction("Index");

        }

    }


}