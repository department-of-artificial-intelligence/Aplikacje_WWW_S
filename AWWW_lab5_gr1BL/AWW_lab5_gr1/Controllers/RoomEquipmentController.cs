using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;

namespace Web.Controllers
{
    public class RoomEquipmentController : Controller
    {

        private readonly AppDbContext _context;
        public RoomEquipmentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.RoomId = new SelectList(_context.Rooms, "Id", "Name");
            ViewBag.EquipmentId = new SelectList(_context.Equipment, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomEquipment re)
        {
            if (ModelState.IsValid)
            {
                _context.RoomsEquipment.Add(re);
                _context.SaveChanges();
                return RedirectToAction("Index", "Rooms"); 
            }
            return View(re);
        }
    }
}
