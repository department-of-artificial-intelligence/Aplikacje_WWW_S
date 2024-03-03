using Microsoft.AspNetCore.Mvc;

public class StudentController : Controller {
    public IActionResult Index(int id = 1) 
    {
        var students = new List<Student> 
        {
            new Student {
                Id = 1,
                FirstName = "Mateusz",
                LastName = "Janik",
                IndexNr = 134948,
                DateOfBirth = DateTime.Now.AddYears(-20),
                FieldOfStudy = "PAI"
            },
            new Student {
                Id = 2,
                FirstName = "Jan",
                LastName = "Kowalski",
                IndexNr = 172973,
                DateOfBirth = DateTime.Now.AddYears(-20),
                FieldOfStudy = "PAI"
            },
            new Student {
                Id = 3,
                FirstName = "Marcin",
                LastName = "Nowak",
                IndexNr = 134583,
                DateOfBirth = DateTime.Now.AddYears(-20),
                FieldOfStudy = "PAI"
            }
        };

        return View(students[id-1]);
    }
}