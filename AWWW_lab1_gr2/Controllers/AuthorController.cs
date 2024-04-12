using Microsoft.AspNetCore.Mvc;

using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Components.Web;

public class AuthorController: Controller {

    private readonly DatabaseContext _context; 
    public AuthorController(DatabaseContext context){
        _context = context; 
    }

    public IActionResult Index() {
        ViewBag.Title = "Autorzy"; 
        var authors = _context.Authors;
        return View(authors); 
    }

    [HttpGet]
    public IActionResult Add() {
        ViewBag.Title = "Dodawanie autora"; 
        return View(); 
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Add(Author author) {
        if(ModelState.IsValid){

            _context.Authors.Add(author); 
            _context.SaveChanges(); 
            return RedirectToAction("Index"); 
        }
        return RedirectToAction("Form"); 
    }


}