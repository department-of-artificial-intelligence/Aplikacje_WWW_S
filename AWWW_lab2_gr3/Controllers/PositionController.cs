using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers {
    public class PositionController : Controller {

        private readonly MyDbContext _dbContext;

        public PositionController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index() {
            var positions = _dbContext.Positions.ToList();
            return View(positions);
        }

        public IActionResult Add() {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(Position position){
            if (position == null){
                return View("Error");
            }
            _dbContext.Positions.Add(position);
            try {
                _dbContext.SaveChanges();
            } catch (Exception ex) {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}
