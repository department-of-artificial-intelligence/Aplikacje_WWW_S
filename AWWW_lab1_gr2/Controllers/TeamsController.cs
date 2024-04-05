using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class TeamsController:Controller{
    private readonly MyDbContext _context;

    public TeamsController(MyDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index(){
        ViewBag.Title = "Lista drużyn";
        var data = await _context.Teams.ToListAsync();
        return View(data);
    }
    
    [HttpPost]
    public async Task<IActionResult> UsunDane(int id)
    {
        var dane = await _context.Teams.FindAsync(id);
        if (dane == null)
        {
            return NotFound();
        }

        _context.Teams.Remove(dane);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index"); // Przekierowanie na widok po usunięciu danych
    }
}