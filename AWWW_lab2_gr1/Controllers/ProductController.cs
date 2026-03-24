using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr1.Data;
using AWWW_lab2_gr1.Models;

namespace AWWW_lab2_gr1.Controllers;

public class ProductController : Controller
{
    private readonly AppDbContext _context;
    public ProductController(AppDbContext context) { _context = context; }

    // Wyświetlanie listy produktów
    public IActionResult Index()
    {
        var products = _context.Products
            .Include(p => p.Category)
            .Include(p => p.Tags)
            .ToList();
        return View(products);
    }

    // Formularz dodawania produktu
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
        ViewBag.Tags = new MultiSelectList(_context.Tags, "Id", "Name");
        return View();
    }

    // Zapis do bazy
    [HttpPost]
    public IActionResult Create(Product product, int[] selectedTagIds)
    {
        if (ModelState.IsValid)
        {
            product.Tags = new List<Tag>();
            if (selectedTagIds != null && selectedTagIds.Any())
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

        ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
        ViewBag.Tags = new MultiSelectList(_context.Tags, "Id", "Name", selectedTagIds);
        return View(product);
    }
}