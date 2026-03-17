using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr1.Data;
using AWWW_lab2_gr1.Models;

namespace AWWW_lab2_gr1.Controllers;

public class AddressController : Controller
{
    private readonly AppDbContext _context;

    public AddressController(AppDbContext context)
    {
        _context = context;
    }

    // Wyświetlanie listy adresów
    public async Task<IActionResult> Index()
    {
        return View(await _context.Addresses.ToListAsync());
    }

    // Formularz dodawania adresu (GET)
    public IActionResult Create()
    {
        return View();
    }

    // Zapisywanie nowego adresu do bazy (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CustomerId,City,Street,PostalCode")] Address address)
    {
        if (ModelState.IsValid)
        {
            _context.Add(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(address);
    }
}