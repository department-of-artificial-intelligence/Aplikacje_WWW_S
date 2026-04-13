using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AWWW_lab3_gr1.Data;
using AWWW_lab3_gr1.Models;
using AWWW_lab3_gr1.ViewModels;

namespace AWWW_lab3_gr1.Controllers
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

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new ProductCreateViewModel
            {
                Categories = _context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList(),

                Tags = _context.Tags
                    .Select(t => new SelectListItem
                    {
                        Value = t.Id.ToString(),
                        Text = t.Name
                    }).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateViewModel vm)
        {
            var product = new Product
            {
                Name = vm.Name,
                Price = vm.Price,
                CategoryId = vm.CategoryId
            };

            if (vm.SelectedTagIds != null && vm.SelectedTagIds.Any())
            {
                var selectedTags = _context.Tags
                    .Where(t => vm.SelectedTagIds.Contains(t.Id))
                    .ToList();

                product.Tags = selectedTags;
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}