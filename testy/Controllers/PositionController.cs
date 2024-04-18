using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kolokwium.Models;

public class PositionController : Controller
{
    private readonly MyDbContext _context;
    public PositionController(MyDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var positions = _context.Position.ToList();
        return View(positions);
    }
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(Position position)
    {
        _context.Position.Add(position);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}