using AWWW_lab2_gr2.Models;
using Microsoft.AspNetCore.Mvc;

public class EventTypeController : Controller{
    
    private readonly MyDbContext _dbContext;
    
    public EventTypeController(MyDbContext dbContext){
        _dbContext = dbContext;
    }
    
    public IActionResult Index(){
        var eventTypes = _dbContext.EventTypes!.ToList();
        return View(eventTypes);
    }
    
    public IActionResult Add(int id = -1){
        if (id != -1){
            var eventType = _dbContext.EventTypes!.FirstOrDefault(a=>a.Id==id);
            return View(eventType);
        }else{
            return View();
        }
    }
    
    [HttpPost]
    public IActionResult Add(EventType eventType){
        if (eventType.Id != 0){
            var a = _dbContext.EventTypes!.FirstOrDefault(a=>a.Id == eventType.Id);
            if(a != null){
                a.Name = eventType.Name;
            }
        }else{
            _dbContext.EventTypes!.Add(eventType);
        }
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
    
}