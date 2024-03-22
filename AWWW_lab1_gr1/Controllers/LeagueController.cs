using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class LeagueController:Controller
{
    MyDbContext bdContext;

    public LeagueController(MyDbContext bdContext)
    {
        this.bdContext = bdContext;
    }

    public async Task<IActionResult> Index()
    {
        return View(await bdContext.Tags.ToListAsync());
    }

    public IActionResult Add()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Add(League league)
    {
        if(ModelState.IsValid)
        {
            bdContext.Add(league);
            await bdContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(league);
    }
}