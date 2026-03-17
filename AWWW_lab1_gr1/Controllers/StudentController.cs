using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;
using System.Collections.Generic;
using System.Linq;

namespace AWWW_lab1_gr1.Controllers
{
    public class StudentController : Controller
    {
        List<Student> students = new List<Student>()
        {
            new Student { Id = 1, FirstName = "Jan", LastName = "Kowalski"},
            new Student { Id = 2, FirstName = "Anna", LastName = "Nowak"},
            new Student { Id = 3, FirstName = "Piotr", LastName = "Wiśniewski"}
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