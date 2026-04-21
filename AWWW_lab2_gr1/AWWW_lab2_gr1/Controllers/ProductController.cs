using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc;
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
            ViewBag.Categories = _context.Categories.ToList(); //W create.cshtml jest foreach i dlatego musi byc tak, lista bo kategorii 
            ViewBag.Tags = _context.Tags.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product, List<int> selectedTags)
        {
            var tags = _context.Tags
                .Where(t => selectedTags.Contains(t.Id))
                .ToList();

            product.Tags = tags;
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _context.Products
                .Include(p => p.Tags)
                .FirstOrDefault(p => p.Id == id);

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product, List<int> selectedTags)
        {
            var existingProduct = _context.Products
                .Include(p => p.Tags)
                .FirstOrDefault(p => p.Id == product.Id);

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.CategoryID = product.CategoryID;

            //aktualizacja tagow
            existingProduct.Tags.Clear();
            var tags = _context.Tags
                .Where(t => selectedTags.Contains(t.Id))
                .ToList();

            existingProduct.Tags = tags;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
