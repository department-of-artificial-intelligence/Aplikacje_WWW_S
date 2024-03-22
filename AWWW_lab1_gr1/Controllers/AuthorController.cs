using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AuthorController: Controller{
MyDbContext bdContext;

public AuthorController (MyDbContext bdContext){
   this.bdContext=bdContext;
}

public async Task<IActionResult> Index()
     {
        return View(await bdContext.Authors.ToListAsync());
     }

public IActionResult Add(){
   return View();
}

[HttpPost]

public async Task<IActionResult> Add(Author author){
   if(ModelState.IsValid)
           {
               bdContext.Add(author);
               await bdContext.SaveChangesAsync();
               return RedirectToAction("Index");
           }
   return View(author);
}

}