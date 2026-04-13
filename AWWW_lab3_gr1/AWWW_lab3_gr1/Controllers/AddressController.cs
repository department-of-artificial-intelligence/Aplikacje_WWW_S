using AWWW_lab3_gr1.Data;
using AWWW_lab3_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab3_gr1.Controllers
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

    }
}
