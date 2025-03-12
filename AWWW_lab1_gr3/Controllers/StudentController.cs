using Microsoft.AspNetCore.Mvc;
using AWWW_lab1_gr3.Models;

public class StudentController: Controller
{
    public IActionResult Index(int id =1){
       var students = new List<Student>
       {
        new Student{
            Id = 1,
            FirstName = "Lukasz",
            LastName = "Nowak",
            IndexNr = 13344,
            DateOfBirth = DateTime.Now,
            FieldOfStudy ="IT"
        },
        new Student{
            Id = 2,
            FirstName = "Adam",
            LastName = "Kowalski",
            IndexNr = 13352,
            DateOfBirth = DateTime.Now,
            FieldOfStudy ="Civil engineering"
        }
            
       };
       
       return View(students[id-1]);
    }
}
