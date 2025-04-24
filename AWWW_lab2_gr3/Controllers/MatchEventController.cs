using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace AWWW_lab2_gr3.Controllers{

    public class MatchEventController : Controller
    {

        private readonly AppDbContext _dbContext;

        public MatchEventController(AppDbContext db)
        {
            _dbContext = db;
        }
    
    
    
        public IActionResult Index()
        {
        
            ViewBag.Title = "Wydarzenia meczowe";
            var events = _dbContext.MatchEvents.ToList();
            return View("Index",events);
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View(new MatchEvent());
        }

        [HttpPost]

        public IActionResult Add(MatchEvent me)
        {
            try{
                _dbContext.MatchEvents.Add(me);
                _dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception("Nie udało się dodać zdarzenia : " + e.Message);
            }
            return RedirectToAction("Index");
        }
    }


}