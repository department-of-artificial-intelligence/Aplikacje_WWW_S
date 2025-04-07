using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc;

public class AuthorController : Controller
{
    private readonly OskiDBContext _dbContext;

    public AuthorController(OskiDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var authors = _dbContext.Authors.ToList();
        return View(authors);
    }

}