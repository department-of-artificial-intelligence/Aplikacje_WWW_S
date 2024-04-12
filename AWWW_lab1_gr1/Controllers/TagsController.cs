using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class TagController:Controller
{
    MeBdContext dbcontext;

    public TagController(MeBdContext dbcontext)
    {
        this.dbcontext = dbcontext;
    }

    public async Task<IActionResult> Index()
    {
        
        try{
            var tags = await dbcontext.Tags.ToListAsync();
            return View(tags);
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
    public async Task<IActionResult> Add(Tag tag)
    {
        if(ModelState.IsValid)
        {
             dbcontext.Add(tag);
            await dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(tag);
    }
}