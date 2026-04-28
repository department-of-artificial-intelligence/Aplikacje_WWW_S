using DAL;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Web.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly AppDbContext _context;
        public EquipmentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Equipment.ToList());

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _context.Equipment.Add(equipment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(equipment);
        }
    }
}
