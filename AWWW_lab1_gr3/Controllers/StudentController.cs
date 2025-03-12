using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;

namespace AWWW_lab1_gr3.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index(int id=1){
            var students = new List<Student>
            {
                new Student{
                    Id = 1,
                    FirstName = "Vladyslav1",
                    LastName = "Turchynovych",
                    DateOfBirth = new DateTime(0, 1, 1),
                    FieldOfStudy = "Informatyka"
                },
                new Student{
                    Id = 2,
                    FirstName = "Vladyslav2",
                    LastName = "Turchynovych",
                    DateOfBirth = new DateTime(0, 1, 1),
                    FieldOfStudy = "Informatyka"
                },
                new Student{
                    Id = 3,
                    FirstName = "Vladyslav3",
                    LastName = "Turchynovych",
                    DateOfBirth = new DateTime(0, 1, 1),
                    FieldOfStudy = "Informatyka"
                },
            };
            return View(students[id - 1]);
        }
    }
}