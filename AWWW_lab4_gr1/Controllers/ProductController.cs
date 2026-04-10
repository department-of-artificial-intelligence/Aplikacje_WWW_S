using Microsoft.AspNetCore.Mvc;
using AWWW_lab4_gr1.Models;
using Microsoft.EntityFrameworkCore; // potrzeben do include

namespace AWWW_lab4_gr1.ProductController
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

        [HttpGet]
        public IActionResult Edit(int id) //produkt do edycji
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            var vm = new ProductCreateViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,

                Categories = _dbContext.Categories.ToList(),
                Tags = _dbContext.Tags.ToList()
            };

            return View(vm);
        }


        [HttpPost]
        public IActionResult Edit(ProductCreateViewModel vm)//zapisanie zmian
        {
            var product = _dbContext.Products
                .Include(p => p.Tags)
                .FirstOrDefault(p => p.Id == vm.Id);

            if (product == null)
                return NotFound();

            product.Name = vm.Name;
            product.Price = vm.Price;
            product.CategoryId = vm.CategoryId;

            product.Tags = _dbContext.Tags
                .Where(t => vm.SelectedTagIds.Contains(t.Id))
                .ToList();

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)//do usuniecia
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(ProductCreateViewModel vm)//zapisane zmiany
        {
            var product = _dbContext.Products.Find(vm.Id);

            if (product == null)
                return NotFound();

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }


}