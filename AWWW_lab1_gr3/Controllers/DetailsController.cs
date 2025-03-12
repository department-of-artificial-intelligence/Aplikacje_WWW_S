using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;
public class DetailsController : Controller
{
    public IActionResult Index(int Id)
    {
        var student = StudentRepository.students.FirstOrDefault(s => s.Id == Id);
        if(student == null)
        {
            return NotFound();
        }
        return View(student);
    }
}