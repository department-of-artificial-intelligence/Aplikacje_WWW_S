using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AuthorsController : Controller
{
   private MeBdContext dbContext;

    public AuthorsController(MeBdContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<IActionResult> Index()
    {
        try
        {
            var authors = await dbContext.Authors.ToListAsync();
             return View(authors);
        }
        catch (Exception ex)
        {
            throw;
        }       
    }



    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Author author)
    {
        if (ModelState.IsValid)
        {
            dbContext.Add(author);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        return View(author);
    }
}