using AWWW_lab1_gr1;
using Microsoft.EntityFrameworkCore;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

public class CategoryControler: Controller 
{
     DbContext bdContext;

     public CategoryControler(DbContext bdContext)
     {
          this.bdContext = bdContext;
     }


     public async Task<IActionResult> Index()
     {
        return View(await bdContext.Categories.ToListAsync());
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
               bdContext.Add(category);
               await bdContext.SaveChangesAsync();
               return RedirectToAction("Index");
           }
           return View(category);
     }

}