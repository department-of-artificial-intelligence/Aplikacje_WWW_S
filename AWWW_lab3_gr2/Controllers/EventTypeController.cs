using AWWW_lab3_gr2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AWWW_lab3_gr2.Controllers
{
    public class EventTypeController : Controller
    {
        private readonly MyDbContext _dbContext;

        public EventTypeController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var eventTypes = _dbContext.EventType.ToList();
            return View(eventTypes);
        }

        public IActionResult Details(int id)
        {
            var eventType = _dbContext.EventType.FirstOrDefault(a => a.Id == id);
            if (eventType != null)
                return View(eventType);
            return View("Error");
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
                _dbContext.EventType.Add(eventType);
                _dbContext.SaveChanges();
                return View("Added", eventType);
            }
            return View();
        }
    }
}