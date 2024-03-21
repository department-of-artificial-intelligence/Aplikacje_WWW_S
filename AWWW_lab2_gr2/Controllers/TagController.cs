using AWWW_lab2_gr2.Models;
using Microsoft.AspNetCore.Mvc;

public class TagController : Controller{
    
    private readonly MyDbContext _dbContext;
    
    public TagController(MyDbContext dbContext){
        _dbContext = dbContext;
    }
    
    public IActionResult Index(){
        var tags = _dbContext.Tags!.ToList();
        return View(tags);
    }
    
    public IActionResult Add(int id = -1){
        if (id != -1){
            var tag = _dbContext.Tags!.FirstOrDefault(a=>a.Id==id);
            return View(tag);
        }else{
            return View();
        }
    }
    
    [HttpPost]
    public IActionResult Add(Tag tag){
        if (tag.Id != 0){
            var a = _dbContext.Tags!.FirstOrDefault(a=>a.Id == tag.Id);
            if(a != null){
                a.Name = tag.Name;
            }
        }else{
            _dbContext.Tags!.Add(tag);
        }
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
    
}