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
    return View();
  }

  [HttpPost]
  public IActionResult Add(Author author)
  {
    Console.WriteLine(author.FirstName);
    Console.WriteLine(ModelState.IsValid);

    _dbContext.Authors.Add(author);

    try
    {
      _dbContext.SaveChanges();
    }
    catch (Exception ex)
    {
      return View("Error");
    }

    // return View("Details", author);
    return RedirectToAction("Details", "Author", new { id = author.Id });
  }
}