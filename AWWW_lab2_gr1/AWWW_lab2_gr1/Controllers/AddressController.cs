using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace YourProjectName.Controllers
{
    public class AddressController : Controller
    {
        private readonly AppDbContext _context;

        public AddressController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var addresses = _context.Addresses
                .Include(a => a.Customer)
                .ToList();

            return View(addresses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Address address)
        {
            if (!_context.Customers.Any(c => c.Id == address.CustomerId))
            {
                ModelState.AddModelError("CustomerId", "Klient o podanym ID nie istnieje.");
            }

            if (!ModelState.IsValid)
                return View(address);

            _context.Addresses.Add(address);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}