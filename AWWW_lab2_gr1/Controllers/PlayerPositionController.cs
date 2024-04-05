using AWW_lab2_gr1;
using AWW_lab2_gr1.Models;
using Microsoft.AspNetCore.Mvc;


public class PlayerPositionController : Controller
{
  private readonly MyDbContext _dbContext;

  public PlayerPositionController(MyDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public IActionResult Index()
  {
    List<Position> positions = _dbContext.Positions.ToList();
    ViewBag.Title = "Player Positions";

    return View(positions);
  }

  public IActionResult Details(int id)
  {
    Position position = _dbContext.Positions.FirstOrDefault(el => el.Id == id);

    if (position == null)
    {
      return View("Error");
    }

    return View(position);
  }


  public IActionResult Add()
  {
    return View("Edit", new Position());
  }

  public IActionResult Edit(int id)
  {
    var position = _dbContext.Positions.FirstOrDefault(a => a.Id == id);

    if (position == null)
    {
      return View("Error");
    }

    return View("Edit", position);
  }

  [HttpPost]
  public IActionResult Save(Position position)
  {
    if (position.Id == 0)
    {
      _dbContext.Positions.Add(position);
    }
    else
    {
      _dbContext.Positions.Update(position);
    }

    try
    {
      _dbContext.SaveChanges();
    }
    catch (Exception ex)
    {
      return View("Error");
    }

    return RedirectToAction("Details", "PlayerPosition", new { id = position.Id });

    // return View("Details", author);
  }

  public ActionResult Delete(int id)
  {
    // Retrieve data from database based on id
    Position position = _dbContext.Positions.Find(id);

    if (position == null)
    {
      return RedirectToAction("Index");
    }

    _dbContext.Positions.Remove(position);
    _dbContext.SaveChanges();

    return RedirectToAction("Index");
  }
}