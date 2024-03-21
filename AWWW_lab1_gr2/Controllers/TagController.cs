using Microsoft.AspNetCore.Mvc;

using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Components.Web;

public class TagController: Controller {
    private readonly DatabaseContext _context; 
    public TagController(DatabaseContext context){
        _context = context; 
    }

    public IActionResult Index() {
        ViewBag.Title = "Dodawanie kategorii"; 
        return View(); 
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Add(Tag tag) {
        if(ModelState.IsValid){
            _context.Tags.Add(tag); 
            _context.SaveChanges(); 
            return RedirectToAction("Index"); 
        } 
        return RedirectToAction("Index"); 
    }

}