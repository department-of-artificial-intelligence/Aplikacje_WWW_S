using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kolokwium.Models;

public class MatchController : Controller
{
    private readonly MyDbContext _context;
    public MatchController(MyDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var matches = _context.Match.ToList();
        return View(matches);
    }
}