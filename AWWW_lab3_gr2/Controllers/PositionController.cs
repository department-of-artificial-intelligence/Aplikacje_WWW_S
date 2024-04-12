using AWWW_lab3_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AWWW_lab3_gr2.Controllers
{
    public class PositionController : Controller
    {
        private readonly MyDbContext _dbContext;

        public PositionController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var positions = _dbContext.Position.ToList();
            return View(positions);
        }

        public IActionResult Details(int id)
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
            if (ModelState.IsValid)
            {
                _dbContext.Position.Add(position);
                _dbContext.SaveChanges();
                return View("Added", position);
            }
            return View();
        }
    }
}