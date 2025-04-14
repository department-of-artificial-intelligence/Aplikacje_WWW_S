using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc;

public class CategoryController : Controller
{
    private readonly OskiDBContext _dbContext;

    public CategoryController(OskiDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var categories = _dbContext.Category.ToList();
        return View(categories);
    }

}