using Microsoft.AspNetCore.Mvc;

public class AutorController : Controller{
     private readonly MyDbContext _dbContext;

    public AutorController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IActionResult Index(int id)
    {
        var autor = _dbContext.Authors.FirstOrDefault(a => a.Id == id); //Repository.Articles.ToList()[id];
        if (autor != null)
            return View(autor);
        return NotFound();
    }

  
}