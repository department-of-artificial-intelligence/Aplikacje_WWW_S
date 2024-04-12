using AWWW_lab3_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AWWW_lab3_gr2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MyDbContext _dbContext;

        public CategoryController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var categories = _dbContext.Category.ToList();
            return View(categories);
        }

        public IActionResult Details(int id)
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
            if (ModelState.IsValid)
            {
                _dbContext.Category.Add(category);
                _dbContext.SaveChanges();
                return View("Added", category);
            }
            return View();
        }
    }
}