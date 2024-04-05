using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


public class LeagueController:Controller{
    private readonly MyDbContext context;
    public LeagueController(MyDbContext conteext){
        context = conteext;
    }
    public async Task<IActionResult> Index()
    {
        ViewBag.Title = "Ligi";
        var data = await context.Leagues.ToListAsync();
        return View(data);
    }

    [HttpPost]
    public IActionResult Added(League league)
    {
        if (ModelState.IsValid)
        {
            context.Leagues.Add(league);
            context.SaveChanges();
            return RedirectToAction("Index", "League");
        }
        return View(league);
    }

    [HttpPost]
    public async Task<IActionResult> UsunDane(int id)
    {
        var dane = await context.Leagues.FindAsync(id);
        if (dane == null)
        {
            return NotFound();
        }
        context.Leagues.Remove(dane);
        await context.SaveChangesAsync();

        return RedirectToAction("Index"); // Przekierowanie na widok po usunięciu danych
    }

    public IActionResult Add(){
        return View();
    }
}