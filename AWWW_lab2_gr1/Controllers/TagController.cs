using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Data;
using AWWW_lab2_gr1.Models;

namespace AWWW_lab2_gr1.Controllers;

public class TagController : Controller
{
    private readonly AppDbContext _context;
    public TagController(AppDbContext context) { _context = context; }

    public IActionResult Index() => View(_context.Tags.ToList());
    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Tag tag)
    {
        if (ModelState.IsValid)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(tag);
    }
}