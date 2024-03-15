using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class EventTypesController : Controller {
   LabOneContext dbContext;

    public EventTypesController(LabOneContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<IActionResult> Index() {
         

        return View(await dbContext.EventTypes.ToListAsync());
    }

    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(EventType eventType) {
        if (ModelState.IsValid) {
            dbContext.Add(eventType);
            await dbContext.SaveChangesAsync();
     
            return RedirectToAction("Index");
        }
        return View(eventType);
    }
}
