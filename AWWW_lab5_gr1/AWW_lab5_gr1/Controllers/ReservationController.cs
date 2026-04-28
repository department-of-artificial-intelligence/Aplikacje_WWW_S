using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using Services.Interfaces;

namespace Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _resService;
        private readonly AppDbContext _context;

        public ReservationController(IReservationService resService, AppDbContext context)
        {
            _resService = resService;
            _context = context;
        }

        public IActionResult Index()
        {
            return  View(_resService.GetAll());
        }
        public IActionResult Create()
        {
            ViewBag.RoomId = new SelectList(_context.Rooms, "Id", "Name");
            ViewBag.EventId = new SelectList(_context.Events, "Id", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Reservation res)
        {
            var error = _resService.ValidateAndCreate(res);

            if (error == null) return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", error);
            ViewBag.RoomId = new SelectList(_context.Rooms, "Id", "Name", res.RoomId);
            ViewBag.EventId = new SelectList(_context.Events, "Id", "Title", res.EventId);
            return View(res);
        }
    }
}
