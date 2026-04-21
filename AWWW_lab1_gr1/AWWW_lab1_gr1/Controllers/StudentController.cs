using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;
using System;

namespace AWWW_lab1_gr1.Controllers
{
	public class StudentController : Controller
    {
        public IActionResult Details(int id)
        {
            var students = Student.GetStudents();

            var student = students.FirstOrDefault(s => s.Id == id);

            return View(student);
        }
    }
}
