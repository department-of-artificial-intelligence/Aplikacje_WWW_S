using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;
public class StudentController:Controller{
    public IActionResult Index(int id=1)
    {
        var students = new List<Student>
        {
            new Student{
                Id = 1,
                FirstName = "Joanna",
                LastName = "Dolnicz",
                IndexNr = 145678,
                DateOfBirth = DateTime.Today,
                FieldOfStudy = "Zarządzanie"
            },
            new Student{
                Id = 2,
                FirstName = "Artur",
                LastName = "Król",
                IndexNr = 123456,
                DateOfBirth = DateTime.Today,
                FieldOfStudy = "Finanse"
            },
            new Student{
                Id = 3,
                FirstName = "Miłosz",
                LastName = "Kolan",
                IndexNr = 156765,
                DateOfBirth = DateTime.Today,
                FieldOfStudy = "Filologia Angielska"
            }

        };
        return View(students[id-1]);
    }
}