using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MyDbContext _dbContext;

        public CategoryController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int id)
        {
            var category = _dbContext.Category.FirstOrDefault(a => a.Id == id); 
            if (category != null)
                return View(category);
            return View("Error");
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _dbContext.Category.Add(category); 
            _dbContext.SaveChanges();
            return View("Added",category); 
        }
    }
}
