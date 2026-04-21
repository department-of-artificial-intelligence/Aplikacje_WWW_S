using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Controllers;

public class OrderController : Controller
{
    public AppDbContext? _dbContext;

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddOrder(int id)
    {
        return View(id);
    }

    public IActionResult AddOrder(Order order)
    {
        _dbContext?.Orders.Add(order);
        _dbContext?.SaveChanges();

        return View("Index");
    }
}
