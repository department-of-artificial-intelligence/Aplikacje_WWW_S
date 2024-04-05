using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class LeagueController:Controller
{
    MyDbContext DbContext;

    public LeagueController(MyDbContext DbContext)
    {
        this.DbContext = DbContext;
    }

    public async Task<IActionResult> Index()
    {
        return View(await DbContext.Tags.ToListAsync());
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
            DbContext.Add(league);
            await DbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(league);
    }
}