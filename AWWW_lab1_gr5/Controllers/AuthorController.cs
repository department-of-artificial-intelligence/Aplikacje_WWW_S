using AWWW_lab1_gr5;
using AWWW_lab1_gr5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AuthorsController : Controller {
   MyDbContext dbContext;

    public AuthorsController(MyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<IActionResult> Index() {
         

        return View(await dbContext.Authors.ToListAsync());
    }

    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Author author) {
        if (ModelState.IsValid) {
            dbContext.Add(author);
            await dbContext.SaveChangesAsync();
     
            return RedirectToAction("Index");
        }
        return View(author);
    }
}