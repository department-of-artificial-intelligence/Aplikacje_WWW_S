using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class TagController:Controller
{
    DbContext bdContext;

    public TagController(DbContext bdContext)
    {
        this.bdContext = bdContext;
    }

    public async Task<IActionResult> Index()
    {
        return View(await dbcontext.Tags.ToListAsync());
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
             bdContext.Add(tag);
            await bdContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(tag);
    }
}