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
        try{var authors = await dbContext.Authors.ToListAsync();} 
        catch(Exception ex){}

     
        return View();
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