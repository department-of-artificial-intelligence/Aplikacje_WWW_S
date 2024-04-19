using Kolokwium.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allClients = _context.Clients.Include(c => c.Orders).ToList();
            return View(allClients);
        }

        public IActionResult AddClient()
        {
            var orders = _context.Orders.ToList();
            var ordersList = new SelectList(orders, "Id", "Description");
            ViewBag.ordersList = ordersList;
            return View();
        }

        [HttpPost]
        public IActionResult AddClient(Client client, List<int> orders)
        {
            foreach (var order in orders)
            {
                var orderToAdd = _context.Orders.Find(order);
                client.Orders.Add(orderToAdd);
            }
            _context.Clients.Add(client);
            _context.SaveChanges();

            var allClients = _context.Clients.Include(c => c.Orders).ToList();
            return View("Index", allClients);
        }
    }
}
