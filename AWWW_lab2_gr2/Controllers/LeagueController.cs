using AWWW_lab2_gr2.Models;
using Microsoft.AspNetCore.Mvc;

public class LeagueController : Controller{
    
    private readonly MyDbContext _dbContext;
    
    public LeagueController(MyDbContext dbContext){
        _dbContext = dbContext;
    }
    
    public IActionResult Index(){
        var leagues = _dbContext.Leagues!.ToList();
        return View(leagues);
    }
    
    public IActionResult Add(int id = -1){
        if (id != -1){
            var league = _dbContext.Leagues!.FirstOrDefault(a=>a.Id==id);
            return View(league);
        }else{
            return View();
        }
    }
    
    [HttpPost]
    public IActionResult Add(League league){
        if (league.Id != 0){
            var a = _dbContext.Leagues!.FirstOrDefault(a=>a.Id == league.Id);
            if(a != null){
                a.Name = league.Name;
                a.Country = league.Country;
                a.Level = league.Level;
            }
        }else{
            _dbContext.Leagues!.Add(league);
        }
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
    
}