using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Controllers;

public class KsiazkaController : Controller
{
    private readonly AppDbContext _context;
    public KsiazkaController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var ksiazki = _context.Ksiazki.Include(k=>k.Autorzy).Include(k=>k.Biblioteka).ToList();
        return View(ksiazki);
    }
    public IActionResult Create()
    {
        ViewBag.Biblioteki = _context.Biblioteki.ToList();
        ViewBag.Autorzy = _context.Autorzy.ToList();
        return View();
    }
    [HttpPost]
    public IActionResult Create(Ksiazka ksiazka, int[] autorzyIds)
    {
        var autorzy = _context.Autorzy.Where(a=> autorzyIds.Contains(a.Id)).ToList();
        ksiazka.Autorzy = autorzy;
        _context.Ksiazki.Add(ksiazka);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

}