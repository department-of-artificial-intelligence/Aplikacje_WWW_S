using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr1.Models;

namespace AWWW_lab2_gr1.Controllers;

public class AddressController : Controller
{
    private readonly AppDbContext _context;

    public AddressController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var addresses = _context.Addresses.Include(a => a.Customer).OrderBy(a => a.Id).ToList();
        return View(addresses);
    }

    public IActionResult Create()
    {
        var customers = _context.Customers.OrderBy(c => c.Name).ToList();
        ViewBag.Customers = customers;
        return View();
    }

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Address address)
{
    if (!ModelState.IsValid)
    {
        var customers = _context.Customers.OrderBy(c => c.Name).ToList();
        ViewBag.Customers = customers;
        return View(address);
    }

    _context.Addresses.Add(address);
    _context.SaveChanges();
    return RedirectToAction(nameof(Index));
}
}
