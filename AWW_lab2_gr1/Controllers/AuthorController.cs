using AWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace AWW_lab2_gr1.Controllers;

public class AuthorController : Controller
{
  private readonly MyDbContext _dbContext;

  public AuthorController(MyDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public IActionResult Index()
  {
    List<Author> authors = _dbContext.Authors.ToList();

    ViewBag.Title = "Authors";
    return View(authors);
  }

  public IActionResult Details(int id)
  {
    var author = _dbContext.Authors.FirstOrDefault(a => a.Id == id);

    if (author == null)
    {
      return View("Error");
    }

    return View(author);
  }
  public IActionResult Add()
  {
    return View("Edit", new Author { FirstName = "", LastName = "" });
  }

  public IActionResult Edit(int id)
  {
    var author = _dbContext.Authors.FirstOrDefault(a => a.Id == id);

    if (author == null)
    {
      return View("Error");
    }

    return View("Edit", author);
  }

  [HttpPost]
  public IActionResult Save(Author author)
  {
    Console.WriteLine(ModelState.IsValid);

    Console.WriteLine(author.Id);

    if (author.Id == 0)
    {
      _dbContext.Authors.Add(author);
    }
    else
    {
      _dbContext.Authors.Update(author);
    }

    try
    {
      _dbContext.SaveChanges();
    }
    catch (Exception ex)
    {
      return View("Error");
    }

    return RedirectToAction("Details", "Author", new { id = author.Id });

    // return View("Details", author);
  }

  public ActionResult Delete(int id)
  {
    // Retrieve data from database based on id
    Author author = _dbContext.Authors.Find(id);

    if (author == null)
    {
      return RedirectToAction("Index");
    }

    _dbContext.Authors.Remove(author);
    _dbContext.SaveChanges();

    return RedirectToAction("Index");
  }
}