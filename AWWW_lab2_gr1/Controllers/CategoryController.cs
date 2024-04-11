using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr1.Models;

public class CategoryController : Controller
{

    private readonly MyDbContext _dbContext;
    public CategoryController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var categories = _dbContext.Categories.ToList();
        return View(categories);
    }

    public IActionResult Edit(int id)
    {
        var category = _dbContext.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var category = _dbContext.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        _dbContext.Categories!.Remove(category);
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
        var category = _dbContext.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    [HttpPost]
    public IActionResult AddOrUpdate(Category category)
    {
        if (category.Id != 0)
        {
            var a = _dbContext.Categories.Find(category.Id);
            if (a != null)
            {
                a.Name = category.Name;
            }
        }
        else
        {
            _dbContext.Categories!.Add(category);
        }
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult AddOrUpdate(int id = -1)
    {

        if (id != -1)
        {
            var category = _dbContext.Categories!
                .FirstOrDefault(a => a.Id == id);
            @ViewBag.Header = "Edytuj kategorie";
            @ViewBag.ButtonText = "Edytuj";
            return View(category);
        }
        else
        {
            @ViewBag.Header = "Dodaj kategorie";
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
        var category = _dbContext.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }


}
