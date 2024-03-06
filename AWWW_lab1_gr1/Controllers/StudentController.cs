using AWWW_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab1_gr1.Controllers
{
    public class StudentController : Controller
    {
        private IList<Student>? _students;
        public StudentController()
        {
            _students = new List<Student>() {
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
                }
            };
        }
        public IActionResult Students()
        {
            ViewBag.Title = "Student list";

            if (_students == null) { return View(); }

            ViewBag.StudentsCount = _students.Count;

            var studentsName = new List<string>();
            foreach (var student in _students)
            {
                studentsName.Add(student.FirstName + " " + student.LastName);
            }
            ViewBag.StudentsName = studentsName;

            return View();
        }

        public IActionResult Index(int id = 1)
        {
            ViewBag.Title = "Student Info";

            if (_students != null && _students.Count > id)
            {
                return View(_students[id]);
            }
            return View();
        }
    }
}
