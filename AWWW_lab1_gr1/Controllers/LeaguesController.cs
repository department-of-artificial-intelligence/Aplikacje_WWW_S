using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class LeagueController:Controller
{
    MeBdContext dbcontext;

    public LeagueController(MeBdContext dbcontext)
    {
        this.dbcontext = dbcontext;
    }

    public async Task<IActionResult> Index()
    {
        try{
            var league = await dbcontext.Leagues.ToListAsync();
            return View(league);
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
    public async Task<IActionResult> Add(League league)
    {
        if(ModelState.IsValid)
        {
            dbcontext.Add(league);
            await dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(league);
    }
}