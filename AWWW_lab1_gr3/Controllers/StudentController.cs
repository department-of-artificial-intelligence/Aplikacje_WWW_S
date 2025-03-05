using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;

public class StudentController : Controller
{
    public IActionResult Index(int id = 1)
    {
        var students = new List<Student>{


            new Student{
            Id = 1,
            FirstName = "Jacob",
            LastName = "Grzybowski",
            IndexNr = 123567,
            DateOfBirth = new DateTime(2003,07,4),
            FieldOfStudy = "Logistic"
            },

          new Student{
            Id = 2,
            FirstName = "Jacob2",
            LastName = "Grzybowski",
            IndexNr = 123567,
            DateOfBirth = new DateTime(2003,07,4),
            FieldOfStudy = "Logistic"
            },

           new Student{
            Id = 3,
            FirstName = "Jacob3",
            LastName = "Grzybowski",
            IndexNr = 123567,
            DateOfBirth = new DateTime(2003,07,4),
            FieldOfStudy = "Logistic"
            },
        };
        return View(students[id - 1]);
    }

}