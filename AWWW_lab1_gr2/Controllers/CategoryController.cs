using Microsoft.AspNetCore.Mvc;

using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Components.Web;

public class CategoryController: Controller {
    private readonly DatabaseContext _context; 
    public CategoryController(DatabaseContext context){
        _context = context; 
    }

    public IActionResult Index() {
        ViewBag.Title = "Kategorie"; 
        var categories = _context.Categories;
        return View(categories); 
    }

    public IActionResult Form() {
        ViewBag.Title = "Dodawanie kategorii"; 
        return View(); 
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Add(Category category) {
        if(ModelState.IsValid){

            _context.Categories.Add(category); 
            _context.SaveChanges(); 
            return RedirectToAction("Index"); 
        }
        return RedirectToAction("Index");  
    }

}