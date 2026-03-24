using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Models;

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
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList(); //W create.cshtml jest foreach i dlatego musi byc tak, lista bo kategorii 
            ViewBag.Tags = _context.Categories.ToList();
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
    }
}
