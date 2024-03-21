using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr2.Models;

namespace AWWW_lab2_gr2.Controllers
{
	public class PositionController : Controller
	{
		private readonly MyDbContext _context;
		public PositionController(MyDbContext context)
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
		public IActionResult Add(Position position)
		{
			_context.Positions.Add(position);
			_context.SaveChanges();
			return View("Added", position);
		}
	}
}