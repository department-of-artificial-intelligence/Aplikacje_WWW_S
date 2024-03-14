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
                FirstName = "Mateusz",
                LastName = "Janik",
                IndexNr = 671209,
                DateOfBirth = new DateTime(2001, 8, 23),
                FieldOfStudy = "Computer Science"
            },
            new Student
            {
                Id = 2,
                FirstName = "Jan",
                LastName = "Nowak",
                IndexNr = 134512,
                DateOfBirth = new DateTime(2002, 4, 3),
                FieldOfStudy = "Computer Science"
            },
            new Student
            {
                Id = 3,
                FirstName = "Kamil",
                LastName = "Buła",
                IndexNr = 139837,
                DateOfBirth = new DateTime(2002, 7, 19),
                FieldOfStudy = "Artifical Inteligence"
            }
        };

        return View(students[id - 1]);
    }
}
