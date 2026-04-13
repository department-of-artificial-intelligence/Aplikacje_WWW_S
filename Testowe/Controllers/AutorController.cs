using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kolokwium.Models;

namespace Kolokwium.Controllers;

public class AutorController : Controller
{
    private readonly AppDbContext _context;

    public AutorController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var autorzy = _context.Autorzy
            .Include(a => a.Ksiazki)
            .ToList();

        return View(autorzy);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Autor autor)
    {
        _context.Autorzy.Add(autor);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}