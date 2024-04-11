using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

public class AuthorsController : Controller {
    MyDbContext bdContext;

    public AuthorsController(MyDbContext bdContext)
    {
        this.bdContext = bdContext;
    }
    
    public async Task<IActionResult> Index() {
        try
        {
            return View(await bdContext.Authors.ToListAsync());
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
public async Task<IActionResult> Create(Author author)
{
    if (ModelState.IsValid)
    {
        bdContext.Add(author);
        await bdContext.SaveChangesAsync();

        return RedirectToAction("Index", "Authors"); 
    }
    return View(author);
}
}
