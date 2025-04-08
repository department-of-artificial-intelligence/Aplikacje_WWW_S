using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

namespace AWWW_lab2_gr3.Controllers {
    public class EventTypeController : Controller {

        private readonly MyDbContext _dbContext;

        public EventTypeController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index() {
            var eventTypes = _dbContext.EventTypes.ToList();
            return View(eventTypes);
        }

        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(EventType eventType)
        {
            if (eventType == null){
                return View("Error");
            }
            _dbContext.EventTypes.Add(eventType);
            try {
                _dbContext.SaveChanges();
            } catch (Exception ex) {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}
