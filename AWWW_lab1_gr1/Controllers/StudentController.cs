using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index(int id = 1)
        {
            var students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    FirstName = "Bartosz",
                    LastName = "Olech",
                    IndexNr = 136599,
                    DateOfBirth = DateTime.Parse("2002-03-29"),
                    FieldOfStudy = "Informatyka"
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    IndexNr = 123456,
                    DateOfBirth = DateTime.Parse("2005-01-9"),
                    FieldOfStudy = "Zarządzanie"
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Kamil",
                    LastName = "Wojciechowski",
                    IndexNr = 158299,
                    DateOfBirth = DateTime.Parse("2000-11-30"),
                    FieldOfStudy = "Prawo"
                },
            };
            return View(students[id - 1]);
        }
    }
}