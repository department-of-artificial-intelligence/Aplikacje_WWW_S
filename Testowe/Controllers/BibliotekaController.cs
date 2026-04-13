using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Controllers;

public class BibliotekaController : Controller
{
    private readonly AppDbContext _context;
    public BibliotekaController(AppDbContext context)
    {
        _context=context;
    }

    public IActionResult Index()
    {
        var biblioteki = _context.Biblioteki.Include(b=>b.Ksiazki).ToList();
        return View(biblioteki);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Biblioteka biblioteka)
    {
        _context.Biblioteki.Add(biblioteka);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

}