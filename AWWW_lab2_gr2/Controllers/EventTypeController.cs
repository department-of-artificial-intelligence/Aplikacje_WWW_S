using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr2.Models;

namespace AWWW_lab2_gr2.Controllers
{
	public class CategoryController : Controller
	{
		private readonly MyDbContext _context;

		public CategoryController(MyDbContext context)
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
		public IActionResult Add(Category category)
		{
			_context.Categories.Add(category);
			_context.SaveChanges();
			return View("Added", category);
		}
	}
}

