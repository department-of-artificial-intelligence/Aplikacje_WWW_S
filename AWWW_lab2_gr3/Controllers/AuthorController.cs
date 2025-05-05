using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr3.Models;

public class AuthorController : Controller
{
    private readonly ApplicationDbContext _context;

    public AuthorController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Author author)
    {
        if (ModelState.IsValid)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        return View(author);
    }
}
