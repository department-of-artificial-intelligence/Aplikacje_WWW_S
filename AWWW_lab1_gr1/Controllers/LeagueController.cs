using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


public class  LeagueController : Controller
    {
        private readonly LabDbContext _dbContext;

        public LeagueController(LabDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<IActionResult> Index(){
           return View(await _dbContext.Authors.ToListAsync());
    }
    

    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(League league) {
        if (ModelState.IsValid) {
            _dbContext.Add(league);
            await _dbContext.SaveChangesAsync();
     
            return RedirectToAction("Index");
        }
        return View(league);
    }
}