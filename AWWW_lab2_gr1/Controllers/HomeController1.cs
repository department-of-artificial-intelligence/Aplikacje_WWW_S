using AWWW_lab2_gr1.Data;
using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var orders = _context.Orders
                .Include(o => o.OrderStatus)
                .ToList();
            return View(orders);
        }

        public IActionResult Details(int id)
        {
            var order = _context.Orders
                .Include(o => o.OrderStatus)
                .Include(o => o.StatusHistories) 
                    .ThenInclude(h => h.OrderStatus) 
                .FirstOrDefault(o => o.Id == id);

            if (order == null) return NotFound();

            order.StatusHistories = order.StatusHistories.OrderByDescending(h => h.ChangedAt).ToList();

            return View(order);
        }

        public IActionResult EditStatus(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return NotFound();

            ViewBag.Statuses = new SelectList(_context.OrderStatuses, "Id", "Name", order.OrderStatusId);
            return View(order);
        }

        [HttpPost]
        public IActionResult EditStatus(int id, int OrderStatusId)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return NotFound();


            if (order.OrderStatusId != OrderStatusId)
            {
                order.OrderStatusId = OrderStatusId;

                var historyEntry = new OrderStatusHistory
                {
                    OrderId = order.Id,
                    OrderStatusId = OrderStatusId,
                    ChangedAt = DateTime.Now 
                };

                _context.OrderStatusHistories.Add(historyEntry);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}