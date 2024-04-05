using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;
using Microsoft.EntityFrameworkCore;

public class AuthorsController:Controller{
    private readonly MyDbContext _context;
    public AuthorsController(MyDbContext context){
        _context = context;
    }
    public async Task<IActionResult> Index(){
        ViewBag.Title = "Autorzy";
        var data = await _context.Authors.ToListAsync(); 
        return View(data);
    }

    public IActionResult Add(){
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UsunDane(int id)
    {
        var dane = await _context.Authors.FindAsync(id);
        if (dane == null)
        {
            return NotFound();
        }

        _context.Authors.Remove(dane);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Added(Author author)
    {
        if (ModelState.IsValid)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Authors");
        }
        return View();
    }
}