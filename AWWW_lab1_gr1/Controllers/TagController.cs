using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class TagsController : Controller {
   MyDbContext bdContext;

    public TagsController(MyDbContext bdContext)
    {
        this.bdContext = bdContext;
    }
    public async Task<IActionResult> Index() {
        try
        {
            return View(await bdContext.Tags.ToListAsync());
        }
        catch (Exception ex)
        {
            
            return View("Views/Tag/Index.cshtml");
        }
    }
    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Tag tag) {
        if (ModelState.IsValid) {
            bdContext.Add(tag);
            await bdContext.SaveChangesAsync();
     
            return RedirectToAction("Index");
        }
        return View(tag);
    }
}