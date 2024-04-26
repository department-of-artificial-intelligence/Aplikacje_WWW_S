using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


public class AuthorController:Controller{
    private readonly MyDbContext context;
    public AuthorController(MyDbContext conteext){
        context = conteext;
    }
    public async Task<IActionResult> Index()
    {
        ViewBag.Title = "Autorzy";
        var data = await context.Authors.ToListAsync();
        return View(data);
    }

    [HttpPost]
    public IActionResult Added(Author author)
    {
        if (ModelState.IsValid)
        {
            context.Authors.Add(author);
            context.SaveChanges();
            return RedirectToAction("Index", "Author");
        }
        return View(author);
    }

    [HttpPost]
    public async Task<IActionResult> UsunDane(int id)
    {
        var dane = await context.Authors.FindAsync(id);
        if (dane == null)
        {
            return NotFound();
        }
        context.Authors.Remove(dane);
        await context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public IActionResult Add(){
        return View();
    }
}