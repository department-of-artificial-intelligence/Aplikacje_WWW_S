using AWWW_lab1_gr1.Data;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MyDBContext _dbContext;

        public CategoryController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Category> categories = _dbContext.Categories!.ToList();
            return View(categories);
        }

        public IActionResult Details(int id) 
        {
            Category? category = _dbContext.Categories
                .Include(a => a.Articles)
                .FirstOrDefault(a => a.Id == id);
            return View(category);
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
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
