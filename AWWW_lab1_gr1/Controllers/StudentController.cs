using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> _students = new List<Student>
        {
            new Student
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                IndexNr = "s12345",
                DateOfBirth = new DateTime(1995, 5, 20),
                FieldOfStudy = "Informatyka"
            },
            new Student
            {
                Id = 2,
                FirstName = "Anna",
                LastName = "Nowak",
                IndexNr = "s54321",
                DateOfBirth = new DateTime(1996, 8, 15),
                FieldOfStudy = "Matematyka"
            },
            new Student
            {
                Id = 3,
                FirstName = "Piotr",
                LastName = "Zieliński",
                IndexNr = "s67890",
                DateOfBirth = new DateTime(1994, 12, 10),
                FieldOfStudy = "Fizyka"
            }
        };

        public IActionResult Index()
        {
            return View(_students);
        }

        public IActionResult Details(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}