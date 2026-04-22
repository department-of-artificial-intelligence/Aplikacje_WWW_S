using Kolokwium.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }

        public IActionResult AddOrder()
        {
            ViewBag.Addresses = _context.Addresses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddOrder(Order order, Address address)
        {
            var addresses = _context.Addresses.ToList();
            order.AddressId = address.Id;

            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


