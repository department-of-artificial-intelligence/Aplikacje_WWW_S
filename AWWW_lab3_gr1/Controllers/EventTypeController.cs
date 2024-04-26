using AWWW_lab3_gr1;
using AWWW_lab3_gr1.Models;
using Microsoft.AspNetCore.Mvc;


public class EventTypeController : Controller
{
  private readonly MyDbContext _dbContext;

  public EventTypeController(MyDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public IActionResult Index()
  {
    List<EventType> eventTypes = _dbContext.EventTypes.ToList();
    ViewBag.Title = "Event Types";

    return View(eventTypes);
  }

  public IActionResult Details(int id)
  {
    EventType eventType = _dbContext.EventTypes.FirstOrDefault(el => el.ID == id);

    if (eventType == null)
    {
      return View("Error");
    }

    return View(eventType);
  }

  public IActionResult Add()
  {
    return View("Edit", new EventType());
  }

  public IActionResult Edit(int id)
  {
    var eventType = _dbContext.EventTypes.FirstOrDefault(a => a.ID == id);

    if (eventType == null)
    {
      return View("Error");
    }

    return View("Edit", eventType);
  }

  [HttpPost]
  public IActionResult Save(EventType eventType)
  {
    if (eventType.ID == 0)
    {
      _dbContext.EventTypes.Add(eventType);
    }
    else
    {
      _dbContext.EventTypes.Update(eventType);
    }

    try
    {
      _dbContext.SaveChanges();
    }
    catch (Exception ex)
    {
      return View("Error");
    }

    return RedirectToAction("Details", "EventType", new { id = eventType.ID });

    // return View("Details", author);
  }

  public ActionResult Delete(int id)
  {
    // Retrieve data from database based on id
    EventType eventType = _dbContext.EventTypes.Find(id);

    if (eventType == null)
    {
      return RedirectToAction("Index");
    }

    _dbContext.EventTypes.Remove(eventType);
    _dbContext.SaveChanges();

    return RedirectToAction("Index");
  }
}