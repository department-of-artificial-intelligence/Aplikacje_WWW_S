using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Models;

namespace AWWW_lab2_gr1.Controllers;

public class TagController : Controller
{
    private readonly AppDbContext _context;

    public TagController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var tags = _context.Tags.OrderBy(t => t.Id).ToList();
        return View(tags);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Tag tag)
    {
        if (!ModelState.IsValid)
            return View(tag);

        _context.Tags.Add(tag);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
