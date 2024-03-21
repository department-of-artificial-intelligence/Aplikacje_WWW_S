using AWWW_lab2_gr2.Models;
using Microsoft.AspNetCore.Mvc;

public class CategoryController : Controller{
    
    private readonly MyDbContext _dbContext;
    
    public CategoryController(MyDbContext dbContext){
        _dbContext = dbContext;
    }
    
    public IActionResult Index(){
        var categories = _dbContext.Categories!.ToList();
        return View(categories);
    }
    
    public IActionResult Add(int id = -1){
        if (id != -1){
            var category = _dbContext.Categories!.FirstOrDefault(a=>a.Id==id);
            return View(category);
        }else{
            return View();
        }
    }
    
    [HttpPost]
    public IActionResult Add(Category category){
        if (category.Id != 0){
            var a = _dbContext.Categories!.FirstOrDefault(a=>a.Id == category.Id);
            if(a != null){
                a.Name = category.Name;
            }
        }else{
            _dbContext.Categories!.Add(category);
        }
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
    
}