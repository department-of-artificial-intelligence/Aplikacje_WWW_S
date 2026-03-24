using AWWW_lab1_gr1.Data;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Controllers;

public class TagController : Controller
{
    private readonly CompanyDbContext _db;

    public TagController(CompanyDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var tags = await _db.Tags
            .OrderBy(t => t.Name)
            .ToListAsync();

        return View(tags);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            _db.Tags.Add(new Tag { Name = name.Trim() });
            await _db.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}
