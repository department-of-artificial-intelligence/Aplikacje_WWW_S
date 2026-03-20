using AWWW_lab2_gr1.Data;
using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AWWW_lab2_gr1.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _context;

		public HomeController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var categories = _context.Categories.ToList();
			return View(categories);
		}
	}
}
