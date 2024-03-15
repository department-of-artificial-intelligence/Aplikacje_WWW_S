using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class TagsController : Controller {
   LabOneContext dbContext;

    public TagsController(LabOneContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<IActionResult> Index() {
         

        return View(await dbContext.Tags.ToListAsync());
    }

    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Tag tag) {
        if (ModelState.IsValid) {
            dbContext.Add(tag);
            await dbContext.SaveChangesAsync();
     
            return RedirectToAction("Index");
        }
        return View(tag);
    }
}
