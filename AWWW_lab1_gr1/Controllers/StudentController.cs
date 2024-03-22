using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr1.Models;


 public class StudentController:Controller{

    public IActionResult Index(int id=1)
    {
        var studenty = new List<Student>
        {
            new Student{
            ID = 1,
            FirstName = "Jakub",
            LastName = "kowalski",
            IndexNr = 311337,
            DateOfBirth = new DateTime(1999,01,30),
            FieldOfStudy = "Informatyka"
            },
            new Student{
            ID = 2,
            FirstName = "Adriana",
            LastName = "Wróbel",
            IndexNr = 321161,
            DateOfBirth = new DateTime(2000,09,15),
            FieldOfStudy = ""
            },
            new Student{
            ID = 3,
            FirstName = "Marcin",
            LastName = "Zawadski",
            IndexNr = 341488,
            DateOfBirth = new DateTime(2003,11,11),
            FieldOfStudy = "Budownictwo"
            }
        
  
        };
        return View(studenty[id-1]);
    }
}