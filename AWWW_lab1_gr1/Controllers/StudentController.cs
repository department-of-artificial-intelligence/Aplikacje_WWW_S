using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;


 public class StudentController:Controller{

    public IActionResult Index(int id=1)
    {
        var studenty = new List<Student>
        {
            new Student{
            ID = 1,
            FirstName = "Vasya ",
            LastName = "Pupkin",
            IndexNr = 214712,
            DateOfBirth = new DateTime(2000,12,31),
            FielOfStudy = "Informatyka"
            },
            new Student{
            ID = 2,
            FirstName = "Ivan ",
            LastName = "Ivanych Ivanow",
            IndexNr = 643531,
            DateOfBirth = new DateTime(2004,05,11),
            FielOfStudy = "Logistika"
            },
            new Student{
            ID = 3,
            FirstName = "Petr",
            LastName = "Osetr",
            IndexNr = 534817,
            DateOfBirth = new DateTime(2002,04,06),
            FielOfStudy = "Architekruta"
            }
        
  
        };
        return View(studenty[id-1]);
    }
}