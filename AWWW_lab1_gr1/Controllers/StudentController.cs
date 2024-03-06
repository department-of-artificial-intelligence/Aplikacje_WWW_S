using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Student list";
            var students = new List<Student>() {
                new Student()
                {
                  Id = 1,
                  FirstName = "Jan",
                  LastName = "Kowalski",
                  IndexNr = 11111,
                  DateOfBirth = new DateTime(1999, 12, 1),
                  FieldOfStudy = "Informatyka"
                },
                new Student()
                {
                  Id = 2,
                  FirstName = "Anna",
                  LastName = "Nowicka",
                  IndexNr = 22222,
                  DateOfBirth = new DateTime(2001, 5, 15),
                  FieldOfStudy = "Medycyna"
                },
                new Student()
                {
                  Id = 3,
                  FirstName = "Piotr",
                  LastName = "Wieczorek",
                  IndexNr = 33333,
                  DateOfBirth = new DateTime(1998, 3, 8),
                  FieldOfStudy = "Historia"
                },
                new Student()
                {
                  Id = 4,
                  FirstName = "Maria",
                  LastName = "Malinowska",
                  IndexNr = 44444,
                  DateOfBirth = new DateTime(2000, 7, 22),
                  FieldOfStudy = "Psychologia"
                },
                new Student()
                {
                  Id = 5,
                  FirstName = "Tomasz",
                  LastName = "Kwiatkowski",
                  IndexNr = 55555,
                  DateOfBirth = new DateTime(1997, 10, 1),
                  FieldOfStudy = "Zarządzanie"
                }
            };
            ViewBag.StudentsCount = students.Count;

            var studentsName = new List<string>();
            foreach (var student in students)
            {
                studentsName.Add(student.FirstName + " " + student.LastName);
            }
            ViewBag.StudentsName = studentsName;

            return View();
        }
    }
}
