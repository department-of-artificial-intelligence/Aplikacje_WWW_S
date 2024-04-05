using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Controllers
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
            var categories = _dbContext.Categories!.ToList(); 
            return View(categories);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _dbContext.Categories!.Add(category); 
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        


    }
}