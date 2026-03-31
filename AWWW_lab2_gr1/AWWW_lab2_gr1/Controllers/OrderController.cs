using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr1.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult EditStatus(int id)
        {
            var order = _context.Orders
                .Include(o => o.OrderStatus)
                .FirstOrDefault(o => o.Id == id);

            ViewBag.Statuses = _context.OrderStatuses.ToList();

            return View(order);
        }

        [HttpPost]
        public IActionResult EditStatus(int id, int newStatusId)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);

            order.OrderStatusId = newStatusId;

            var history = new OrderStatusHistory
            {
                OrderId = order.Id,
                OrderStatusId = newStatusId,
                ChangedAt = DateTime.Now
            };

            _context.OrderStatusHistories.Add(history);

            _context.SaveChanges();

            return RedirectToAction("Details", new { id = order.Id });
        }

        public IActionResult Details(int id)
        {
            var order = _context.Orders
                .Include(o => o.OrderStatus)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Include(o => o.OrderStatusHistories)
                .ThenInclude(h => h.OrderStatus)
                .FirstOrDefault(o => o.Id == id);

            return View(order);
        }

        public IActionResult Index()
        {
            var orders = _context.Orders
                .Include(o => o.OrderStatus)
                .Include(o => o.Customer)
                .ToList();

            return View(orders);
        }
    }
}
