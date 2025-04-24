using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            var teams = _dbContext.Teams.Select(p => new SelectListItem{
                Value = p.LeagueId.ToString(),
                Text = p.Name
            }).ToList();
            ViewBag.Teams = teams;
            return View("Index",ligi);
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View(new League());
        }


        [HttpGet]

        public IActionResult Delete(int id)
        {
            ViewBag.Id = id;
            return View("Delete");
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

        [HttpPost]
        public IActionResult DeleteC(int id)
        {
            var league = _dbContext.Leagues.Include(t=> t.Teams).FirstOrDefault(l => l.Id == id);
            if (league == null)
            {
                return NotFound();
            }
            
            foreach(var team in league.Teams)
            {
                team.LeagueId = null;
                team.League = null;
            }

            _dbContext.Leagues.Remove(league);
            try{
                _dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception("Nie udało się usunąć ligi : " + e.Message);
            }
            return RedirectToAction("Index");
        }

    }


}