using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr1.Data;
using AWWW_lab2_gr1.Models; 

public class CategoryController : Controller
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    // Wyświetlanie listy (GET)
    public async Task<IActionResult> Index()
    {
        return View(await _context.Categories.ToListAsync());
    }

    // Wyświetlanie formularza dodawania (GET)
    public IActionResult Create()
    {
        return View();
    }

    // Obsługa zapisu z formularza (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name")] Category category)
    {
        if (ModelState.IsValid)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }
}