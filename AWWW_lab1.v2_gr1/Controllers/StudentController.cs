using Microsoft.AspNetCore.Mvc;
using AWWW_lab1.v2_gr1.Models;

namespace AWWW_lab1.v2_gr1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index(int id=1)
        {
            var students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    FirstName = "Ronald",
                    LastName = "Pralski",
                    IndexNr = "s12345",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    FieldOfStudy = "Informatyka"
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Anna",
                    LastName = "Tomalska",
                    IndexNr = "s54321",
                    DateOfBirth = new DateTime(2001, 5, 12),
                    FieldOfStudy = "Matematyka"
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Piotr",
                    LastName = "Nerkowski",
                    IndexNr = "s98765",
                    DateOfBirth = new DateTime(1999, 9, 23),
                    FieldOfStudy = "Fizyka"
                }
            };

            return View(students[id-1]); // będzie szukać Views/Student/Index.cshtml
        }
    }
}