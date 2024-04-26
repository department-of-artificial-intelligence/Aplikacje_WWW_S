using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Controllers
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
            var positions = _dbContext.Positions!.ToList(); 
            return View(positions);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Position position)
        {
            _dbContext.Positions!.Add(position); 
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        


    }
}