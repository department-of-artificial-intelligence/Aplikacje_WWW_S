using AWWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr1.Models;

public class AuthorController : Controller
{

    private readonly MyDbContext _dbContext;
    public AuthorController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var authors = _dbContext.Authors.ToList();
        return View(authors);
    }

    public IActionResult Edit(int id)
    {
        var author = _dbContext.Authors.Find(id);
        if (author == null)
        {
            return NotFound();
        }
        return View(author);
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var author = _dbContext.Authors.Find(id);
        if (author == null)
        {
            return NotFound();
        }
        _dbContext.Authors!.Remove(author);
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
        var author = _dbContext.Authors.Find(id);
        if (author == null)
        {
            return NotFound();
        }
        return View(author);
    }

    [HttpPost]
    public IActionResult AddOrUpdate(Author author)
    {
        if (author.Id != 0)
        {
            var a = _dbContext.Authors.Find(author.Id);
            if (a != null)
            {
                a.FirstName = author.FirstName;
                a.LastName = author.LastName;
            }
        }
        else
        {
            _dbContext.Authors!.Add(author);
        }
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult AddOrUpdate(int id = -1)
    {

        if (id != -1)
        {
            var author = _dbContext.Authors!
                .FirstOrDefault(a => a.Id == id);
            @ViewBag.Header = "Edytuj autora";
            @ViewBag.ButtonText = "Edytuj";
            return View(author);
        }
        else
        {
            @ViewBag.Header = "Dodaj autora";
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
        var author = _dbContext.Authors.Find(id);
        if (author == null)
        {
            return NotFound();
        }
        return View(author);
    }


}
