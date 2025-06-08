using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class GarageController : Controller
{
    private readonly MyDbContext _context;
    public GarageController(MyDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var garage = _context.Garages.Include(o => o.Cars).ToList();
        return View(garage);
    }
}