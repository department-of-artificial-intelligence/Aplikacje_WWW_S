using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AWWW_lab02_gr3.Models;

namespace AWWW_lab02_gr3.Controllers
{
    public class TagController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger _logger;

        public TagController(AppDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var tags = _dbContext.Tags.ToList();
                return View(tags);
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Błąd w TagController.Index(): {Message}", ex.Message);
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
                _logger.LogError(ex, "Błąd w TagController.Add(): {Message}", ex.Message);
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            try
            {
                if(!ModelState.IsValid)
                    return View("Error");
                _dbContext.Tags.Add(tag);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Błąd w TagController.Add(Tag tag): {Message}", ex.Message);
                return View("Error");
            }
        }
    }
}