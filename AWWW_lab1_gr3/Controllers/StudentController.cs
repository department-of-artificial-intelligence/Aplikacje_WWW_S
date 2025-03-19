using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;

public class StudentController : Controller {
    public IActionResult Index(int id=1) {
        var students = new List<Student>
        {
            new Student {
                Id = 1,
                FirstName = "Małgorzata",
                LastName = "Stasiak",
                IndexNr = 123456,
                DateOfBirth = new DateTime(2003,7,1),
                FieldOfStudy = "budownictwo",
            },
            new Student {
                Id = 2,
                FirstName = "Maria",
                LastName = "Romanowska",
                IndexNr = 234567,
                DateOfBirth = new DateTime(2002,7,10),
                FieldOfStudy = "matematyka",
            },
            new Student {
                Id = 3,
                FirstName = "Nikodem",
                LastName = "Janik",
                IndexNr = 345678,
                DateOfBirth = new DateTime(2004,9,17),
                FieldOfStudy = "informatyka",
            }
        };
        //ViewBag.Title = "Article";
        return View(students[id-1]);
    }
}