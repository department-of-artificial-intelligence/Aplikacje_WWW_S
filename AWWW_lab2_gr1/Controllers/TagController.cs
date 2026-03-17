using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr1.Data;
using AWWW_lab2_gr1.Models;

namespace AWWW_lab2_gr1.Controllers;

public class TagController : Controller
{
    private readonly AppDbContext _context;

    public TagController(AppDbContext context)
    {
        _context = context;
    }

    // Wyświetlanie listy tagów
    public async Task<IActionResult> Index()
    {
        return View(await _context.Tags.ToListAsync());
    }

    // Formularz dodawania taga (GET)
    public IActionResult Create()
    {
        return View();
    }

    // Zapisywanie nowego taga do bazy (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name")] Tag tag)
    {
        if (ModelState.IsValid)
        {
            _context.Add(tag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(tag);
    }
}