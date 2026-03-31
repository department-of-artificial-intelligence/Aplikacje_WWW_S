using AWWW_lab2_gr1.Data;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
			var products = _context.Products.Include(p => p.Category).Include(p => p.Tags).ToList();


			return View(products);
		}


		public IActionResult Create()
		{
			ViewBag.Categories = new SelectList(_context.Categories,"Id","Name");
            ViewBag.Tags = _context.Tags.ToList();

            return View();
		}

		public IActionResult Edit(int id)
		{
			var product = _context.Products.Include(p => p.Tags).FirstOrDefault(p => p.Id == id);

			ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
			ViewBag.Tags = _context.Tags.ToList();	

			return View(product);
		}

		public IActionResult Delete(int id)
		{
			var product = _context.Products.Find(id);

			_context.Products.Remove(product);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}


		[HttpPost]
		public IActionResult Create(Product product,int[] selectedTags)
		{
			product.Tags = _context.Tags.Where( t => selectedTags.Contains(t.Id)).ToList();

			_context.Products.Add(product);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Edit(Product product, int[] selectedTags) 
		{
			var existing = _context.Products.Include(_p => _p.Tags).FirstOrDefault(p => p.Id == product.Id);

			existing.Name = product.Name;
			existing.Price = product.Price;
			existing.CategoryId = product.CategoryId;

			existing.Tags = _context.Tags.Where(t => selectedTags.Contains(t.Id)).ToList();

			_context.SaveChanges();

			return RedirectToAction("Index");

		}
	}


}
