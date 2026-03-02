using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> _students = new List<Student>
        {
            new Student { Id = 1, FirstName = "Ivan", LastName = "Petrenko", IndexNr = "12345", DateOfBirth = new DateTime(2003, 5, 15), FieldOfStudy = "Computer Science" },
            new Student { Id = 2, FirstName = "Olena", LastName = "Koval", IndexNr = "12346", DateOfBirth = new DateTime(2004, 2, 20), FieldOfStudy = "Cybersecurity" },
            new Student { Id = 3, FirstName = "Pen", LastName = "Bobryk", IndexNr = "12347", DateOfBirth = new DateTime(2002, 11, 10), FieldOfStudy = "Software Engineering" }
        };

        public IActionResult Index()
        {
            return View(_students);
        }

        public IActionResult Details(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }
    }
}