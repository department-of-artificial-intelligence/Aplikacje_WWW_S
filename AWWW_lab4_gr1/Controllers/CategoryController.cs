using Microsoft.AspNetCore.Mvc;
using AWWW_lab4_gr1.Models;

namespace AWWW_lab4_gr1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index(int id)
        {
            var category = _dbContext.Categories.Find(id);
            return View(category);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return View("Added", category);
        }
    }
}
