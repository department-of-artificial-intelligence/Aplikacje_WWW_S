using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ArticlesController:Controller{
    private readonly MyDbContext _context;

    public ArticlesController(MyDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index(){
        ViewBag.Title = "Lista artykułów";
        var data = await _context.Articles.ToListAsync();
        ViewBag.autorzy = await _context.Authors.ToListAsync();
        return View(data);
    }
    public IActionResult Add(){
        ViewBag.Title = "Dodaj artykuł";
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> UsunDane(int id)
    {
        var dane = await _context.Articles.FindAsync(id);
        if (dane == null)
        {
            return NotFound();
        }

        _context.Articles.Remove(dane);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Added(Article article)
    {
        if (ModelState.IsValid)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Articles");
        }
        return View();
    }
}