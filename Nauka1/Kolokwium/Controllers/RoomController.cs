using Kolokwium.Data;
using Kolokwium.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kolokwium.Controllers
{
    public class RoomController : Controller
    {
        private readonly AppDbContext _context;

        public RoomController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Rooms.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Hotels = new SelectList(_context.Hotels, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
