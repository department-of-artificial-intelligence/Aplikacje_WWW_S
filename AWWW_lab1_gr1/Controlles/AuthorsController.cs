using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AuthorsController: Controller{
MyDbContext DbContext;

public AuthorsController (MyDbContext DbContext){
   this.DbContext=DbContext;
}

public async Task<IActionResult> Index()
     {
        return View(await DbContext.Authors.ToListAsync());
     }

public IActionResult Add(){
   return View();
}

[HttpPost]

public async Task<IActionResult> Add(Author author){
   if(ModelState.IsValid)
           {
               DbContext.Add(author);
               await DbContext.SaveChangesAsync();
               return RedirectToAction("Index");
           }
   return View(author);
}

}