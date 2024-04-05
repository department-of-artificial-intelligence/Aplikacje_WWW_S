using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Controllers
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
            var eventTypes = _dbContext.EventTypes!.ToList(); 
            return View(eventTypes);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EventType eventType)
        {
            _dbContext.EventTypes!.Add(eventType); 
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        


    }
}