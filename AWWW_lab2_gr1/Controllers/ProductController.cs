using AWWW_lab2_gr1.Data;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab2_gr1.Controllers
{
	public class ProductController : Controller
	{
		private readonly AppDbContext _context;

		public ProductController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View(_context.Categories.ToList());
		}

		public IActionResult Create()
		{
			ViewBag.Categories = new SelectList(_context.Categories,"Id","Name");
			return View();
		}

		[HttpPost]
		public IActionResult Create(Product product)
		{
			_context.Products.Add(product);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}


}
