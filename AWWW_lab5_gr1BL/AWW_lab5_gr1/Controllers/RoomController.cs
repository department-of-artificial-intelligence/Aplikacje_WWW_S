using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Web.Controllers
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
           var rooms = _context.Rooms.Include(r => r.Building).ToList();
           return View(rooms);
        }
        public IActionResult Create()
        {
            ViewBag.BuildingId = new SelectList(_context.Buildings, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Rooms.Add(room);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.BuildingId = new SelectList(_context.Buildings, "Id", "Name", room.BuildingId);
            return View(room);
        }
    }
}
