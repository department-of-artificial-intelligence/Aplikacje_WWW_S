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
       
        try{
      
            var eventypes = await dbcontext.EventTypes.ToListAsync();
            return View(eventypes);
         }
         catch(Exception ex)
         {
          throw;
         }
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