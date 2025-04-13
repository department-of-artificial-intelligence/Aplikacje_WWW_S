using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers{

    public class PlayerController : Controller{

        private readonly AppDbContext _dbContext;

        public PlayerController(AppDbContext db)
        {
            _dbContext = db;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Gracze";
            var players = _dbContext.Players.ToList();
            return View("Index",players);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Player());
        }

        [HttpPost]
        public IActionResult Add(Player p)
        {
            try{
                _dbContext.Players.Add(p);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw new Exception("Nie udało się dodać gracza");
            }
            return RedirectToAction("Index");
        }
    }
}