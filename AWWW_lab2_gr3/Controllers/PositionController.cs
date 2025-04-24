using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace AWWW_lab2_gr3.Controllers{

    public class PositionController : Controller
    {

        private readonly AppDbContext _dbContext;

        public PositionController(AppDbContext db)
        {
            _dbContext = db;
        }


        
        public IActionResult Index()
        {
            ViewBag.Title = "Pozycje";
            var pos = _dbContext.Positions.ToList();
            return View("Index",pos);
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View(new Position());
        }

        [HttpPost]

        public IActionResult Add(Position p)
        {
            try{
                _dbContext.Positions.Add(p);
                _dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception("Nie udało się dodać pozycji : " + e.Message);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Id = id;
            return View("Delete");
        }

        [HttpPost]
        public IActionResult DeleteC(int id)
        {
            var position = _dbContext.Positions.Include(t=> t.Player).FirstOrDefault(l => l.Id == id);
            if (position == null)
            {
                return NotFound();
            }
            
            var player = _dbContext.Players.Include(p => p.Positions).FirstOrDefault(l => l.Id == position.PlayerId);
            player.Positions.Remove(position);
            
            _dbContext.Positions.Remove(position);
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