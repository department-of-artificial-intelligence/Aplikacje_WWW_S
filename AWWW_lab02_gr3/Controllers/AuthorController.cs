using AWWW_lab02_gr3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab02_gr3.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger _logger;
        public AuthorController(AppDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index(int id)
        {
            try
            {
                var authors = _dbContext.Authors.ToList();
                return View(authors);
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Błąd w AuthorController.Index(): {Message}",ex.Message);
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
                _logger.LogError(ex, "Błąd w AuthorController.Add(): {Message}", ex.Message);
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Add(Author author)
        {
            try
            {
                if(!ModelState.IsValid)
                    return View("Error");
                _dbContext.Authors.Add(author);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Błąd w AuthorController.Add: {Message}", ex.Message);
                return View("Error");
            }
        }
    }
}