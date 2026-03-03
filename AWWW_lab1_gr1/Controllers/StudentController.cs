using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using AWWW_lab1_gr1.Models;


namespace AWWW_lab1_gr1.Controllers
{
    public class StudentController : Controller
    {
        List<Student> students = new List<Student>
        {
            new Student
            {
                Id = 0,
                FirstName = "Andriy",
                LastName = "Babyuk",
                IndexNr = "139183",
                DateOfBirth = DateTime.Parse("18-03-2006"),
                FieldOfStudy = "Informatyka"
            },
            new Student
            {
                Id = 1,
                FirstName = "Ala",
                LastName = "Kot",
                IndexNr = "110022",
                DateOfBirth = DateTime.Parse("12-12-1984"),
                FieldOfStudy = "Zarządzanie"
            },
            new Student
            {
                Id = 2,
                FirstName = "Test",
                LastName = "Value",
                IndexNr = "123456",
                DateOfBirth = DateTime.Parse("09-09-2000"),
                FieldOfStudy = "Matematyka stosowana"
            }
        };
        public IActionResult List(int id=1)
        {
            return View(students[id-1].getFullName());
        }
    }
}