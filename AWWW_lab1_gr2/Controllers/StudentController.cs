using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;
public class StudentController:Controller{
    public IActionResult Index(int id=1)
    {
        var students = new List<Student>
        {
            new Student{
                Id = 1,
                FirstName = "Adrian",
                LastName = "Żuberek",
                IndexNr = 352532,
                DateOfBirth = DateTime.Today,
                FieldOfStudy = "Informatyka"
            },
            new Student{
                Id = 2,
                FirstName = "Paweł",
                LastName = "Wodzisławski",
                IndexNr = 546767,
                DateOfBirth = DateTime.Today,
                FieldOfStudy = "Informatyka"
            },
            new Student{
                Id = 3,
                FirstName = "Marceli",
                LastName = "Zdun",
                IndexNr = 906775,
                DateOfBirth = DateTime.Today,
                FieldOfStudy = "Informatyka"
            }
            
        };
        return View(students[id-1]);
    }
}