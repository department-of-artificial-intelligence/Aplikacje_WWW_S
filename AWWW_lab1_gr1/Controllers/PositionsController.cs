using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PositionController:Controller
{
    MeBdContext dbcontext;

    public PositionController(MeBdContext dbcontext)
    {
        this.dbcontext= dbcontext;
    }

    public async Task<IActionResult> Index()
    {
        return View(await dbcontext.Positions.ToListAsync());
    }

    public IActionResult Add()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Add(Position position)
    {
        if(ModelState.IsValid)
        {
            dbcontext.Add(position);
            await dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(position);
    }
}