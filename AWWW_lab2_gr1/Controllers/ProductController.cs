using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr1.Models;

namespace AWWW_lab2_gr1.Controllers;

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
            .OrderBy(p => p.Id)
            .ToList();

        return View(products);
    }

    public IActionResult Create()
    {
        var viewModel = new ProductCreateViewModel
        {
            Categories = BuildCategorySelectList(),
            Tags = BuildTagSelectList()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ProductCreateViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Categories = BuildCategorySelectList();
            viewModel.Tags = BuildTagSelectList();
            return View(viewModel);
        }

        var product = new Product
        {
            Name = viewModel.Name,
            Price = viewModel.Price,
            CategoryId = viewModel.CategoryId!.Value
        };

        var selectedTagIds = viewModel.SelectedTagIds.Distinct().ToList();
        if (selectedTagIds.Count > 0)
        {
            var selectedTags = _context.Tags
                .Where(t => selectedTagIds.Contains(t.Id))
                .ToList();

            foreach (var tag in selectedTags)
            {
                product.Tags.Add(tag);
            }
        }

        _context.Products.Add(product);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    private List<SelectListItem> BuildCategorySelectList()
    {
        return _context.Categories
            .OrderBy(c => c.Name)
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            })
            .ToList();
    }

    private List<SelectListItem> BuildTagSelectList()
    {
        return _context.Tags
            .OrderBy(t => t.Name)
            .Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name
            })
            .ToList();
    }
}