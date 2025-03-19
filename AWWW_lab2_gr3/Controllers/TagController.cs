using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc;

public class TagController : Controller
{
    private readonly MyDbContext _dbContext;

    public TagController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var tag = _dbContext.Tags.ToList();
        return View(tag);
    }

    // GET: Autor/Create
    public IActionResult Add()
    {
        return View();
    }

    // POST: Autor/Create
    [HttpPost]
    public IActionResult Add(Tag tag)
    {
        _dbContext.Tags.Add(tag);
        _dbContext.SaveChanges();
        return View("Added", tag);
    }

}