using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AuthorsController : Controller {
   MeBdContext dbContext;

    public AuthorsController(MeBdContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<IActionResult> Index() {
         

        return View(await dbContext.Authors.ToListAsync());
    }

    public IActionResult Add() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Author author) {
        if (ModelState.IsValid) {
            dbContext.Add(author);
            await dbContext.SaveChangesAsync();
     
            return RedirectToAction("Index");
        }
        return View(author);
    }
}