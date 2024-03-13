using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr5.Models;

namespace AWWW_lab1_gr5.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index(int id=1)
        {
            var students = new List<Student>{
                new Student{
                    Id = 1,
                    Title = "Student 1",
                    FirstName = "Pawel",
                    LastName = "Ciura",
                    IndexNr = 133512,
                    DateOfBirth = DateTime.Now,
                    FieldOfStudy = "Informatyka"
                },
                new Student{
                    Id = 2,
                    Title = "Student 2",
                    FirstName = "Andrzej",
                    LastName = "Biały",
                    IndexNr = 133242,
                    DateOfBirth = DateTime.Now,
                    FieldOfStudy = "Robotyka"
                },
                new Student{
                    Id = 3,
                    Title = "Student 3",
                    FirstName = "Matej",
                    LastName = "Błaszczykiewicz",
                    IndexNr = 133964,
                    DateOfBirth = DateTime.Now,
                    FieldOfStudy = "Zarządzanie"
                }
            };
            
            return View(students[id-1]);
        }
    }
}
