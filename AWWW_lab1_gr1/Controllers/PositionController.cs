using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
    public class PositionController : Controller
    {
        private readonly LabDbContext _dbContext;

        public PositionController(LabDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var position = _dbContext.Positions!.ToList(); 
            return View(position);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Position position)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Positions.Add(position);
                _dbContext.SaveChanges();
                return View("Added", position);
            }
            return View("Error");
        }
    }
}