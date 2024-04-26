using AWWW_lab3_gr1;
using AWWW_lab3_gr1.Models;
using Microsoft.AspNetCore.Mvc;


public class TagController : Controller
{
  private readonly MyDbContext _dbContext;

  public TagController(MyDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public IActionResult Index()
  {
    List<Tag> tags = _dbContext.Tags.ToList();
    ViewBag.Title = "Tags";

    return View(tags);
  }

  public IActionResult Details(int id)
  {
    Tag tag = _dbContext.Tags.FirstOrDefault(el => el.Id == id);

    if (tag == null)
    {
      return View("Error");
    }

    return View(tag);
  }

  public IActionResult Add()
  {
    return View("Edit", new Tag());
  }

  public IActionResult Edit(int id)
  {
    var tag = _dbContext.Tags.FirstOrDefault(a => a.Id == id);

    if (tag == null)
    {
      return View("Error");
    }

    return View("Edit", tag);
  }

  [HttpPost]
  public IActionResult Save(Tag tag)
  {
    if (tag.Id == 0)
    {
      _dbContext.Tags.Add(tag);
    }
    else
    {
      _dbContext.Tags.Update(tag);
    }

    try
    {
      _dbContext.SaveChanges();
    }
    catch (Exception ex)
    {
      return View("Error");
    }

    return RedirectToAction("Details", "Tag", new { id = tag.Id });

    // return View("Details", author);
  }

  public ActionResult Delete(int id)
  {
    // Retrieve data from database based on id
    Tag tag = _dbContext.Tags.Find(id);

    if (tag == null)
    {
      return RedirectToAction("Index");
    }

    _dbContext.Tags.Remove(tag);
    _dbContext.SaveChanges();

    return RedirectToAction("Index");
  }
}