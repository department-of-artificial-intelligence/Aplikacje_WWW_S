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

     public async Task<IActionResult> Index() {
        try
        {
            return View(await bdContext.Leagues.ToListAsync());
        }
        catch (Exception ex)
        {
            
            return View("Views/League/Index.cshtml");
        }
    }


    [HttpPost]
    public async Task<IActionResult> Add(League league)
    {
        if(ModelState.IsValid)
        {
            bdContext.Add(league);
            await bdContext.SaveChangesAsync();
            return RedirectToAction("Views/League/Add.cshtml");
        }
        return View(league);
    }
}