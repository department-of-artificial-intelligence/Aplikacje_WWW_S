using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;

public class StudentController : Controller
{
    public IActionResult Index(int id = 1)
    {
        var Studenci = new List<Student>
        {
        new Student{
            Id = 1,
            FirstName = "Jakub",
            LastName = "Grzybowski",
            IndexNr = 136541,
            DateOfBirth = DateTime.Today,
            FieldOfStudy = "Informatyka"
        },
         new Student{
            Id = 2,
            FirstName = "Michał",
            LastName = "Kowalski",
            IndexNr = 200123,
            DateOfBirth = new DateTime(2000, 5, 12),
            FieldOfStudy = "Matematyka"
        },
        new Student{
            Id = 3,
            FirstName = "Anna",
            LastName = "Nowak",
            IndexNr = 210456,
            DateOfBirth = new DateTime(2001, 8, 22),
            FieldOfStudy = "Biotechnologia"
        },
        new Student{
            Id = 4,
            FirstName = "Karolina",
            LastName = "Wiśniewska",
            IndexNr = 220789,
            DateOfBirth = new DateTime(1999, 11, 3),
            FieldOfStudy = "Psychologia"
        }
        };

        return View(Studenci[id - 1]);
    }
}