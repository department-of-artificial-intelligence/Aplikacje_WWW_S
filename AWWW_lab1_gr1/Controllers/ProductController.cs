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
            .OrderBy(p => p.Name)
            .ToListAsync();

        return View(products);
    }

    public IActionResult Create()
    {
        try
        {
            ViewBag.CategoryId = new SelectList(_db.Categories, "Id", "Name");
            
            ViewBag.Tags = _db.Tags.ToList();
            
            return View();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Błąd podczas ładowania formularza dodawania produktu.");
            throw;
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Price,CategoryId")] Product product, List<int> selectedTagsIds)
    {
        try
        {            if (!ModelState.IsValid)
            {
                ViewBag.CategoryId = new SelectList(_db.Categories, "Id", "Name", product.CategoryId);
                ViewBag.Tags = _db.Tags.ToList();
                return View(product);
            }
            product.Tags = new List<Tag>();
            if (selectedTagsIds != null && selectedTagsIds.Any())
            {
                var tags = await _db.Tags.Where(t => selectedTagsIds.Contains(t.Id)).ToListAsync();
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
            _logger.LogError(ex, "Błąd podczas zapisywania produktu.");
            throw;
        }
    }
}