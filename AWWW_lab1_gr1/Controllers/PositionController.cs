using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PositionController:Controller
{
    MyDbContext bdContext;

    public PositionController(MyDbContext bdContext)
    {
        this.bdContext= bdContext;
    }

    public async Task<IActionResult> Index()
    {
        return View(await bdContext.Positions.ToListAsync());
    }

    public IActionResult Add()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Add(Position position)
    {
        if(ModelState.IsValid)
        {
            bdContext.Add(position);
            await bdContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(position);
    }
}