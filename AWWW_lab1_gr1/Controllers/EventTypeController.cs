using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class EventTypeController: Controller
{
    MyDbContext DbContext;

    public EventTypeController(MyDbContext DbContext)
    {
        this.DbContext = DbContext;
    }

    public async Task<IActionResult> Index()
    {
        return View (await DbContext.EventTypes.ToListAsync()); 
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
            DbContext.Add(eventType);
            await DbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(eventType);
    }
}