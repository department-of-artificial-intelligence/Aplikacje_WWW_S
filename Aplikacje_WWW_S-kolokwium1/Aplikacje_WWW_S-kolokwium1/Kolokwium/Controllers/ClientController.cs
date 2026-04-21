using Kolokwium.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kolokwium.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kolokwium.Controllers
{
	public class ClientController : Controller
	{
		private readonly AppDbContext _context;

		public ClientController(AppDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View(_context.Clients.ToList());
		}

		public IActionResult AddClient()
		{
            ViewBag.Orders = _context.Orders.ToList();
            return View();
		}

		[HttpPost]
		public IActionResult AddClient(Client client,int[] selectedOrders)
        {
            client.Orders = _context.Orders.Where(o => selectedOrders.Contains(o.Id)).ToList();
            _context.Clients.Add(client);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
