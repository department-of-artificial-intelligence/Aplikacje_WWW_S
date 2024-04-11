using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

public class LeagueController : Controller {
    MyDbContext bdContext;

    public LeagueController(MyDbContext bdContext)
    {
        this.bdContext = bdContext;
    }
    
    public async Task<IActionResult> Index() {
        try
        {
            return View(await bdContext.Leagues.ToListAsync());
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
    public async Task<IActionResult> Create(League league) {
        if (ModelState.IsValid) {
            bdContext.Add(league);
            await bdContext.SaveChangesAsync();
     
            return RedirectToAction("Index");
        }
        return View(league);
    }
}
