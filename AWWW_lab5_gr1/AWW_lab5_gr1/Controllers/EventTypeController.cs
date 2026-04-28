using DAL;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Web.Controllers
{
    public class EventTypeController : Controller
    {
        private readonly AppDbContext _context;
        public EventTypeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           return  View(_context.EventsType.ToList());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(EventType type)
        {
            if (ModelState.IsValid)
            {
                _context.EventsType.Add(type);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(type);
        }
    }
}
