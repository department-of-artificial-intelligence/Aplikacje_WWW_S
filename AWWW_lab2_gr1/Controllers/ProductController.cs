using AWWW_lab2_gr1.Data;
using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc;
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
            var products = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.Tags = new MultiSelectList(_context.Tags, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product, int[] selectedTagIds)
        {
            if (ModelState.IsValid)
            {

                if (selectedTagIds != null && selectedTagIds.Any())
                {
                    product.Tags = _context.Tags.Where(t => selectedTagIds.Contains(t.Id)).ToList();
                }

                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewBag.Tags = new MultiSelectList(_context.Tags, "Id", "Name", selectedTagIds);
            return View(product);
        }
    }
}