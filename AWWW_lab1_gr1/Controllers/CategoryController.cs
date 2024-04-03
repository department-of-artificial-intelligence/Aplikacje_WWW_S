using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


public class  AuthorController : Controller
    {
        private readonly LabDbContext _dbContext;

        public AuthorController(LabDbContext _dbContext)
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
    public async Task<IActionResult> Create(Category category) {
        if (ModelState.IsValid) {
            _dbContext.Add(category);
            await _dbContext.SaveChangesAsync();
     
            return RedirectToAction("Index");
        }
        return View(category);
    }
}