using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc;

public class CategoryController : Controller
{
    private readonly MyDbContext _dbContext;

    public CategoryController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var category = _dbContext.Categories.ToList();
        return View(category);
    }

    // GET: Autor/Create
    public IActionResult Add()
    {
        return View();
    }

    // POST: Autor/Create
    [HttpPost]
    public IActionResult Add(Category category)
    {
        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
        return View("Added", category);
    }

}