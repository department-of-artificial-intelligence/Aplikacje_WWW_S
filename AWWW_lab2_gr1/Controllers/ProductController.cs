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


        public IActionResult Edit(int id)
        {
            var product = _context.Products.Include(p => p.Tags).FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            var selectedTagIds = product.Tags.Select(t => t.Id).ToArray();
            ViewBag.Tags = new MultiSelectList(_context.Tags, "Id", "Name", selectedTagIds);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, Product product, int[] selectedTagIds)
        {
            if (id != product.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var productToUpdate = _context.Products.Include(p => p.Tags).FirstOrDefault(p => p.Id == id);
                if (productToUpdate == null) return NotFound();

                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                productToUpdate.CategoryId = product.CategoryId;

                productToUpdate.Tags.Clear();
                if (selectedTagIds != null && selectedTagIds.Any())
                {
                    productToUpdate.Tags = _context.Tags.Where(t => selectedTagIds.Contains(t.Id)).ToList();
                }

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}