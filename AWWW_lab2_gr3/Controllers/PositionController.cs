using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc;

public class PositionController : Controller
{
    private readonly MyDbContext _dbContext;

    public PositionController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var positions = _dbContext.Positions.ToList();
        return View(positions);
    }

    // GET: Autor/Create
    public IActionResult Add()
    {
        return View();
    }

    // POST: Autor/Create
    [HttpPost]
    public IActionResult Add(Position position)
    {
        _dbContext.Positions.Add(position);
        _dbContext.SaveChanges();
        return View("Added", position);
    }

}
