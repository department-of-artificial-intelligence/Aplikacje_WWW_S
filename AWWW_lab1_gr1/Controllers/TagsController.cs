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
             dbcontext.Add(tag);
            await dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(tag);
    }
}