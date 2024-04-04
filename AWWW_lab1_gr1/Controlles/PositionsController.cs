using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PositionsController:Controller
{
    MyDbContext DbContext;

    public PositionsController(MyDbContext DbContext)
    {
        this.DbContext= DbContext;
    }

    public async Task<IActionResult> Index()
    {
        return View(await DbContext.Positions.ToListAsync());
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
            DbContext.Add(position);
            await DbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(position);
    }
}