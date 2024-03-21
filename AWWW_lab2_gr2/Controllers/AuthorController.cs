using AWWW_lab2_gr2.Models;
using Microsoft.AspNetCore.Mvc;

public class AuthorController : Controller{
    
    private readonly MyDbContext _dbContext;
    
    public AuthorController(MyDbContext dbContext){
        _dbContext = dbContext;
    }
    
    public IActionResult Index(){
        var authors = _dbContext.Authors!.ToList();
        return View(authors);
    }
    
    public IActionResult Add(int id =-1){
        if (id != -1){
            var author = _dbContext.Authors!.FirstOrDefault(a=>a.Id==id);
            return View(author);
        }else{
            return View();
        }
    }
    
    [HttpPost]
    public IActionResult Add(Author author){
        if (author.Id !=0 ){
            var a = _dbContext.Authors!.FirstOrDefault(a=>a.Id == author.Id);
            if (a!=null){
                a.FirstName = author.FirstName;
                a.LastName = author.LastName;
            }
        }else{
            _dbContext.Authors!.Add(author);
        }
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
}