using AWWW_lab2_gr3.Models;
using Microsoft.AspNetCore.Mvc;

public class EventTypeController : Controller
{
    private readonly OskiDBContext _dbContext;

    public EventTypeController(OskiDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var eventtypes = _dbContext.EventType.ToList();
        return View(eventtypes);
    }

}