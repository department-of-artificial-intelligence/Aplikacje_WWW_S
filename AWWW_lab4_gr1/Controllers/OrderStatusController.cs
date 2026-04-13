using Microsoft.AspNetCore.Mvc;
using AWWW_lab4_gr1.Models;

namespace AWWW_lab4_gr1.Controllers
{
    public class OrderStatusController : Controller
    {
        private readonly AppDbContext _dbContext;

        public OrderStatusController(AppDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index(int id)
        {
            var status = _dbContext.OrderStatuses.Find(id);
            return View(status);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(OrderStatus orderStatus)
        {
            _dbContext.OrderStatuses.Add(orderStatus);
            _dbContext.SaveChanges();
            return View("Added", orderStatus);
        }
    }
}
