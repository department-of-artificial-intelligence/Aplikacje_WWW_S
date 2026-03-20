using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Models;
using AWWW_lab2_gr1.Data;

namespace AWWW_lab2_gr1.Controllers
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
            return View(_context.Addresses.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
