using AWWW_lab2_gr1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AWWW_lab2_gr1.Models;
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

        public IActionResult Index()
        {
            var orders = _context.Orders.Include(o => o.OrderStatus).ToList();
            return View(orders);
        }

        public IActionResult Edit(int id)
        {
            var order = _context.Orders.Find(id);

            ViewBag.Statuses = new SelectList(_context.OrderStatuses, "Id", "Name");

            return View(order);
        }

        public IActionResult Details(int id)
        {
            var order = _context.Orders.Include(o => o.OrderStatus).Include(o => o.OrderStatusHistories).ThenInclude(h => h.OrderStatus).FirstOrDefault(o => o.Id == id);

            return View(order);
        }
        [HttpPost]
        public IActionResult Edit(int id, int newStatusId)
        {
            var order = _context.Orders.Find(id);

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
    }
}
