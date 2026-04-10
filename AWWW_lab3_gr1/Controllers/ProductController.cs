using Microsoft.AspNetCore.Mvc;
using AWWW_lab3_gr1.Models;
using Microsoft.EntityFrameworkCore; // potrzeben do include

namespace AWWW_lab3_gr1.ProductController
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ProductController(AppDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            var products = _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Tags).ToList();

            return View(products);
        }

        public IActionResult Add()
        {
            var vm = new ProductCreateViewModel
            {
                Categories = _dbContext.Categories.ToList(),
                Tags = _dbContext.Tags.ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(ProductCreateViewModel vm)
        {
            var product = new Product
            {
                Name = vm.Name,
                Price = vm.Price,
                CategoryId = vm.CategoryId
            };

            product.Tags = _dbContext.Tags
                .Where(t => vm.SelectedTagIds.Contains(t.Id))
                .ToList();

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}