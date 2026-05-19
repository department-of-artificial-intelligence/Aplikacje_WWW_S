using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;

namespace Web.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() 
        { 
            return View(_context.Events.ToList()); 
        }

        public IActionResult Create()
        {
            ViewBag.EventTypeId = new SelectList(_context.EventsType, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(@event);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.EventTypeId = new SelectList(_context.EventsType, "Id", "Name", @event.EventTypeId);
            return View(@event);
        }
    }
}
