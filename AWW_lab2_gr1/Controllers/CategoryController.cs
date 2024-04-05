using AWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWW_lab2_gr1.Controllers;

public class CategoryController : Controller
{
  private readonly MyDbContext _dbContext;

  public CategoryController(MyDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public IActionResult Index()
  {
    List<Category> categories = _dbContext.Categories.ToList();

    ViewBag.Title = "Categories";
    ViewBag.Test = "ddd";

    return View(categories);
  }

  public IActionResult Details(int id)
  {
    Category category = _dbContext.Categories.FirstOrDefault(el => el.Id == id);

    if (category == null)
    {
      return View("Error");
    }

    return View(category);
  }

  public IActionResult Add()
  {
    return View("Edit", new Category());
  }

  public IActionResult Edit(int id)
  {
    var category = _dbContext.Categories.FirstOrDefault(a => a.Id == id);

    if (category == null)
    {
      return View("Error");
    }

    return View("Edit", category);
  }

  [HttpPost]
  public IActionResult Save(Category category)
  {
    Console.WriteLine(ModelState.IsValid);

    Console.WriteLine(category.Id);

    if (category.Id == 0)
    {
      _dbContext.Categories.Add(category);
    }
    else
    {
      _dbContext.Categories.Update(category);
    }

    try
    {
      _dbContext.SaveChanges();
    }
    catch (Exception ex)
    {
      return View("Error");
    }

    return RedirectToAction("Details", "Category", new { id = category.Id });

    // return View("Details", author);
  }

  public ActionResult Delete(int id)
  {
    // Retrieve data from database based on id
    Category category = _dbContext.Categories.Find(id);

    if (category == null)
    {
      return RedirectToAction("Index");
    }

    _dbContext.Categories.Remove(category);
    _dbContext.SaveChanges();

    return RedirectToAction("Index");
  }
}