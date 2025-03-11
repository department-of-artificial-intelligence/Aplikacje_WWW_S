using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;
using System.Linq;

public class DetailsController : Controller
{
    public IActionResult Details(int id)
    {
        var student = StudentRepository.Students.FirstOrDefault(s => s.Id == id);
        if (student == null)
            return NotFound();
            
        return View(student);
    }
}
