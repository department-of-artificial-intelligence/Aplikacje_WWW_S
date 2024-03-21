using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetCore;

public class AuthorsController : Controller {
    MyDbContext _dbContext;

    public AuthorsController(MyDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public IActionResult Index()
        {
            return View(_dbContext.Authors.ToList());
        }

    public IActionResult Create() {
        return View();
    }

    
}