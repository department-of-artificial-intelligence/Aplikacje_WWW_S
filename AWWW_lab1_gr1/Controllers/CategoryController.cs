using AWWW_lab1_gr1;
using Microsoft.EntityFrameworkCore;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

public class CategoryController: Controller 
{
   private  MeBdContext dbContext;

     public CategoryController(MeBdContext meBdContext)
     {
          this.dbContext = meBdContext;
     }


     public async Task<IActionResult> Index()
     {
         try{
      
            var category = await dbContext.Categories.ToListAsync();
            return View(category);
         }
         catch(Exception ex)
         {
          throw;
         }

          
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
