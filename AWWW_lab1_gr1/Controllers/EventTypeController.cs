using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

public class EventTypeController : Controller {
    MyDbContext bdContext;

    public EventTypeController(MyDbContext bdContext)
    {
        this.bdContext = bdContext;
    }
    
    public async Task<IActionResult> Index() {
        try
        {
            return View(await bdContext.EventTypes.ToListAsync());
        }
        catch (Exception ex)
        {
            
            return View("Index");
        }
    }

    public IActionResult Create() {
        return View();
    }

      public IActionResult Add()
    {
        return View("Add"); 
    }

    [HttpPost]
    public async Task<IActionResult> Create(EventType eventType) {
        if (ModelState.IsValid) {
            bdContext.Add(eventType);
            await bdContext.SaveChangesAsync();
     
            return RedirectToAction("Index");
        }
        return View(eventType);
    }
}
