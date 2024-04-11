using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

public class CategoryController : Controller {
    MyDbContext bdContext;

    public CategoryController(MyDbContext bdContext)
    {
        this.bdContext = bdContext;
    }
    
    public async Task<IActionResult> Index() {
        try
        {
            return View(await bdContext.Categories.ToListAsync());
        }
        catch (Exception ex)
        {
            
            return View("Index");
        }
    }

    public IActionResult Create() {
        return View("Add");
    }

      public IActionResult Add()
    {
        return View("Add"); 
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category) {
        if (ModelState.IsValid) {
            bdContext.Add(category);
            await bdContext.SaveChangesAsync();
     
            return RedirectToAction("Index", "Categories");
        }
        return View(category);
    }
}
