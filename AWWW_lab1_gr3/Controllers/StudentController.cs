using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;
public class StudentController : Controller
{
    public IActionResult Index()
    {
        var students = StudentRepository.students;
        return View(students);
    }
}