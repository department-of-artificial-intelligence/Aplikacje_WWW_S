using Microsoft.AspNetCore.Mvc;
using Kolokwium.Services.Interfaces;

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
        var books = _bookService.GetBooks();
        return View(books);
    }
}
