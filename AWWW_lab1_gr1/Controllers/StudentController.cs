using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

public class StudentController : Controller
{
    public IActionResult Index(int id = 1)
    {
        var students = new List<Student>
        {
            new Student
            {
                Id = 1,
                FirstName = "Kamil",
                LastName = "Czudaj",
                IndexNr = 133999,
                DateOfBirth = new DateTime(2001, 5, 15),
                FieldOfStudy = "Computer Science"
            },
            new Student
            {
                Id = 2,
                FirstName = "Jan",
                LastName = "Kowalski",
                IndexNr = 133929,
                DateOfBirth = new DateTime(2002, 2, 11),
                FieldOfStudy = "Computer Science"
            },
            new Student
            {
                Id = 3,
                FirstName = "Artur",
                LastName = "Janik",
                IndexNr = 123999,
                DateOfBirth = new DateTime(2003, 5, 15),
                FieldOfStudy = "Computer Science"
            }
        };

        return View(students[id - 1]);
    }
}
