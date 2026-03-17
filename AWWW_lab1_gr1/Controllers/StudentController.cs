using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;

namespace AWWW_lab1_gr1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var students = Student.GetStudents();
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var students = Student.GetStudents();
            var student = students[id - 1];
            
            return View(student);
        }
    }
}