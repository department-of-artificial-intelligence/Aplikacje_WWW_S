using Kolokwium.Data;
using Kolokwium.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AppDbContext _context;

        public ReservationController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var reservation = _context.Reservations.Include(r => r.Hotel).Include(r => r.Room).ToList();
            return View(reservation);
        }

        public IActionResult Edit(int id)
        {
            var reservation = _context.Reservations.Find(id);

            ViewBag.RoomId = new SelectList(_context.Rooms, "Id", "Number", reservation.RoomId);
            ViewBag.HotelId = new SelectList(_context.Hotels, "Id", "Name", reservation.HotelId);

            return View(reservation);
        }

        [HttpPost]
        public IActionResult Edit(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
