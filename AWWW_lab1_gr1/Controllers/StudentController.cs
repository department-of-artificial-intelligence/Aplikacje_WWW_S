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
                FirstName = "Jan",
                LastName = "Kowalski",
                IndexNr = "12345",
                DateOfBirth = new DateTime(1995, 5, 15),
                FieldOfStudy = "IT"
            },
            new Student
            {
                Id = 2,
                FirstName = "Cristiano",
                LastName = "Ronaldo",
                IndexNr = "13370",
                DateOfBirth = new DateTime(1985, 2, 5),
                FieldOfStudy = "Science"
            },
            new Student
            {
                Id = 3,
                FirstName = "Adam",
                LastName = "Nowak",
                IndexNr = "54321",
                DateOfBirth = new DateTime(1999, 1, 9),
                FieldOfStudy = "Math"
            }
        };

        return View(students);
    }
}