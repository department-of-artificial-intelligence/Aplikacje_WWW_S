using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr2.Controllers
{
    public class EventTypeController : Controller
    {
        private readonly MyDbContext _dbContext;

        public EventTypeController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int id)
        {
            var eventtype = _dbContext.EventType.FirstOrDefault(a => a.Id == id);
            if (eventtype != null)
                return View(eventtype);
            return View("Error");
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EventType eventtype)
        {
            _dbContext.EventType.Add(eventtype); 
            _dbContext.SaveChanges();
            return View("Added",eventtype); 
        }
    }
}
