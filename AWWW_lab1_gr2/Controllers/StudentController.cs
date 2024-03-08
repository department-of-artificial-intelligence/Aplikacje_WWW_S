using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr2.Models;

public class StudentController:Controller{
    public IActionResult Index(int itemid){
        var studenci = new List<Student>{
            new Student{
                ID = 1,
                FirstName = "Kamil",
                LastName = "Zdun",
                IndexNr = 12121,
                DateOfBirth = DateTime.Today,
                FieldOfStudy = "Tynkarstwo"
            },
            new Student{
                ID = 2,
                FirstName = "Paweł",
                LastName = "Jumper",
                IndexNr = 12345,
                DateOfBirth = DateTime.Today,
                FieldOfStudy = "Akrobatyka"
            },
            new Student{
                ID = 3,
                FirstName = "Marson",
                LastName = "Marson",
                IndexNr = 11111,
                DateOfBirth = DateTime.Today,
                FieldOfStudy = "Dota"
            },

        };
        return View(studenci[itemid-1]);
    }
}