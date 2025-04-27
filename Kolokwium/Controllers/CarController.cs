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
}