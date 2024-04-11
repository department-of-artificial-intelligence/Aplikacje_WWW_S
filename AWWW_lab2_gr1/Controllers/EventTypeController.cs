using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr1.Models;

public class EventTypeController : Controller
{

    private readonly MyDbContext _dbContext;
    public EventTypeController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var types = _dbContext.EventTypes.ToList();
        return View(types);
    }

    public IActionResult Edit(int id)
    {
        var type = _dbContext.EventTypes.Find(id);
        if (type == null)
        {
            return NotFound();
        }
        return View(type);
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var type = _dbContext.EventTypes.Find(id);
        if (type == null)
        {
            return NotFound();
        }
        _dbContext.EventTypes!.Remove(type);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var type = _dbContext.EventTypes.Find(id);
        if (type == null)
        {
            return NotFound();
        }
        return View(type);
    }

    [HttpPost]
    public IActionResult AddOrUpdate(EventType type)
    {
        if (type.Id != 0)
        {
            var a = _dbContext.EventTypes.Find(type.Id);
            if (a != null)
            {
                a.Name = type.Name;
            }
        }
        else
        {
            _dbContext.EventTypes!.Add(type);
        }
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult AddOrUpdate(int id = -1)
    {

        if (id != -1)
        {
            var type = _dbContext.EventTypes!
                .FirstOrDefault(a => a.Id == id);
            @ViewBag.Header = "Edytuj typ eventu";
            @ViewBag.ButtonText = "Edytuj";
            return View(type);
        }
        else
        {
            @ViewBag.Header = "Dodaj typ eventu";
            @ViewBag.ButtonText = "Dodaj";
            return View();
        }

    }

    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var type = _dbContext.EventTypes.Find(id);
        if (type == null)
        {
            return NotFound();
        }
        return View(type);
    }


}
