using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Web;
using AWWW_lab1_gr2.Models;
public class StudentController : Controller
{
    public IActionResult Student(int id)
    {
        return Index(id);
    }

    public IActionResult Index(int id) {
        var students = new List<Student>
        {
            new Student { Id = 1, FirstName = "Jan", LastName = "Kowalski", IndexNr = 123456, DateOfBirth = DateTime.Now, FieldOfStudy = "Informatyka" },
            new Student { Id = 2, FirstName = "Anna", LastName = "Nowak", IndexNr = 234567, DateOfBirth = DateTime.Now, FieldOfStudy = "Matematyka" },
            new Student { Id = 3, FirstName = "Piotr", LastName = "Wiśniewski", IndexNr = 345678, DateOfBirth = DateTime.Now, FieldOfStudy = "Fizyka" }
        };

        if(id==0) {
            return View(students);
        }
        return View(students[id-1]);
    }

}

