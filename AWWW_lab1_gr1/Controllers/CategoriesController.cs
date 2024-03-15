using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CategoriesController : Controller {
   LabOneContext dbContext;

    public CategoriesController(LabOneContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<IActionResult> Index() {
         

        return View(await dbContext.Categories.ToListAsync());
    }

    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category) {
        if (ModelState.IsValid) {
            dbContext.Add(category);
            await dbContext.SaveChangesAsync();
     
            return RedirectToAction("Index");
        }
        return View(category);
    }
}
