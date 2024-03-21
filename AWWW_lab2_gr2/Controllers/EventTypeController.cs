using AWWW_lab2_gr2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr2.Controllers
{
	public class EventTypeController : Controller
	{
		private readonly MyDbContext _context;
		public EventTypeController(MyDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(EventType eventType)
		{
			_context.EventTypes.Add(eventType);
			_context.SaveChanges();
			return View("Added", eventType);
		}
	}
}