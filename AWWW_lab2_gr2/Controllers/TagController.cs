using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr2.Models;

namespace AWWW_lab2_gr2.Controllers
{
	public class TagController : Controller
	{
		private readonly MyDbContext _context;
		public TagController(MyDbContext context)
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
		public IActionResult Add(Tag tag)
		{
			_context.Tags.Add(tag);
			_context.SaveChanges();
			return View("Added", tag);
		}
	}
}