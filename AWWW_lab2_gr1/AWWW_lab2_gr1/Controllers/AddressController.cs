using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Models;

public class AddressesController : Controller
{
    private readonly AppDbContext _context;

    public AddressesController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var addresses = _context.Addresses.ToList();
        return View(addresses);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Address address)
    {
        _context.Addresses.Add(address);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}