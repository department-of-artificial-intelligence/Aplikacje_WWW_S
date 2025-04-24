using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr3.Controllers{

    public class CategoryController : Controller
    {

        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext db)
        {
            _dbContext = db;
        }

        
        public IActionResult Index()
        {
            ViewBag.Title = "Kategorie";
            var cat = _dbContext.Categories.ToList();
            return View("Index",cat);
        }

        [HttpGet]

        public IActionResult Add()
        {
           return View(new Category());
    
        }

        [HttpPost]

        public IActionResult Add(Category cat)
        {
            try{
                _dbContext.Categories.Add(cat);
                _dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception("Nie udało się dodać kategori : " + e.Message);
            }
            return RedirectToAction("Index");
        }

    
    }


}