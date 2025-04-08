using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers {
    public class CategoryController : Controller {

        private readonly MyDbContext _dbContext;

        public CategoryController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index() {
            var categories = _dbContext.Categories.ToList();
            return View(categories);
        }

        public IActionResult Add() {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(Category category) {
            if (ModelState.IsValid)
            {
                if (category == null) {
                    return View("Error");
                }
                _dbContext.Categories.Add(category);
                try
                {
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("Error");
                }

                return RedirectToAction("Index");
            }
            return View("Error");
        }
    }
}
