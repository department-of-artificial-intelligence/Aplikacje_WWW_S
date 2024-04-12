using AWWW_lab1_gr1;
using Microsoft.EntityFrameworkCore;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class CategoriesControllers: Controller 
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

     public async Task<IActionResult> Index()
     {
        return View(await DbContext.Categories.ToListAsync());
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