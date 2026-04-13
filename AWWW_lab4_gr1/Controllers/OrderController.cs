using Microsoft.AspNetCore.Mvc;
using AWWW_lab4_gr1.Models;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab4_gr1.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _dbContext;

        public OrderController(AppDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult List()
        {
            var orders = _dbContext.Orders
            .Include(o => o.OrderStatus).ToList();

            return View(orders);
        }

        public IActionResult Index(int id)
        {
            var order = _dbContext.Orders.Find(id);
            return View(order);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Order order)
        {
            order.CreatedAt = DateTime.Now;

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return View("Added", order);
        }


        [HttpGet]
        public IActionResult Edit(int id) //produkt do edycji
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == id);

            if (order == null)
                return NotFound();

            return View(order);
        }


        [HttpPost]
        public IActionResult Edit(Order order)//zapisanie zmian
        {
            var existingOrder = _dbContext.Orders.FirstOrDefault(o => o.Id == order.Id);

            if (existingOrder == null)
                return NotFound();

            existingOrder.OrderStatusId = order.OrderStatusId;

            _dbContext.SaveChanges();

            return RedirectToAction("List");
        }

    }
}
