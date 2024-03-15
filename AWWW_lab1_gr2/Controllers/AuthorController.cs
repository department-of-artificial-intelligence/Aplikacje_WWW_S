using Microsoft.AspNetCore.Mvc;

using AWWW_lab1_gr2.Models;
using Microsoft.AspNetCore.Components.Web;

public class AuthorController: Controller {

    public IActionResult Index() {
        ViewBag.Title = "Dodawanie autora"; 
        return View(); 
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Add(Author author) {
        return Content(
            $"Dodano autora: {author.FirstName} {author.LastName} o id: {author.AuthorId}"
        ); 
    }

}