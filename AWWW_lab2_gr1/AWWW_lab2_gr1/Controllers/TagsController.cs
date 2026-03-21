using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Models;

public class TagsController : Controller
{
    private readonly AppDbContext _context;

    public TagsController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var tags = _context.Tags.ToList();
        return View(tags);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Tag tag)
    {
        _context.Tags.Add(tag);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}