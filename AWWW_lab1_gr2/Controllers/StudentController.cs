using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AWWW_lab1_gr2.Models;

namespace AWWW_lab1_gr2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var studenci = new List<Student>{
                new Student {
                Id = 1,
                FirstName = "Patryk",
                LastName = "Wawrzak",
                IndexNr = 100000,
                DateOfBirth = DateTime.Now,
                FieldOfStudy = "Informatyka"
                },
                new Student {
                Id = 2,
                FirstName = "Lorem",
                LastName = "Ipsum",
                IndexNr = 100001,
                DateOfBirth = DateTime.Now,
                FieldOfStudy = "Matematyka"
                },
                new Student {
                Id = 3,
                FirstName = "Bop",
                LastName = "Ili",
                IndexNr = 100002,
                DateOfBirth = DateTime.Now,
                FieldOfStudy = "Mechatronika"
                }
            };
            return View(studenci);
        }
    }
}