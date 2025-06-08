using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kolokwium.Models;

namespace Kolokwium.Controllers;


public class CarController : Controller{
    private readonly MyDbContext _context;
    public CarController(MyDbContext context){
        _context = context;
    }

    public IActionResult Index(){
        var car = _context.Cars.Include(o => o.Owners).ToList();
        return View(car);
    }

    public IActionResult Add()
    {
        ViewBag.owners = _context.Owners.Select(o => new SelectListItem
        {
            Value = o.Id.ToString(),
            Text = o.Name
        }).ToList();
        ViewBag.garages = _context.Garages.Select(g => new SelectListItem
        {
            Value = g.Id.ToString(),
            Text = g.Nazwa
        }).ToList();
        return View();
    }

    [HttpPost]
    public IActionResult Add(Car car , List<int> owners)
    {
       var ownerss = owners != null ? _context.Owners.Where(o => owners.Contains(o.Id)).ToList() : new List<Owner>();
       car.Owners = ownerss;

       var garage = _context.Garages.FirstOrDefault(g => g.Id == car.GarageId);
       car.Garage = garage;

        _context.Cars.Add(car);
        _context.SaveChanges();


        return RedirectToAction("Index");
    }
}