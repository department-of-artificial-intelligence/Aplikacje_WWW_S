using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class OwnerController : Controller
{
    private readonly MyDbContext _context;
    public OwnerController(MyDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var owners = _context.Owners.Include(o => o.Cars).ToList();
        return View(owners);
    }
}