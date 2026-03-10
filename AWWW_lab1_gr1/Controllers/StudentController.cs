using System;
using System.Collections.Generic;
using System.Linq;
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
                IndexNr = "12345",
                DateOfBirth = new DateTime(2000, 5, 15),
                FieldOfStudy = "Informatyka"
            },
            new Student
            {
                Id = 2,
                FirstName = "Anna",
                LastName = "Nowak",
                IndexNr = "12346",
                DateOfBirth = new DateTime(2001, 8, 22),
                FieldOfStudy = "Zarządzanie"
            },
            new Student
            {
                Id = 3,
                FirstName = "Piotr",
                LastName = "Wiśniewski",
                IndexNr = "12347",
                DateOfBirth = new DateTime(1999, 12, 10),
                FieldOfStudy = "Elektronika"
            }
        };

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}