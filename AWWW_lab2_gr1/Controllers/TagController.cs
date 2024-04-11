using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr1.Models;

public class TagController : Controller
{

    private readonly MyDbContext _dbContext;
    public TagController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var tags = _dbContext.Tags.ToList();
        return View(tags);
    }

    public IActionResult Edit(int id)
    {
        var tag = _dbContext.Tags.Find(id);
        if (tag == null)
        {
            return NotFound();
        }
        return View(tag);
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var tag = _dbContext.Tags.Find(id);
        if (tag == null)
        {
            return NotFound();
        }
        _dbContext.Tags!.Remove(tag);
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
        var tag = _dbContext.Tags.Find(id);
        if (tag == null)
        {
            return NotFound();
        }
        return View(tag);
    }

    [HttpPost]
    public IActionResult AddOrUpdate(Tag tag)
    {
        if (tag.Id != 0)
        {
            var a = _dbContext.Tags.Find(tag.Id);
            if (a != null)
            {
                a.Name = tag.Name;
            }
        }
        else
        {
            _dbContext.Tags!.Add(tag);
        }
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult AddOrUpdate(int id = -1)
    {

        if (id != -1)
        {
            var tag = _dbContext.Tags!
                .FirstOrDefault(a => a.Id == id);
            @ViewBag.Header = "Edytuj tag";
            @ViewBag.ButtonText = "Edytuj";
            return View(tag);
        }
        else
        {
            @ViewBag.Header = "Dodaj tag";
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
        var tag = _dbContext.Tags.Find(id);
        if (tag == null)
        {
            return NotFound();
        }
        return View(tag);
    }


}
