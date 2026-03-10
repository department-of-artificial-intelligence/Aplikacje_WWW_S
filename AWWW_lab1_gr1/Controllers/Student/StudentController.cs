using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                IndexNr = "s12345",
                DateOfBirth = new DateTime(2000,5,12),
                FieldOfStudy = "Informatyka"
            },
            new Student
            {
                Id = 2,
                FirstName = "Anna",
                LastName = "Nowak",
                IndexNr = "s23456",
                DateOfBirth = new DateTime(1999,8,21),
                FieldOfStudy = "Matematyka"
            },
            new Student
            {
                Id = 3,
                FirstName = "Piotr",
                LastName = "Wiśniewski",
                IndexNr = "s34567",
                DateOfBirth = new DateTime(2001,2,3),
                FieldOfStudy = "Fizyka"
            }
        };

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }
    }
}