using AWWW_lab1_gr1.Data;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr1.Controllers
{
    public class EventTypeController : Controller
    {
        private readonly MyDBContext _dbContext;

        public EventTypeController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<EventType> events = _dbContext.EventTypes!.ToList();
            return View(events);
        }

        public IActionResult Details(int id)
        {
            EventType? eventType = _dbContext.EventTypes.FirstOrDefault(a => a.Id == id);
            return View(eventType);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EventType entity)
        {
            if(ModelState.IsValid)
            {
                _dbContext.Add(entity);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
