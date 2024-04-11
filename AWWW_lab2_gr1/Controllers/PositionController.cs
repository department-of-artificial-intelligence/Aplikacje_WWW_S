using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr1.Models;

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

    public IActionResult Edit(int id)
    {
        var position = _dbContext.Positions.Find(id);
        if (position == null)
        {
            return NotFound();
        }
        return View(position);
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var position = _dbContext.Positions.Find(id);
        if (position == null)
        {
            return NotFound();
        }
        _dbContext.Positions!.Remove(position);
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
        var position = _dbContext.Positions.Find(id);
        if (position == null)
        {
            return NotFound();
        }
        return View(position);
    }

    [HttpPost]
    public IActionResult AddOrUpdate(Position position)
    {
        if (position.Id != 0)
        {
            var a = _dbContext.Positions.Find(position.Id);
            if (a != null)
            {
                a.Name = position.Name;
            }
        }
        else
        {
            _dbContext.Positions!.Add(position);
        }
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult AddOrUpdate(int id = -1)
    {

        if (id != -1)
        {
            var position = _dbContext.Positions!
                .FirstOrDefault(a => a.Id == id);
            @ViewBag.Header = "Edytuj pozycję";
            @ViewBag.ButtonText = "Edytuj";
            return View(position);
        }
        else
        {
            @ViewBag.Header = "Dodaj pozycję";
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
        var position = _dbContext.Positions.Find(id);
        if (position == null)
        {
            return NotFound();
        }
        return View(position);
    }


}
