using Kolokwium.Data;
using Kolokwium.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Controllers
{
    public class HotelController : Controller
    {
        private readonly AppDbContext _context;

        public HotelController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Hotels.ToList());
        }

        public IActionResult Details(int id)
        {
            var hotel = _context.Hotels.Include(h => h.Rooms).FirstOrDefault(h => h.Id == id);

            return View(hotel);
        }

        public IActionResult Delete(int id)
        {
            var hotel = _context.Hotels.Find(id);

            _context.Hotels.Remove(hotel);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
