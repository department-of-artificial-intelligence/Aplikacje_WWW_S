using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;
public class StudentController : Controller
{
    public IActionResult Index(int id = 1)
    {
        

        var students = new List<Student>{
        new Student{
            Id = 1,
            FirstName = "Jan",
            LastName = "Kowalski",
            IndexNumber = "s1234",
            DateOfBirth = new DateTime(2003, 05, 12),
            FieldOfStudy = "Informatyka"
        },

        new Student{
            Id = 2,
            FirstName = "Andrzej",
            LastName = "Popek",
            IndexNumber = "s1325",
            DateOfBirth = new DateTime(1986, 01, 12),
            FieldOfStudy = "Informatyka"
        }, 
        
        new Student{
            
            Id = 3,
            FirstName = "Janusz",
            LastName = "Bilski",
            IndexNumber = "s1263",
            DateOfBirth = new DateTime(1999, 06, 12),
            FieldOfStudy = "Informatyka"
        }
        };

        return View(students[id-1]);
    }
}