using AWWW_lab02_gr3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace AWWW_lab02_gr3.Controllers
{
    public class EventTypeController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger _logger;

        public EventTypeController(AppDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var eventTypes = _dbContext.EventTypes.ToList();
                return View(eventTypes);
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Błąd w EventTypeController.Index(): {Message}", ex.Message);
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
                _logger.LogError(ex, "Błąd w EventTypeController.Add(): {Message}", ex.Message);
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Add(EventType eventType)
        {
            
        }
    }
}