using Kolokwium.Model.DataModels;
using Kolokwium.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Web.Controllers;

public class BookController : Controller
{
    private readonly IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    public IActionResult Index()
    {
        var books = _bookService.ViewAll();
        return View(books);
    }
    public IActionResult Delete(int id)
    {
        _bookService.Delete(id);
        return RedirectToAction("Index");
    }
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(Book book)
    {
        _bookService.Add(book);
        return RedirectToAction("Index");
    }
 
    public IActionResult Update(int id)
    {
        var existingBook = _bookService.Update(id);
        if (existingBook == null)
        {
            return NotFound();
        }
        return View(existingBook);
    }
  
}