using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr1.Data;
using AWWW_lab2_gr1.Models;

namespace AWWW_lab2_gr1.Controllers;

public class CustomerController : Controller
{
    private readonly AppDbContext _context;
    public CustomerController(AppDbContext context) { _context = context; }

    public IActionResult Index() => View(_context.Customers.ToList());
    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(customer);
    }
}