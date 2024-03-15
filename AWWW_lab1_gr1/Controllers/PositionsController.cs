using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PositionsController : Controller {
   LabOneContext dbContext;

    public PositionsController(LabOneContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<IActionResult> Index() {
         

        return View(await dbContext.Positions.ToListAsync());
    }

    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Position position) {
        if (ModelState.IsValid) {
            dbContext.Add(position);
            await dbContext.SaveChangesAsync();
     
            return RedirectToAction("Index");
        }
        return View(position);
    }
}
