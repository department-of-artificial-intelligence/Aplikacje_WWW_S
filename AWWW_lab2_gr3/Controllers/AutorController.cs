using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc;

public class AutorController : Controller
{
    private readonly MyDbContext _dbContext;

    public AutorController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var authors = _dbContext.Authors.ToList();
        return View(authors);
    }

    // GET: Autor/Create
    public IActionResult Add()
    {
        return View();
    }

    // POST: Autor/Create
    [HttpPost]
    public IActionResult Add(Author author)
    {
        _dbContext.Authors.Add(author);
        _dbContext.SaveChanges();
        return View("Added",author);
    }

}