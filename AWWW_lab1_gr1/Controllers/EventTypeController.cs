using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
    public class EventTypeController : Controller
    {
        private readonly LabDbContext _dbContext;

        public EventTypeController(LabDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var eventType = _dbContext.EventTypes!.ToList(); 
            return View(eventType);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EventType eventType)
        {
            if (ModelState.IsValid)
            {
                _dbContext.EventTypes.Add(eventType);
                _dbContext.SaveChanges();
                return View("Added", eventType);
            }
            return View("Error");
        }
    }
}