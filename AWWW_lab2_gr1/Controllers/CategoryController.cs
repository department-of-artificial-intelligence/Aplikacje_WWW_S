using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Data;
using AWWW_lab2_gr1.Models;

namespace AWWW_lab2_gr1.Controllers;

public class CategoryController : Controller
{
    private readonly AppDbContext _context;
    public CategoryController(AppDbContext context) { _context = context; }

    // Wyświetlanie listy
    public IActionResult Index() => View(_context.Categories.ToList());

    // Formularz dodawania
    public IActionResult Create() => View();

    // Zapis do bazy
    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }
}