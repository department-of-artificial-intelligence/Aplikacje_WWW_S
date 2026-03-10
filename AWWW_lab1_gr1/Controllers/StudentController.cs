using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers;

public class StudentController : Controller
{
    public IActionResult Index(int id=1)
    {
        var students = new List<Student>{
            new Student{
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                IndexNr = 12345,
                DateOfBirth = new DateTime(2000, 1, 1),
                FieldOfStudy = "Informatyka"
            },
            new Student{
                Id = 2,
                FirstName = "Anna",
                LastName = "Nowak",
                IndexNr = 12346,
                DateOfBirth = new DateTime(2001, 1, 2),
                FieldOfStudy = "Matematyka"
            },
            new Student{
                Id = 3,
                FirstName = "Piotr",
                LastName = "Wiśniewski",
                IndexNr = 12347,
                DateOfBirth = new DateTime(2002, 2, 3),
                FieldOfStudy = "Fizyka"
            }
        };

        return View(students[id-1]);
    }
}
