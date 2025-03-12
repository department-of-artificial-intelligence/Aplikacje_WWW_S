using AWWW_lab1_gr3.Models;
using Microsoft.AspNetCore.Mvc;

public class StudentController : Controller
{
    public IActionResult Index(int id=1)
    {
        var students = new List<Student>
        {
            new Student
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                IndexNr = 1000,
                DateOfBirth = DateTime.Now,
                FieldOfStudy = "IT"
            },
            new Student
            {
                Id = 2,
                FirstName = "Adam",
                LastName = "Nowak",
                IndexNr = 1001,
                DateOfBirth = DateTime.Now,
                FieldOfStudy = "WIM"
            },
            new Student
            {
                Id = 1,
                FirstName = "Marcin",
                LastName = "Koawlczyk",
                IndexNr = 1002,
                DateOfBirth = DateTime.Now,
                FieldOfStudy = "IT"
            }
        };
        return View(students[id-1]);
    }
}