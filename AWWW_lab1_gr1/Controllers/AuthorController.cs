using AWWW_lab1_gr1;
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class Author: Controller{
DbContext bdContext;

public Author (DbContext bdContext){
   this.bdContext=bdContext;
}

public async Task<IActionResult> Index(){
    return View(await dbContext.Authors.ToListAsync());
}

public IActionResult Add(){
   return View();
}

[HttpPost]

public async Task<IActionResult> Add(Author author){
   if (ModelState.IsValid){
      bdContext.Add(author);
      await bdContext.SaveChangesAsyns();
      return RedirectToAction("Index");

   }
   return Viev(author);
}

}