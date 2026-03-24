using AWWW_lab1_gr1.Data;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab1_gr1.Controllers;

public class AddressController : Controller
{
    private readonly CompanyDbContext _db;

    public AddressController(CompanyDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var addresses = await _db.Addresses
            .AsNoTracking()
            .OrderBy(a => a.City)
            .ThenBy(a => a.Street)
            .ToListAsync();

        return View(addresses);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Address model)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Index));
        }

        _db.Addresses.Add(new Address
        {
            CustomerId = model.CustomerId,
            City = model.City.Trim(),
            Street = model.Street.Trim(),
            PostalCode = model.PostalCode.Trim()
        });

        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
