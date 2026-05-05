using AWWW_lab1_gr1.Data;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Controllers;

public class ProductController : Controller
{
    private readonly CompanyDbContext _db;
    private readonly ILogger<ProductController> _logger;

    public ProductController(CompanyDbContext db, ILogger<ProductController> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _db.Products
            .Include(p => p.Category)
            .Include(p => p.Tags)
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .ToListAsync();

        return View(products);
    }

    public IActionResult Create()
    {
        LoadFormData();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Price,CategoryId")] Product product, List<int>? selectedTagsIds)
    {
        if (!ModelState.IsValid)
        {
            LoadFormData(product.CategoryId, selectedTagsIds);
            return View(product);
        }

        try
        {
            product.Name = product.Name.Trim();
            product.Tags = new List<Tag>();
            if (selectedTagsIds is { Count: > 0 })
            {
                var tags = await _db.Tags
                    .Where(t => selectedTagsIds.Contains(t.Id))
                    .ToListAsync();

                foreach (var tag in tags)
                {
                    product.Tags.Add(tag);
                }
            }

            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Blad podczas zapisywania produktu.");
            throw;
        }
    }

    public async Task<IActionResult> Edit(int id)
    {
        var product = await _db.Products
            .Include(p => p.Tags)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
        {
            return NotFound();
        }

        LoadFormData(product.CategoryId, product.Tags.Select(t => t.Id).ToList());
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,CategoryId")] Product formProduct, List<int>? selectedTagsIds)
    {
        if (id != formProduct.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            LoadFormData(formProduct.CategoryId, selectedTagsIds);
            return View(formProduct);
        }

        var product = await _db.Products
            .Include(p => p.Tags)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
        {
            return NotFound();
        }

        product.Name = formProduct.Name.Trim();
        product.Price = formProduct.Price;
        product.CategoryId = formProduct.CategoryId;

        product.Tags.Clear();
        if (selectedTagsIds is { Count: > 0 })
        {
            var tags = await _db.Tags
                .Where(t => selectedTagsIds.Contains(t.Id))
                .ToListAsync();

            foreach (var tag in tags)
            {
                product.Tags.Add(tag);
            }
        }

        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _db.Products
            .Include(p => p.OrderItems)
            .Include(p => p.Reviews)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
        {
            return RedirectToAction(nameof(Index));
        }

        if (product.OrderItems.Any() || product.Reviews.Any())
        {
            TempData["ErrorMessage"] = "Nie mozna usunac produktu, poniewaz jest powiazany z zamowieniami lub opiniami.";
            return RedirectToAction(nameof(Index));
        }

        _db.Products.Remove(product);
        await _db.SaveChangesAsync();
        TempData["SuccessMessage"] = "Produkt zostal usuniety.";

        return RedirectToAction(nameof(Index));
    }

    private void LoadFormData(int? selectedCategoryId = null, IEnumerable<int>? selectedTagIds = null)
    {
        ViewBag.CategoryId = new SelectList(_db.Categories.OrderBy(c => c.Name), "Id", "Name", selectedCategoryId);
        ViewBag.Tags = _db.Tags
            .OrderBy(t => t.Name)
            .ToList();
        ViewBag.SelectedTagIds = (selectedTagIds ?? []).ToHashSet();
    }
}