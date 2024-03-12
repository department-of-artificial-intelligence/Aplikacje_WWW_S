using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;
public class StudentController : Controller {
    public IActionResult Index(int id=1) {
        var students = new List<Student>
        {
            new Student {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            IndexNr = 123456,
            DateOfBirth = DateTime.Now,
            FieldOfStudy = "Computer Science"
            },
            new Student {
            Id = 2,
            FirstName = "Eric",
            LastName = "Bauer",
            IndexNr = 123456,
            DateOfBirth = DateTime.Now,
            FieldOfStudy = "Computer Science"
            },
            new Student {
            Id = 3,
            FirstName = "Ivan",
            LastName = "Ivanov",
            IndexNr = 123456,
            DateOfBirth = DateTime.Now,
            FieldOfStudy = "Computer Science"
            },
        };

        return View(students[id-1]);
    }
}

