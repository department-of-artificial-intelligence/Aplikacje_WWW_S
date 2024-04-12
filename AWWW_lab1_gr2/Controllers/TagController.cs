using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


public class TagController:Controller{
    private readonly MyDbContext context;
    public TagController(MyDbContext conteext){
        context = conteext;
    }
    public async Task<IActionResult> Index()
    {
        ViewBag.Title = "Tagi";
        var data = await context.Tags.ToListAsync();
        return View(data);
    }

    [HttpPost]
    public IActionResult Added(Tag tag)
    {
        if (ModelState.IsValid)
        {
            context.Tags.Add(tag);
            context.SaveChanges();
            return RedirectToAction("Index", "Tag");
        }
        return View(tag);
    }

    [HttpPost]
    public async Task<IActionResult> UsunDane(int id)
    {
        var dane = await context.Tags.FindAsync(id);
        if (dane == null)
        {
            return NotFound();
        }
        context.Tags.Remove(dane);
        await context.SaveChangesAsync();

        return RedirectToAction("Index"); // Przekierowanie na widok po usunięciu danych
    }

    public IActionResult Add(){
        return View();
    }
}