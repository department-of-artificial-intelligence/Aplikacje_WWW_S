using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;

public class StudentController : Controller
{
    public IActionResult Index(int id)
    {
        var students = new List<Student>{
            new Student{
                Id = 1,
                FirstName = "Cezary",
                LastName = "Ślęzoz",
                IndexNr = 12,
                FieldOfStudy = "Informatyka",
                DateOfBirth = DateTime.Today
            },
            new Student{
                Id = 2,
                FirstName = "Anna",
                LastName = "Musi",
                IndexNr = 13,
                FieldOfStudy = "Zarządzanie",
                DateOfBirth = DateTime.Now
            },
            new Student{
                Id = 3,
                FirstName = "Maciej",
                LastName = "Musiał",
                IndexNr = 14,
                FieldOfStudy = "Sztuka",
                DateOfBirth = DateTime.Today
            }
        };
        return View(students[id-1]);
    }
}