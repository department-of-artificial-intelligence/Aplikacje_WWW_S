using AWWW_lab1_gr1;
using Microsoft.EntityFrameworkCore;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

public class CategoryControler: Controller 
{
     MyDbContext bdContext;

     public CategoryControler(MyDbContext bdContext)
     {
          this.bdContext = bdContext;
     }


     public async Task<IActionResult> Index() {
        try
        {
            return View(await bdContext.Categories.ToListAsync());
        }
        catch (Exception ex)
        {
            
            return View("Views/Category/Index.cshtml");
        }
    }

     [HttpPost]

     public async Task<IActionResult> Add(Category category)
     {
           if(ModelState.IsValid)
           {
               bdContext.Add(category);
               await bdContext.SaveChangesAsync();
               return RedirectToAction("Views/Category/Add.cshtml");
           }
           return View(category);
     }

}