using Microsoft.AspNetCore.Mvc;
using Kolokwium.Models;

namespace Kolokwium.Controllers
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
            var addresses = _context.Addresses.ToList();
            return View(addresses);
        }
    }
}
