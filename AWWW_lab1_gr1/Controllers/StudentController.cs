
using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

public class StudentController : Controller {
    public IActionResult Index(int id=1) {
        var students = new List<Student>
        {
            new Student{
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                DateOfBirth = new DateTime(2003, 03, 17),
                FieldOfStudy = "Applied mathematics"
            },
            new Student{
                Id = 2,
                FirstName = "Marek",
                LastName = "Kolinski",
                DateOfBirth = new DateTime(1998, 07, 12),
                FieldOfStudy = "Filosophy"
            },
            new Student{
                Id = 3,
                FirstName = "Andrzej",
                LastName = "Zieliński",
                DateOfBirth = new DateTime(2001, 11, 05),
                FieldOfStudy = "Programowanie stron internetowych"
            }
        };

        return View(students[id-1]);
    }
}