using AWWW_lab2_gr2.Models;
using Microsoft.AspNetCore.Mvc;

public class PositionController : Controller{
    
    private readonly MyDbContext _dbContext;
    
    public PositionController(MyDbContext dbContext){
        _dbContext = dbContext;
    }
    
    public IActionResult Index(){
        var positions = _dbContext.Positions!.ToList();
        return View(positions);
    }
    
    public IActionResult Add(int id = -1){
        if (id != -1){
            var position = _dbContext.Positions!.FirstOrDefault(a=>a.Id==id);
            return View(position);
        }else{
            return View();
        }
    }
    
    [HttpPost]
    public IActionResult Add(Position position){
        if(position.Name == null){
            ViewBag.Error = "Pole name jest wymagane";
            return View();
        }
        
        if (position.Id != 0){
            var a = _dbContext.Positions!.FirstOrDefault(a=>a.Id == position.Id);
            if(a != null){
                a.Name = position.Name;
            }
        }else{
            _dbContext.Positions!.Add(position);
        }
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
    
}