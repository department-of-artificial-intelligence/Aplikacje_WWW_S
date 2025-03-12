using Microsoft.AspNetCore.Mvc;
using AWWWW_lab1_gr3.Models;

public class StudentController : Controller 
{
    
        public IActionResult Index(int id=1)
    {
        var students = new List<Student>
        {
            new Student { 
            FirstName = "Kamil",
            LastName = "Malek",
            IndexNr = 133388,
            DateOfBirth = DateTime.Now,
            FieldOfStudy = "Informatyka"
            }
        };
        return View(students[id-1]);
    }
}
