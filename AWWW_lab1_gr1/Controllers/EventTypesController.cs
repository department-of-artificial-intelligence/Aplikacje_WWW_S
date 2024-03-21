using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class EventTypeController: Controller
{
    MeBdContext dbcontext;

    public EventTypeController(MeBdContext dbcontext)
    {
        this.dbcontext = dbcontext;
    }

    public async Task<IActionResult> Index()
    {
        return View (await dbcontext.EventTypes.ToListAsync()); 
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
            dbcontext.Add(eventType);
            await dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(eventType);
    }
}