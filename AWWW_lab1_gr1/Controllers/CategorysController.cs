using AWWW_lab1_gr1;
using Microsoft.EntityFrameworkCore;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

public class CategoryControler: Controller 
{
     MeBdContext dbContext;

     public CategoryControler(MeBdContext meBdContext)
     {
          this.dbContext = meBdContext;
     }


     public async Task<IActionResult> Index()
     {
        return View(await dbContext.Categories.ToListAsync());
     }

     public  IActionResult Add()
     { 
       return View(); 
     }

     [HttpPost]

     public async Task<IActionResult> Add(Category category)
     {
           if(ModelState.IsValid)
           {
               dbContext.Add(category);
               await dbContext.SaveChangesAsync();
               return RedirectToAction("Index");
           }
           return View(category);
     }

}
