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
                Id = 1,
                FirstName = "Andriy",
                LastName = "Babyuk",
                IndexNr = "139183",
                DateOfBirth = new DateTime(2006, 03, 18),
                FieldOfStudy = "Informatyka"
            },
            new Student
            {
                Id = 2,
                FirstName = "Ala",
                LastName = "Kot",
                IndexNr = "110022",
                DateOfBirth = new DateTime(1984,12,12),
                FieldOfStudy = "Zarządzanie"
            },
            new Student
            {
                Id = 3,
                FirstName = "Test",
                LastName = "Value",
                IndexNr = "123456",
                DateOfBirth = new DateTime(2000,09,09),
                FieldOfStudy = "Matematyka stosowana"
            }
        };

        public IActionResult Index()
        {
            return View(students);
        }
        
        public IActionResult Details(int idx=1)
        {
            return View(students[idx-1]);
        }
    }
}