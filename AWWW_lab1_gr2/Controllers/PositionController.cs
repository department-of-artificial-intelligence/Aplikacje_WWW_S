using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr2.Controllers
{
    public class PositionController : Controller
    {
        private readonly MyDbContext _dbContext;

        public PositionController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int id)
        {
            var position = _dbContext.Position.FirstOrDefault(a => a.Id == id);
            if (position != null)
                return View(position);
            return View("Error");
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Position position)
        {
            _dbContext.Position.Add(position); 
            _dbContext.SaveChanges();
            return View("Added",position); 
        }
    }
}
