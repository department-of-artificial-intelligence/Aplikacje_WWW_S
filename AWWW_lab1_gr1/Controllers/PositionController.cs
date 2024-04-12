using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

public class PositionController : Controller {
    MyDbContext bdContext;

    public PositionController(MyDbContext bdContext)
    {
        this.bdContext = bdContext;
    }
    
    public async Task<IActionResult> Index() {
        try
        {
            return View(await bdContext.Positions.ToListAsync());
        }
        catch (Exception ex)
        {
            
            return View("Index");
        }
    }

    

      public IActionResult Add()
    {
        return View("Add"); 
    }

    [HttpPost]
    public async Task<IActionResult> Add(Position position) {
        if (ModelState.IsValid) {
            bdContext.Add(position);
            await bdContext.SaveChangesAsync();
     
            return RedirectToAction("Index");
        }
        return View(position);
    }
}
