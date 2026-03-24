using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr1.Models;

namespace AWWW_lab2_gr1.Controllers;

public class OrderController : Controller
{
    private readonly AppDbContext _context;

    public OrderController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Order
    public IActionResult Index()
    {
        var orders = _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderStatus)
            .OrderByDescending(o => o.CreatedAt)
            .ToList();

        return View(orders);
    }

    // GET: Order/Details/5
    public IActionResult Details(int id)
    {
        var order = _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderStatus)
            .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
            .Include(o => o.OrderStatusHistory).ThenInclude(h => h.OrderStatus)
            .FirstOrDefault(o => o.Id == id);

        if (order == null)
            return NotFound();

        return View(order);
    }

    // GET: Order/Create
    public IActionResult Create()
    {
        var customers = _context.Customers
            .OrderBy(c => c.Id)
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
            .ToList();

        ViewBag.Customers = customers;
        return View();
    }

    // POST: Order/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(int customerId)
    {
        var customer = _context.Customers.Find(customerId);
        if (customer == null)
        {
            ModelState.AddModelError("", "Klient nie istnieje");
            var customers = _context.Customers
                .OrderBy(c => c.Id)
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .ToList();
            ViewBag.Customers = customers;
            return View();
        }

        var order = new Order
        {
            CustomerId = customerId,
            CreatedAt = DateTime.Now,
            OrderStatusId = 1 // "New" status
        };

        _context.Orders.Add(order);
        _context.SaveChanges();

        // Register initial status in history
        var history = new OrderStatusHistory
        {
            OrderId = order.Id,
            OrderStatusId = 1,
            ChangedAt = DateTime.Now
        };
        _context.OrderStatusHistories.Add(history);
        _context.SaveChanges();

        return RedirectToAction(nameof(Details), new { id = order.Id });
    }

    // GET: Order/AddItem/5
    public IActionResult AddItem(int orderId)
    {
        var order = _context.Orders.Find(orderId);
        if (order == null)
            return NotFound();

        var products = _context.Products
            .OrderBy(p => p.Name)
            .ToList();

        ViewBag.OrderId = orderId;
        ViewBag.Products = new SelectList(products, "Id", "Name");
        return View();
    }

    // POST: Order/AddItem
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddItem(int orderId, int productId, int quantity)
    {
        var order = _context.Orders.Find(orderId);
        if (order == null)
            return NotFound();

        var product = _context.Products.Find(productId);
        if (product == null)
        {
            ModelState.AddModelError("", "Produkt nie istnieje");
            return RedirectToAction(nameof(AddItem), new { orderId });
        }

        if (quantity <= 0)
        {
            ModelState.AddModelError("", "Ilość musi być większa niż 0");
            return RedirectToAction(nameof(AddItem), new { orderId });
        }

        var orderItem = new OrderItem
        {
            OrderId = orderId,
            ProductId = productId,
            Quantity = quantity,
            UnitPrice = product.Price
        };

        _context.OrderItems.Add(orderItem);
        _context.SaveChanges();

        return RedirectToAction(nameof(Details), new { id = orderId });
    }

    // GET: Order/ChangeStatus/5
    public IActionResult ChangeStatus(int orderId)
    {
        var order = _context.Orders
            .Include(o => o.OrderStatus)
            .FirstOrDefault(o => o.Id == orderId);

        if (order == null)
            return NotFound();

        var statuses = _context.OrderStatuses
            .OrderBy(s => s.Id)
            .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
            .ToList();

        ViewBag.OrderId = orderId;
        ViewBag.CurrentStatusId = order.OrderStatusId;
        ViewBag.Statuses = statuses;
        return View();
    }

    // POST: Order/ChangeStatus
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ChangeStatus(int orderId, int newStatusId)
    {
        var order = _context.Orders
            .Include(o => o.OrderStatus)
            .FirstOrDefault(o => o.Id == orderId);

        if (order == null)
            return NotFound();

        var newStatus = _context.OrderStatuses.Find(newStatusId);
        if (newStatus == null)
        {
            ModelState.AddModelError("", "Status nie istnieje");
            return RedirectToAction(nameof(ChangeStatus), new { orderId });
        }

        if (order.OrderStatusId == newStatusId)
        {
            ModelState.AddModelError("", "Nowy status jest taki sam jak bieżący");
            return RedirectToAction(nameof(ChangeStatus), new { orderId });
        }

        // Update order status
        order.OrderStatusId = newStatusId;

        // Register status change in history
        var history = new OrderStatusHistory
        {
            OrderId = orderId,
            OrderStatusId = newStatusId,
            ChangedAt = DateTime.Now
        };

        _context.OrderStatusHistories.Add(history);
        _context.SaveChanges();

        return RedirectToAction(nameof(Details), new { id = orderId });
    }

    // POST: Order/DeleteItem/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteItem(int itemId, int orderId)
    {
        var orderItem = _context.OrderItems.Find(itemId);
        if (orderItem == null)
            return NotFound();

        _context.OrderItems.Remove(orderItem);
        _context.SaveChanges();

        return RedirectToAction(nameof(Details), new { id = orderId });
    }

    // POST: Order/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
            return NotFound();

        _context.Orders.Remove(order);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}
