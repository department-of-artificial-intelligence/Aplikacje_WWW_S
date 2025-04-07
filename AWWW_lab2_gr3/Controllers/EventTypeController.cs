using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc;

public class EventTypeController : Controller
{
    private readonly MyDbContext _dbContext;

    public EventTypeController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var eventypes = _dbContext.EventTypes.ToList();
        return View(eventypes);
    }

    // GET: Autor/Create
    public IActionResult Add()
    {
        return View();
    }

    // POST: Autor/Create
    [HttpPost]
    public IActionResult Add(EventType eventype)
    {
        _dbContext.EventTypes.Add(eventype);
        _dbContext.SaveChanges();
        return View("Added", eventype);
    }

}