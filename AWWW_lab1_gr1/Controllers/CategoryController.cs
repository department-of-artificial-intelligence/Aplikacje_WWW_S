using AWWW_lab1_gr1;
using Microsoft.EntityFrameworkCore;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

public class CategoryControler: Controller 
{
     MyDbContext DbContext;

     public CategoryControler(MyDbContext DbContext)
     {
          this.DbContext = DbContext;
     }


     public async Task<IActionResult> Index()
     {
        return View(await DbContext.Categories.ToListAsync());
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
               DbContext.Add(category);
               await DbContext.SaveChangesAsync();
               return RedirectToAction("Index");
           }
           return View(category);
     }

}