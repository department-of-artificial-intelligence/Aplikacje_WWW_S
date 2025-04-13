using AWWW_lab02_gr3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab02_gr3.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger _logger;

        public CategoryController(AppDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var categories = _dbContext.Categories.ToList();
                return View(categories);
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Błąd CategoryController.Index(): {Message}", ex.Message);
                return View("Error");
            }
        }

        public IActionResult Add()
        {
            try
            {
                return View();
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Błąd CategoryController.Add(): {Message}", ex.Message);
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            try
            {
                if(!ModelState.IsValid)
                    return View("Error");
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Błąd CategoryController.Add(Category category): {Message}", ex.Message);
                return View("Error");
            }
        }
    }
}