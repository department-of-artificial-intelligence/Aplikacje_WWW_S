using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Data;
using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWWW_lab2_gr1.Controllers;

public class AddressController : Controller
{
    private readonly AppDbContext _context;
    public AddressController(AppDbContext context) { _context = context; }

    public IActionResult Index() => View(_context.Addresses.ToList());
    public IActionResult Create()
    {
        ViewBag.Customers = new SelectList(_context.Customers, "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Address address)
    {
        if (ModelState.IsValid)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Customers = new SelectList(_context.Customers, "Id", "Name");
        return View(address);
    }
}