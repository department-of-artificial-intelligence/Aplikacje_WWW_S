using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PositionController:Controller
{
    DbContext bdContext;

    public PositionController(DbContext bdContext)
    {
        this.bdcontext= bdContext;
    }

    public async Task<IActionResult> Index()
    {
        return View(await bdcontext.Positions.ToListAsync());
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