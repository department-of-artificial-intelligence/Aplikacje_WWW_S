using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class EventTypeController: Controller
{
    MyDbContext bdContext;

    public EventTypeController(MyDbContext bdContext)
    {
        this.bdContext = bdContext;
    }

    public async Task<IActionResult> Index()
    {
        return View (await bdContext.EventTypes.ToListAsync()); 
    }


    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(EventType eventType)
    {
        if(ModelState.IsValid)
        {
            bdContext.Add(eventType);
            await bdContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(eventType);
    }
}