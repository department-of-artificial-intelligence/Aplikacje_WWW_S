using AWWW_lab1_gr1.Data;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr1.Controllers
{
    public class PositionController : Controller
    {
        private readonly MyDBContext _dbContext;

        public PositionController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Position> positions = _dbContext.Positions!.ToList();
            return View(positions);
        }

        public IActionResult Details(int id)
        {
            Position? position = _dbContext.Positions.FirstOrDefault(x => x.Id == id);
            return View(position);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Position position)
        {
            if(ModelState.IsValid)
            {
                _dbContext.Positions.Add(position);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
